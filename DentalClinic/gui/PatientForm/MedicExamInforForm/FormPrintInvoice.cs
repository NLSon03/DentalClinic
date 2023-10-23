using bus;
using dal.Entities;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormPrintInvoice : Form
    {
        private Thread viewerThread;

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
            CheckNull(item.Treatment.UnitPrice),
            CheckNull(item.TotalAmount),
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
                SetDataForLabelName();
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

        private void CreateInvoicePdf(string invoiceId)
        {
            // Đường dẫn đến file PDF template
            string templatePath = @"F:\AllProject\CSharpProject\DoAn\DentalClinic\gui\Resources\Templates\Template.pdf";
            string invoicesPath = @"F:\AllProject\CSharpProject\DoAn\DentalClinic\gui\Invoices";

            string newPdfPath = Path.Combine(invoicesPath, $"{invoiceId}.pdf");
            Thread newThread = new Thread(() =>
            {
                File.Copy(templatePath, newPdfPath);
            });

            newThread.Start();

            // Đợi cho đến khi thread hoàn thành
            newThread.Join();
            // Mở file PDF mới để chỉnh sửa
            Thread editThread = new Thread(() =>
            {
                PdfReader reader = new PdfReader(templatePath);
                PdfStamper stamper = new PdfStamper(reader, new FileStream(newPdfPath, FileMode.Create, FileAccess.Write));



                // Lấy các trường form từ file PDF
                AcroFields fields = stamper.AcroFields;

                //Lấy các thông tin cần thiết
                var listClinicIds = clinicalInformationService.GetClinicInfoIdsByInvoiceId(Convert.ToInt32(invoiceId));
                listClinicIds.Sort();
                var treatments = clinicalInformationService.GetTreatmentNamesByIds(listClinicIds);
                var quantities = clinicalInformationService.GetQuantitiesByIds(listClinicIds);
                var amounts = clinicalInformationService.GetTotalAmountsByIds(listClinicIds);
                // Điền các trường với dữ liệu đơn
                fields.SetField("InvoiceId", invoiceId);
                fields.SetField("Name", patientInformationService.JustGetName(_PatientID));
                fields.SetField("Date", treatmentInvoiceService.JustGetDate(Convert.ToInt32(invoiceId)));
                fields.SetField("Address", patientInformationService.JustGetAddress(_PatientID));

                // Điền các trường với dữ liệu từ danh sách
                for (int i = 0; i < treatments.Count; i++)
                {
                    fields.SetField($"Treatment{i + 1}", treatments[i]);
                    fields.SetField($"Quan{i + 1}", quantities[i].ToString());
                    fields.SetField($"Amount{i + 1}", amounts[i].ToString());
                }

                // Đóng PdfStamper và PdfReader
                stamper.Close();
                reader.Close();
            });
            if (!newThread.IsAlive)
            {
                editThread.Start();
                editThread.Join();
            }
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
                if (!IsInvoiceCheckboxChecked())
                    throw new Exception("Không có dịch vụ nào được chọn");
                var list = GetCheckedItem(dgvClinicalInfor);
                if (list.Count > 7)
                    throw new Exception("Một hóa đơn thông thể có nhiều hơn 7 dịch vụ.");

                string invoiceId = SaveInvoice(list).ToString();

                CreateInvoicePdf(invoiceId);

                string pdfPath = $"F:\\AllProject\\CSharpProject\\DoAn\\DentalClinic\\gui\\Invoices\\{invoiceId}.pdf";

                //Process process = Process.Start(pdfPath);
                //process.Kill();

                btnExit_Click(sender, e);
                mainForm.frmMedicExamInfor_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvClinicalInfor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClinicalInfor.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                txtTotalAmount.Text = CalculateTotalAmount().ToString();
            }
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
            if (dgvClinicalInfor.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell) && dgvClinicalInfor.CurrentCell.IsInEditMode && dgvClinicalInfor.IsCurrentCellDirty)
            {
                dgvClinicalInfor.EndEdit();
            }
        }

        private void SetDataForLabelName()
        {
            var patient = patientInformationService.GetByID(_PatientID);
            lblPatient.Text = $"{patient.PatientID} | {patient.FullName}";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrintInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
