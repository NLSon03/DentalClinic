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

namespace gui.PatientForm.CompletingMedInvoiceForm
{
    public partial class frmPurchase : Form
    {
        private readonly MedicineService medService = new MedicineService();
        private readonly PrescriptionService prescriptionService = new PrescriptionService();
        private readonly MedicineInvoiceService medInvoice = new MedicineInvoiceService();
        private readonly MedicineInvoiceDetailService medInvoiceDetails = new MedicineInvoiceDetailService();
        private readonly PatientInformationService patient = new PatientInformationService();
        public int ID_p;
        public frmPurchase()
        {
            InitializeComponent();
        }
        private void BindGird(List<Prescription> p)
        {
            dgvMed.Rows.Clear();
            foreach (var pitem in p)
            {
                int index = dgvMed.Rows.Add();
                dgvMed.Rows[index].Cells[1].Value = pitem.ID;
                dgvMed.Rows[index].Cells[2].Value = pitem.TotalAmount;
            }
        }
        public int GetPatientID()
        {
            int a;
            a = ID_p;
            return a;
        }
        private DateTime GetDateTime()
        {
            DateTime dt = DateTime.Now;
            return dt;
        }
        private void frmPurchase_Load(object sender, EventArgs e)
        {
            string s = string.Format("ID bệnh nhân: {0}\n\nTên bệnh nhân: {1}", GetPatientID(), patient.GetByID(GetPatientID().ToString()).FullName);
            lblIDAndName.Text = s;
            string time = string.Format("Ngày {0}/{1}/{2}", GetDateTime().Day, GetDateTime().Month, GetDateTime().Year);
            lblTIme.Text = time;
            var list = prescriptionService.GetIDByPatientID(GetPatientID());
            BindGird(list);
        }

        private void lưuHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMed.Rows)
                {
                    if (row.Selected)
                    {
                        if (Convert.ToBoolean(row.Cells[3].Value) == true)
                        {
                            var medPurchase = new MedicineInvoice()
                            {
                                Date = GetDateTime(),
                                TotalAmount = Convert.ToDecimal(dgvMed.Rows[row.Index].Cells[2].Value.ToString())
                            };
                            medInvoice.InsertNew(medPurchase);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isHasInvoice(int clinicID)
        {
            var invoice = medInvoiceDetails.GetAllByInvoiceID(clinicID);
            if (invoice == null)
                return false;
            return true;
        }
        private bool IsInvoiceCheckboxChecked()
        {
            return dgvMed.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToBoolean(row.Cells["colMedInvoice"].Value));
        }
        private void frmPurchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        private string GetPath()
        {
            string invoicesPath = @"Invoices\MedicInvoice";
            Directory.CreateDirectory(invoicesPath);
            return Path.GetFullPath(invoicesPath);
        }
        private string GetTemplatePath()
        {
            return @"Resources\Templates\MedInvoice.pdf";
        }
        private void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);
        }
        private void CreateInvoicePdf(string invoiceId)
        {
            string templatePath = GetTemplatePath();
            string invoicesPath = GetPath();

            string newPdfPath = Path.Combine(invoicesPath, $"{invoiceId}.pdf");
            CopyFile(templatePath, newPdfPath);

            byte[] pdfContent = File.ReadAllBytes(templatePath);

            using (MemoryStream memory = new MemoryStream(pdfContent))
            {
                PdfReader reader = null;
                PdfStamper stamper = null;
                try
                {
                    reader = new PdfReader(memory.ToArray());
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
                    FillMedInvoice(fields, invoiceId);
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
            };
        }
        private void FillMedInvoice(AcroFields fields, string invoiceId)
        {
            //Lấy các thông tin cần thiết
            var listPrescriptionIds = prescriptionService.GetPrescriptionIdsByInvoiceId(Convert.ToInt32(invoiceId));
            listPrescriptionIds.Sort();
            var medName = prescriptionService.GetMedName(listPrescriptionIds);
            var quantities = prescriptionService.GetQuantitiesByIds(listPrescriptionIds);
            var unit = prescriptionService.GetUnit(listPrescriptionIds);
            var dosage = prescriptionService.GetDosage(listPrescriptionIds);
            var unitprice = prescriptionService.GetPrice(listPrescriptionIds);
            var total = prescriptionService.GetTotal(Convert.ToInt32(invoiceId));
            // Điền các trường với dữ liệu đơn
            //fields.SetField("InvoiceId", invoiceId);
            fields.SetField("CustomerName", patient.GetByID(ID_p.ToString()).FullName);
            fields.SetField("Date", medInvoice.JustGetDate(Convert.ToInt32(invoiceId)));
            fields.SetField("PhoneNum", patient.GetByID(ID_p.ToString()).PhoneNumber);

            // Điền các trường với dữ liệu từ danh sách
            for (int i = 0; i < medName.Count; i++)
            {
                fields.SetField($"MedName{i + 1}", medName[i]);
                fields.SetField($"Dosage{i + 1}", dosage[i]);
                fields.SetField($"Unit{i + 1}", unit[i]);
                fields.SetField($"quantity{i + 1}", quantities[i].ToString());
                fields.SetField($"price{i + 1}", unitprice[i].ToString());
                fields.SetField($"sum{i + 1}", ((decimal)(quantities[i] * unitprice[i])).ToString("N0"));
            }
            fields.SetField($"total", total);
        }
        private int SaveInvoice(List<Prescription> list)
        {
            int idInvoice = medInvoice.InsertNewInvoiceAndReturnID();

            List<int> listID = list.Select(item => item.ID).ToList();

            medInvoiceDetails.InsertInforForInvoice(idInvoice, listID);
            return idInvoice;
        }
        private List<Prescription> GetCheckedItem(DataGridView data)
        {
            return (from DataGridViewRow row in data.Rows.Cast<DataGridViewRow>()
                    where Convert.ToBoolean(row.Cells["colMedInvoice"].Value)
                    select prescriptionService.GetPrescriptionsID(row.Cells["colID"].Value.ToString())).ToList();
        }
        private void CreateAndPrintInvoicePdf(string invoiceId)
        {
            CreateInvoicePdf(invoiceId);

            string pdfPath = Path.GetFullPath($"Invoices\\MedicInvoice\\{invoiceId}.pdf");
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
        private void btnPrintMed_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsInvoiceCheckboxChecked())
                    throw new Exception("Không có dịch vụ nào được chọn");
                var list = GetCheckedItem(dgvMed);

                string invoiceId = SaveInvoice(list).ToString();

                CreateAndPrintInvoicePdf(invoiceId);
                btnQuit_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvMed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMed.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                // txtTotalAmount.Text = CalculateTotalAmount().ToString("N0");
            }
        }

        private void dgvMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMed.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell) && dgvMed.CurrentCell.IsInEditMode && dgvMed.IsCurrentCellDirty && dgvMed.Rows.Count > 0)
            {
                dgvMed.EndEdit();
            }
        }
    }
}
