using bus;
using dal.Entities;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormPrintInvoice : Form
    {
        public frmMedicExamInfor mainForm;
        public string _PatientID;

        private readonly ClinicalInformationService clinicalInformationService = new ClinicalInformationService();
        private readonly PatientInformationService patientInformationService = new PatientInformationService();
        private readonly TreatmentInvoiceDetailsService treatmentInvoiceDetailsService = new TreatmentInvoiceDetailsService();
        private readonly TreatmentInvoiceService treatmentInvoiceService = new TreatmentInvoiceService();
        public FormPrintInvoice()
        {
            InitializeComponent();
        }

        private static string CheckNull(object param)
        {
            return (param == null || param.ToString() == "null" || param.ToString() == "") ? "" : param.ToString();
        }

        private void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            foreach (DataGridViewColumn column in dgvClinicalInfor.Columns)
            {
                column.ReadOnly = true;
            }

            // Cho phép chỉnh sửa cho cột "ColumnInvoice"
            dgvClinicalInfor.Columns["ColumnInvoice"].ReadOnly = false;
        }

        private void BindGrid(List<ClinicalInformation> list)
        {
            dgvClinicalInfor.Rows.Clear();

            var itemsWithInvoiceAndTreatment = list.Where(item => !isHasInvoice(item.ID.ToString()) && item.Treatment != null).ToList();

            for (int i = 0; i < itemsWithInvoiceAndTreatment.Count; i++)
            {
                var item = itemsWithInvoiceAndTreatment[i];
                string[] rowValues = {
            (i + 1).ToString(),
            item.ID.ToString(),
            CheckNull(item.Diagnosi.Diagnosis),
            CheckNull(item.Treatment.TreatmentName.Name),
            CheckNull(item.Treatment.TreatmentMethodName.Name),
            CheckNull(item.Treatment.Unit),
            CheckNull(item.Quantity),
            Convert.ToDecimal(CheckNull(item.Treatment.UnitPrice)).ToString("N0"),
            Convert.ToDecimal(CheckNull(item.TotalAmount)).ToString("N0"),
            CheckNull(item.Diagnosi.ExaminationTime),
            false.ToString()};
                dgvClinicalInfor.Rows.Add(rowValues);
            }

            if (dgvClinicalInfor.Rows.Count < 1)
                lblRedLine.Text = "Không có thông tin điều trị nào.";
        }

        private bool isHasInvoice(string clinicID)
        {
            var invoice = treatmentInvoiceDetailsService.GetByClinicInforID(clinicID);
            if (invoice == null)
                return false;
            return true;
        }

        private void FormPrintInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvClinicalInfor);

                var list = clinicalInformationService.GetByID(_PatientID);

                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsInvoiceCheckboxChecked()
        {
            return dgvClinicalInfor.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToBoolean(row.Cells["ColumnInvoice"].Value));
        }

        // Hàm này trả về danh sách các thông tin lâm sàng đã được check từ DataGridView
        private List<ClinicalInformation> GetCheckedItem(DataGridView data)
        {
            return (from DataGridViewRow row in data.Rows.Cast<DataGridViewRow>()
                    where Convert.ToBoolean(row.Cells["ColumnInvoice"].Value)
                    select clinicalInformationService.GetByClinicID(row.Cells["ColumnIDClinicInf"].Value.ToString())).ToList();
        }

        // Hàm này lưu một hóa đơn với danh sách các thông tin lâm sàng đã cho
        private int SaveInvoice(List<ClinicalInformation> list)
        {
            int idInvoice = treatmentInvoiceService.InsertNewInvoiceAndReturnID();

            List<int> listID = list.Select(item => item.ID).ToList();

            treatmentInvoiceDetailsService.InsertInforForInvoice(idInvoice, listID);
            return idInvoice;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInvoice();
                string invoiceId = SaveInvoice();
                CreateAndPrintInvoicePdf(invoiceId);
                RefreshForm(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ValidateInvoice()
        {
            if (!IsInvoiceCheckboxChecked())
                throw new Exception("Không có dịch vụ nào được chọn");
            var list = GetCheckedItem(dgvClinicalInfor);
            if (list.Count > 7)
                throw new Exception("Một hóa đơn thông thể có nhiều hơn 7 dịch vụ.");
        }

        private string SaveInvoice()
        {
            var list = GetCheckedItem(dgvClinicalInfor);
            return SaveInvoice(list).ToString();
        }

        private void CreateAndPrintInvoicePdf(string invoiceId)
        {
            CreateInvoicePdf(invoiceId);

            string pdfPath = Path.GetFullPath($"Invoices\\{invoiceId}.pdf");
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException($"Không tìm thấy tệp {pdfPath}");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
        }

        private void RefreshForm(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
            mainForm.frmMedicExamInfor_Load(sender, e);
        }
        private void CreateInvoicePdf(string invoiceId)
        {
            string templatePath = GetTemplatePath();
            string invoicesPath = GetInvoicesPath();

            string newPdfPath = Path.Combine(invoicesPath, $"{invoiceId}.pdf");

            CopyFile(templatePath, newPdfPath);

            byte[] pdfContent = File.ReadAllBytes(templatePath);

            using (MemoryStream ms = new MemoryStream(pdfContent))
            {
                PdfReader reader = null;
                PdfStamper stamper = null;
                try
                {
                    reader = new PdfReader(ms.ToArray());
                    stamper = new PdfStamper(reader, new FileStream(newPdfPath, FileMode.Create, FileAccess.Write));

                    AcroFields fields = stamper.AcroFields;

                    string fontPath = @"Resources\Fonts\OpenSans-VariableFont_wdth,wght.ttf";
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bf);

                    // Sử dụng font mới cho tất cả các trường trong PDF
                    foreach (string key in fields.Fields.Keys)
                    {
                        fields.SetFieldProperty(key, "textfont", times.BaseFont, null);
                    }

                    FillInvoiceFields(fields, invoiceId);
                }
                finally
                {
                    if (stamper != null)
                    {
                        stamper.Close();
                    }
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        private void FillInvoiceFields(AcroFields fields, string invoiceId)
        {
            var listClinicIds = clinicalInformationService.GetClinicInfoIdsByInvoiceId(Convert.ToInt32(invoiceId));
            listClinicIds.Sort();
            var treatments = clinicalInformationService.GetTreatmentNamesByIds(listClinicIds);
            var quantities = clinicalInformationService.GetQuantitiesByIds(listClinicIds);
            var amounts = clinicalInformationService.GetTotalAmountsByIds(listClinicIds);
            var total = treatmentInvoiceService.JustGetTotalAmount(Convert.ToInt32(invoiceId));

            fields.SetField("InvoiceId", invoiceId);
            fields.SetField("Name", patientInformationService.JustGetName(_PatientID));
            fields.SetField("Date", treatmentInvoiceService.JustGetDate(Convert.ToInt32(invoiceId)));
            fields.SetField("Address", patientInformationService.JustGetAddress(_PatientID));

            for (int i = 0; i < treatments.Count; i++)
            {
                fields.SetField($"Treatment{i + 1}", treatments[i]);
                fields.SetField($"Quan{i + 1}", quantities[i].ToString());
                fields.SetField($"Amount{i + 1}", ((decimal)amounts[i]).ToString("N0")); // Chuyển đổi số thành chuỗi với dấu phân cách hàng nghìn và không có số thập phân
            }

            fields.SetField("Total", total);
        }

        private string GetTemplatePath()
        {
            return @"Resources\Templates\Template.pdf";
        }

        private string GetInvoicesPath()
        {
            string invoicesPath = @"Invoices";
            Directory.CreateDirectory(invoicesPath);
            return Path.GetFullPath(invoicesPath);
        }

        private void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);
        }

        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvClinicalInfor.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ColumnInvoice"].Value))
                {
                    totalAmount += Convert.ToDecimal(row.Cells["ColumnTotalAmount"].Value);
                }
            }
            return totalAmount;
        }
        private void dgvClinicalInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClinicalInfor.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell) && dgvClinicalInfor.CurrentCell.IsInEditMode && dgvClinicalInfor.IsCurrentCellDirty && dgvClinicalInfor.Rows.Count > 0)
            {
                dgvClinicalInfor.EndEdit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrintInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckAll.Checked)
            {
                foreach (DataGridViewRow row in dgvClinicalInfor.Rows)
                {
                    row.Cells["ColumnInvoice"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvClinicalInfor.Rows)
                {
                    row.Cells["ColumnInvoice"].Value = false;
                }
            }
        }
        private void dgvClinicalInfor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClinicalInfor.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                txtTotalAmount.Text = CalculateTotalAmount().ToString("N0");
            }
        }
    }
}
