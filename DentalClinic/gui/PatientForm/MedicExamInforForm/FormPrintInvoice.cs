using bus;
using dal.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormPrintInvoice : Form
    {
        private Thread viewerThread;

        public string _PatientID;
        private static string template_Path = "F:\\AllProject\\CSharpProject\\DoAn\\DentalClinic\\gui\\Resources\\TreatmentInvoiceTemplate.pdf";


        private readonly ClinicalInformationService clinicalInformationService = new ClinicalInformationService();
        private readonly PatientInformationService patientInformationService = new PatientInformationService();
        private readonly TreatmentInvoiceDetailsService treatmentInvoiceDetailsService = new TreatmentInvoiceDetailsService();

        public FormPrintInvoice()
        {
            InitializeComponent();
        }

        private static string CheckNull(object param)
        {
            return (param == null || param.ToString() == "null" || param.ToString() == "") ? "" : param.ToString();
        }

        private void SetDataForLabelName()
        {
            int id = patientInformationService.GetByID(_PatientID).PatientID;
            string name = patientInformationService.GetByID(_PatientID).FullName;
            lblPatient.Text = id + " | " + name;
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

            int index = 1;

            foreach (var item in list)
            {
                if (!isHasInvoice(item.ID.ToString()) && item.Treatment != null)
                {
                    string id = item.ID.ToString();
                    string diag = CheckNull(item.Diagnosi.Diagnosis);
                    string treatment = CheckNull(item.Treatment.TreatmentName.Name);
                    string treatmentMethod = CheckNull(item.Treatment.TreatmentMethodName.Name);
                    string unit = CheckNull(item.Treatment.Unit);
                    string quantity = CheckNull(item.Quantity);
                    string unitPrice = CheckNull(item.Treatment.UnitPrice);
                    string totalAmount = CheckNull(item.TotalAmount);
                    string date = CheckNull(item.Diagnosi.ExaminationTime);
                    dgvClinicalInfor.Rows.Add(index, id, diag, treatment, treatmentMethod, unit, quantity, unitPrice, totalAmount, date, false);

                    index++;
                }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrintInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private bool isInvoiceCheckboxChecked()
        {
            foreach (DataGridViewRow row in dgvClinicalInfor.Rows)
                if (Convert.ToBoolean(row.Cells["ColumnInvoice"].Value))
                    return true;
            return false;
        }

        private List<ClinicalInformation> GetCheckedItem(DataGridView data)
        {
            var list = new List<ClinicalInformation>();
            foreach (DataGridViewRow row in data.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ColumnInvoice"].Value))
                {
                    var item = clinicalInformationService.GetByClinicID(row.Cells["ColumnIDClinicInf"].Value.ToString());
                    list.Add(item);
                }
            }
            return list;
        }

        public void FillPDF(string templatePath, string outputPath, List<ClinicalInformation> list)
        {
            // Mở file PDF mẫu
            PdfReader pdfReader = new PdfReader(templatePath);

            // Tạo một PdfStamper để chỉnh sửa file PDF
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(outputPath, FileMode.Create));

            // Lấy form fields từ file PDF
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            // Điền thông tin vào form fields
            pdfFormFields.SetField("FieldName1", "Value1");
            pdfFormFields.SetField("FieldName2", "Value2");
            // ...

            // Đóng PdfStamper và PdfReader
            pdfStamper.Close();
            pdfReader.Close();
        }

        //private void CreateInvoicePDF(string filePath, List<ClinicalInformation> items)
        //{
        //    Document document = new Document();
        //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
        //    document.Open();

        //    document.Add(new Paragraph("HÓA ĐƠN THANH TOÁN"));
        //    document.Add(new Paragraph("Mã hóa đơn: " + "{Mã hóa đơn}"));
        //    document.Add(new Paragraph("Ngày lập đơn: " + "{Ngày lập đơn}"));
        //    document.Add(new Paragraph("Họ tên bệnh nhân: " + "{Họ tên bệnh nhân}"));
        //    document.Add(new Paragraph("CCCD (số căn cước công dân): " + "{CCCD}"));
        //    document.Add(new Paragraph("Ngày sinh: " + "{Ngày sinh}"));
        //    document.Add(new Paragraph("Giới tính: " + "{Giới tính}"));
        //    document.Add(new Paragraph("Địa chỉ: " + "{Địa chỉ}"));

        //    PdfPTable table = new PdfPTable(6);
        //    table.AddCell("STT");
        //    table.AddCell("Dịch vụ điều trị");
        //    table.AddCell("Đơn vị tính");
        //    table.AddCell("Đơn giá");
        //    table.AddCell("Số lượng");
        //    table.AddCell("Tổng tiền");


        //    int index = 1;
        //    foreach (var item in items)
        //    {
        //        table.AddCell(index.ToString());
        //        table.AddCell(item.Treatment.TreatmentName.Name + " " + item.Treatment.TreatmentMethodName.Name);
        //        table.AddCell(item.Treatment.Unit);
        //        table.AddCell(item.Treatment.UnitPrice.ToString());
        //        table.AddCell(item.Quantity.ToString());
        //        table.AddCell(item.TotalAmount.ToString());
        //    }

        //    document.Add(table);

        //    document.Close();
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isInvoiceCheckboxChecked())
                    throw new Exception("Không có dịch vụ nào được chọn");

                var list = GetCheckedItem(dgvClinicalInfor);
                Thread thread = new Thread(() =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "PDF Files|*.pdf",
                        Title = "Chọn vị trí lưu file PDF"
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Tạo file PDF tại đường dẫn đã chọn
                        FillPDF(template_Path,filePath, list); 

                        // Mở cửa sổ xem trước file PDF trong một luồng mới
                        viewerThread = new Thread(() =>
                        {
                            Process.Start(filePath);
                            Application.Run();
                        });
                        viewerThread.SetApartmentState(ApartmentState.STA);
                        viewerThread.Start();
                    }
                });
                thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA
                thread.Start();
                thread.Join();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
