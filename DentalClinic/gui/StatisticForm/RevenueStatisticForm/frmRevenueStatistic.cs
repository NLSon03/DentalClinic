using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidecodeSharpFork;
using static System.Net.WebRequestMethods;
using Excel = Microsoft.Office.Interop.Excel;

namespace gui.StatisticForm.RevenueStatisticForm
{
    public partial class frmRevenueStatistic : Form
    {
        private readonly RevenueService revenueService = new RevenueService();
        private readonly ClinicalInformationService clinicalInformationService = new ClinicalInformationService();
        private readonly PrescriptionService prescriptionService = new PrescriptionService();
        private readonly DentalToolTransactionDetailsService dentalToolTransactionDetailsService = new DentalToolTransactionDetailsService();
        private readonly TreatmentService treatmentService = new TreatmentService();
        private readonly MedicineService medicineService = new MedicineService();
        public frmRevenueStatistic()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void BindGridTongDoanhThu(List<Revenue> dsdoanhthu)
        {
            dgvTongDoanhThu.Rows.Clear();
            decimal tongtien = 0;
            decimal tongthu = 0;
            decimal tongchi = 0;
            foreach(var item in dsdoanhthu)
            {
                int index = dgvTongDoanhThu.Rows.Add();
                dgvTongDoanhThu.Rows[index].Cells[0].Value = index + 1;
                dgvTongDoanhThu.Rows[index].Cells[1].Value = item.Ngay;
                dgvTongDoanhThu.Rows[index].Cells[2].Value = (long)item.TienThu;
                dgvTongDoanhThu.Rows[index].Cells[3].Value = (long)item.TienChi;
                dgvTongDoanhThu.Rows[index].Cells[4].Value = (long)item.Tong;
                tongtien += (decimal)item.Tong;
                tongthu += (decimal)item.TienThu;
                tongchi += (decimal)item.TienChi;
            }
            lbTongDT.Text = tongtien.ToString("0");
            lbTongThu.Text = tongthu.ToString("0");
            lbTongChi.Text = tongchi.ToString("0");
        }
        private void BindGridDieutri(List<ClinicalInformation> dsdieutri) 
        {
            dgvDieutri.Columns["clmNgayDieutri"].Visible = true;
            dgvDieutri.Rows.Clear();
            dgvDieutri.Columns["clmSoluong"].HeaderText = "Số lượng";
            decimal tongtien = 0;
            foreach(var item in dsdieutri)
            {
                int index = dgvDieutri.Rows.Add();
                dgvDieutri.Rows[index].Cells[0].Value = index+1;
                dgvDieutri.Rows[index].Cells[1].Value = clinicalInformationService.GetTreatmentInvoiceDate(item.ID).ToString();
                dgvDieutri.Rows[index].Cells[2].Value = clinicalInformationService.GetTreatmentName(item.ID);
                dgvDieutri.Rows[index].Cells[3].Value = clinicalInformationService.GetTreatmentMethodName(item.ID);
                dgvDieutri.Rows[index].Cells[4].Value = item.Quantity;
                dgvDieutri.Rows[index].Cells[5].Value = (long)item.Treatment.UnitPrice;
                dgvDieutri.Rows[index].Cells[6].Value = (long)item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTiendieutri.Text = tongtien.ToString("0");
            lbTongcadieutri.Text = (dgvDieutri.Rows.Count).ToString();

        }
        private void BindGridThuoc(List<Prescription> dsdonthuoc)
        {
            label20.Text = "Số đơn thuốc đã bán";
            dgvThuoc.Columns["clmNgayThuoc"].Visible = true;
            dgvThuoc.Columns["clmSoluongthuoc"].HeaderText = "Số lượng";
            dgvThuoc.Rows.Clear();
            decimal tongtien = 0;
            foreach(var item in  dsdonthuoc)
            {
                int index = dgvThuoc.Rows.Add();
                dgvThuoc.Rows[index].Cells[0].Value = index + 1;
                dgvThuoc.Rows[index].Cells[1].Value = prescriptionService.GetMedicineInvoiceDate(item.ID).ToString();
                dgvThuoc.Rows[index].Cells[2].Value = prescriptionService.GetMedicineName(item.ID);
                dgvThuoc.Rows[index].Cells[3].Value = item.Quantity;
                dgvThuoc.Rows[index].Cells[4].Value = (long)item.Medicine.UnitPrice;
                dgvThuoc.Rows[index].Cells[5].Value = (long)item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTongtienthuoc.Text = tongtien.ToString("0");
            lbTongthuoc.Text = dgvThuoc.Rows.Count.ToString();
        }
        private void BindGridTienNhap(List<DentalToolTransactionsDetail> dsnhap) 
        {
            dgvNhap.Rows.Clear();
            decimal tongtien = 0;
            foreach (var item in dsnhap)
            {
                int index = dgvNhap.Rows.Add();
                dgvNhap.Rows[index].Cells[0].Value = index + 1;
                dgvNhap.Rows[index].Cells[1].Value = item.DentalToolTransaction.TransactionDate.ToString();
                dgvNhap.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvNhap.Rows[index].Cells[3].Value = item.Quantity;
                dgvNhap.Rows[index].Cells[4].Value = (long)item.UnitPrice;
                dgvNhap.Rows[index].Cells[5].Value = (long)item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTienNhap.Text = tongtien.ToString("0");
            lbTongnhap.Text = dgvNhap.Rows.Count.ToString();
        }
        private void BindGridTienXuat(List<DentalToolTransactionsDetail> dsxuat) 
        {
            dgvXuat.Rows.Clear();
            decimal tongtien = 0;
            foreach(var item in dsxuat)
            {
                int index = dgvXuat.Rows.Add();
                dgvXuat.Rows[index].Cells[0].Value = index + 1;
                dgvXuat.Rows[index].Cells[1].Value = item.DentalToolTransaction.TransactionDate.ToString();
                dgvXuat.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvXuat.Rows[index].Cells[3].Value = item.Quantity;
                dgvXuat.Rows[index].Cells[4].Value = (long)item.UnitPrice;
                dgvXuat.Rows[index].Cells[5].Value = (long)item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTienXuat.Text = tongtien.ToString("0");
            lbTongXuat.Text = dgvXuat.Rows.Count.ToString();
        }

        private void BindGridTreatment(List<Treatment> ds, DateTime startDate, DateTime endDate)
        {
            dgvDieutri.Columns["clmNgayDieutri"].Visible = false;
            dgvDieutri.Rows.Clear();
            dgvDieutri.Columns["clmSoluong"].HeaderText = "Số ca thực hiện";
            decimal tongtien = 0;
            int tongsl = 0;

            foreach (var item in ds)
            {
                int i = dgvDieutri.Rows.Add();
                dgvDieutri.Rows[i].Cells[0].Value = i + 1;
                dgvDieutri.Rows[i].Cells[2].Value = item.TreatmentName.Name;
                dgvDieutri.Rows[i].Cells[3].Value = item.TreatmentMethodName.Name;

                int quantity = clinicalInformationService.GetTreatmentQuantity(item.ID, startDate, endDate);
                dgvDieutri.Rows[i].Cells[4].Value = quantity;

                dgvDieutri.Rows[i].Cells[5].Value = (long)item.UnitPrice;
                dgvDieutri.Rows[i].Cells[6].Value = (long)item.UnitPrice * quantity;

                tongtien += (decimal)item.UnitPrice * quantity;
                tongsl += quantity;
            }
            lbTiendieutri.Text = tongtien.ToString("0");
            lbTongcadieutri.Text = tongsl.ToString();
        }

        private void BindGridMedicine(List<Medicine> ds, DateTime date1, DateTime date2)
        {
            dgvThuoc.Columns["clmNgayThuoc"].Visible = false;
            dgvThuoc.Columns["clmSoluongthuoc"].HeaderText = "Số lượng đã bán";
            label20.Text = "Số lượng thuốc đã bán";
            dgvThuoc.Rows.Clear();
            decimal tongtien = 0;
            int slban = 0;
            foreach (var item in ds)
            {
                int index = dgvThuoc.Rows.Add();
                dgvThuoc.Rows[index].Cells[0].Value = index + 1;
                dgvThuoc.Rows[index].Cells[2].Value = item.MedicineName;
                int sl = prescriptionService.GetMedicineQuantity(item.MedicineID, date1, date2);
                dgvThuoc.Rows[index].Cells[3].Value = sl;
                dgvThuoc.Rows[index].Cells[4].Value = (long)item.UnitPrice;
                dgvThuoc.Rows[index].Cells[5].Value = (long)item.UnitPrice * sl;
                tongtien += (decimal)item.UnitPrice * sl;
                slban += sl;
            }
            lbTongtienthuoc.Text = tongtien.ToString("0");
            lbTongthuoc.Text = slban.ToString();
        }



        private void ToExcel(DataGridView dataGrid, string fileName, string tenexcel, string tencotngay, string noidung)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = tenexcel;
                Microsoft.Office.Interop.Excel.Range mergeRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dataGrid.Columns.Count]];
                mergeRange.Merge();
                worksheet.Cells[1, 1] = noidung;
                Microsoft.Office.Interop.Excel.Range cellRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                cellRange.Font.Bold = true;
                cellRange.Font.Color = Color.Red;
                cellRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // export header trong DataGridView
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    worksheet.Cells[3, i + 1] = dataGrid.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                    {
                        if (dataGrid.Columns[j].HeaderText.Unidecode().ToLower().Contains(tencotngay))
                        {
                            if (dataGrid.Rows[i].Cells[j].Value != null)
                                // Định dạng ngày thành MM/dd/yyyy
                                worksheet.Cells[i + 4, j + 1] = DateTime.Parse(dataGrid.Rows[i].Cells[j].Value.ToString()).ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            if (dataGrid.Rows[i].Cells[j].Value!= null)
                            // Giữ nguyên giá trị của các cột khác
                                worksheet.Cells[i + 4, j + 1] = dataGrid.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private DateTime GetStartDateForYear(DateTime inputDate)
        {
            return new DateTime(inputDate.Year, 1, 1);
        }

        private DateTime GetEndDateForYear(DateTime inputDate)
        {
            return new DateTime(inputDate.Year, 12, 31);
        }

        private DateTime GetStartDateForQuarter(DateTime inputDate)
        {
            int year = inputDate.Year;
            int quarter = (inputDate.Month - 1) / 3 + 1;
            switch (quarter)
            {
                case 1:
                    return new DateTime(year, 1, 1);
                case 2:
                    return new DateTime(year, 4, 1);
                case 3:
                    return new DateTime(year, 7, 1);
                case 4:
                    return new DateTime(year, 10, 1);
                default:
                    return DateTime.Today;
            }
        }


        private DateTime GetEndDateForQuarter(DateTime inputDate)
        {
            int year = inputDate.Year;
            int quarter = (inputDate.Month - 1) / 3 + 1;
            switch (quarter)
            {
                case 1:
                    return new DateTime(year, 3, 31);
                case 2:
                    return new DateTime(year, 6, 30);
                case 3:
                    return new DateTime(year, 9, 30);
                case 4:
                    return new DateTime(year, 12, 31);
                default:
                    return DateTime.Today;
            }
        }

        private DateTime GetStartDateForMonth(DateTime inputDate)
        {
            return new DateTime(inputDate.Year, inputDate.Month, 1);
        }

        private DateTime GetEndDateForMonth(DateTime inputDate)
        {
            return new DateTime(inputDate.Year, inputDate.Month, DateTime.DaysInMonth(inputDate.Year, inputDate.Month));
        }

        private void UpdateDateTimePickerFormat(DateTimePicker dateTimePicker, string customFormat)
        {
            dateTimePicker.CustomFormat = customFormat;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void UpdateQuaterFormat(DateTimePicker dateTimePicker)
        {
            int quarter = (dateTimePicker.Value.Month - 1) / 3 + 1;
            UpdateDateTimePickerFormat(dateTimePicker, $"'Quý' {quarter} yyyy");
        }

        private void UpdateMonthFormat(DateTimePicker dateTimePicker)
        {
            UpdateDateTimePickerFormat(dateTimePicker, "MM-yyyy");
        }

        private void UpdateYearFormat(DateTimePicker dateTimePicker)
        {
            UpdateDateTimePickerFormat(dateTimePicker, "'Năm' yyyy");
        }
        private void frmRevenueStatistic_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tabControl1_SelectedIndexChanged(sender, e);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            if (selectedTab != null)
            {
                if (selectedTab == tabTongDoanhThu)
                {
                    var ds = revenueService.GetAll();
                    BindGridTongDoanhThu(ds);
                }
                if (selectedTab == tabTongDieutri)
                {
                    var ds = clinicalInformationService.GetAll();
                    BindGridDieutri(ds);
                }
                if (selectedTab == tabTongDonthuoc)
                {
                    var ds = prescriptionService.GetAll();
                    BindGridThuoc(ds);
                }
                if (selectedTab == tabTongnhap)
                {
                    var ds = dentalToolTransactionDetailsService.GetAllByType(false);
                    BindGridTienNhap(ds);
                }
                if (selectedTab == tabTongxuat)
                {
                    var ds = dentalToolTransactionDetailsService.GetAllByType(true);
                    BindGridTienXuat(ds);
                }
            }


        }



        //FORM TONG DOANH THU
        private void datNgayBD1_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrmTong.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
            }
            else if (optThangfrmTong.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
            }
            else if (optNamfrmTong.Checked)
            {
                UpdateYearFormat(datNgayBD1);
            }
            FilterDatafrmTong();
        }

        private void datNgayKT1_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrmTong.Checked)
            {
                UpdateQuaterFormat(datNgayKT1);
            }
            else if (optThangfrmTong.Checked)
            {
                UpdateMonthFormat(datNgayKT1);
            }
            else if (optNamfrmTong.Checked)
            {
                UpdateYearFormat(datNgayKT1);
            }
            FilterDatafrmTong();
        }

        private void optQuyfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrmTong.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
                UpdateQuaterFormat(datNgayKT1);
                FilterDatafrmTong();
            }
        }

        private void optThangfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrmTong.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
                UpdateMonthFormat(datNgayKT1);
                FilterDatafrmTong();
            }
        }

        private void optNamfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrmTong.Checked)
            {
                UpdateYearFormat(datNgayBD1);
                UpdateYearFormat(datNgayKT1);
                FilterDatafrmTong();
            }
        }

        private void FilterDatafrmTong()
        {
            DateTime date1 = datNgayBD1.Value;
            DateTime date2 = datNgayKT1.Value;

            if (optNamfrmTong.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD1.Value);
                date2 = GetEndDateForYear(datNgayKT1.Value);
            }
            else if (optQuyfrmTong.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD1.Value);
                date2 = GetEndDateForQuarter(datNgayKT1.Value);
            }
            else if (optThangfrmTong.Checked)
            {
                date1 = GetStartDateForMonth(datNgayBD1.Value);
                date2 = GetEndDateForMonth(datNgayKT1.Value);
            }

            if (date1 > date2)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var dsdoanhthu = revenueService.GetAllBetweenDates(date1, date2);
                BindGridTongDoanhThu(dsdoanhthu);
            }
        }

        private void btnXuatfrmTong_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvTongDoanhThu, saveFileDialog.FileName, "Thống kê doanh thu","Ngay", "THỐNG KÊ DOANH THU");
            }
        }

        private void btnLamMoifrmTong_Click(object sender, EventArgs e)
        {
            optNamfrmTong.Checked = false;
            optThangfrmTong.Checked = false;
            optQuyfrmTong.Checked = false;
            datNgayBD1.Format = DateTimePickerFormat.Long;
            datNgayKT1.Format = DateTimePickerFormat.Long;
            datNgayKT1.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD1.Value = GetStartDateForMonth(DateTime.Today);
            var ds = revenueService.GetAll();
            BindGridTongDoanhThu(ds);
        }


        //FORM TONG DIEU TRI
        private void optThangfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm2.Checked)
            {
                UpdateMonthFormat(datNgayBD2);
                UpdateMonthFormat(datNgayKT2);
                FilterDatafrm2();
            }
        }

        private void optQuyfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm2.Checked)
            {
                UpdateQuaterFormat(datNgayBD2);
                UpdateQuaterFormat(datNgayKT2);
                FilterDatafrm2();
            }
        }

        private void optNamfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm2.Checked)
            {
                UpdateYearFormat(datNgayBD2);
                UpdateYearFormat(datNgayKT2);
                FilterDatafrm2();
            }
        }

        private void datNgayBD2_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm2.Checked)
            {
                UpdateQuaterFormat(datNgayBD2);
            }
            else if (optThangfrm2.Checked)
            {
                UpdateMonthFormat(datNgayBD2);
            }
            else if (optNamfrm2.Checked)
            {
                UpdateYearFormat(datNgayBD2);
            }
            FilterDatafrm2();
        }

        private void datNgayKT2_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm2.Checked)
                UpdateQuaterFormat(datNgayKT2);
            else if (optThangfrm2.Checked)
                UpdateMonthFormat(datNgayKT2);
            else if (optNamfrm2.Checked)
                UpdateYearFormat(datNgayKT2);
            FilterDatafrm2();
        }

        private void FilterDatafrm2() 
        {
            DateTime date1 = datNgayBD2.Value;
            DateTime date2 = datNgayKT2.Value;

            if (optNamfrm2.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD2.Value);
                date2 = GetEndDateForYear(datNgayKT2.Value);
            }
            else if (optQuyfrm2.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD2.Value);
                date2 = GetEndDateForQuarter(datNgayKT2.Value);
            }
            else if (optThangfrm2.Checked)
            {
                date1 = GetStartDateForMonth(datNgayBD2.Value);
                date2 = GetEndDateForMonth(datNgayKT2.Value);
            }

            if (date1 > date2)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbThongkeDieutri.Checked)
            {
                var ds = treatmentService.GetAll();
                BindGridTreatment(ds, date1, date2);
            }
            else
            {
                var dsdieutri = clinicalInformationService.GetAllBetweenDates(date1, date2);
                BindGridDieutri(dsdieutri);
            }
        }

        private void btnXuatfrm2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvDieutri, saveFileDialog.FileName, "Thống kê tiền điều trị","Ngay", "THỐNG KÊ DOANH THU ĐIỀU TRỊ");
            }
        }

        private void btnLamMoifrm2_Click(object sender, EventArgs e)
        {
            optNamfrm2.Checked = false;
            optThangfrm2.Checked = false;
            optQuyfrm2.Checked = false;
            datNgayBD2.Format = DateTimePickerFormat.Long;
            datNgayKT2.Format = DateTimePickerFormat.Long;
            datNgayKT2.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD2.Value = GetStartDateForMonth(DateTime.Today);
            cbThongkeDieutri.Checked = false;
            var ds = clinicalInformationService.GetAll();
            BindGridDieutri(ds);
        }
        private void cbThongke_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThongkeDieutri.Checked)
            {
                optNamfrm2.Checked = false;
                optThangfrm2.Checked = false;
                optQuyfrm2.Checked = false;
                var ds = treatmentService.GetAll();
                BindGridTreatment(ds, DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                optNamfrm3.Checked = false;
                optThangfrm3.Checked = false;
                optQuyfrm3.Checked = false;
                var ds = clinicalInformationService.GetAll();
                BindGridDieutri(ds);
            }
        }


        //FORM TONG DON THUOC
        private void optThangfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm3.Checked)
            {
                UpdateMonthFormat(datNgayBD3);
                UpdateMonthFormat(datNgayKT3);
                FilterDatafrm3();
            }
        }

        private void optQuyfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm3.Checked)
            {
                UpdateQuaterFormat(datNgayBD3);
                UpdateQuaterFormat(datNgayKT3);
                FilterDatafrm3();
            }
        }

        private void optNamfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm3.Checked)
            {
                UpdateYearFormat(datNgayBD3);
                UpdateYearFormat(datNgayKT3);
                FilterDatafrm3();
            }
        }

        private void datNgayBD3_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm3.Checked)
            {
                UpdateQuaterFormat(datNgayBD3);
            }
            else if (optNamfrm3.Checked)
            {
                UpdateYearFormat(datNgayBD3);
            }
            else if (optThangfrm3.Checked)
            {
                UpdateMonthFormat(datNgayBD3);
            }
            FilterDatafrm3();
        }

        private void datNgayKT3_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm3.Checked)
                UpdateQuaterFormat(datNgayKT3);
            else if (optNamfrm3.Checked)
                UpdateYearFormat(datNgayKT3);
            else if (optThangfrm3.Checked)
                UpdateMonthFormat(datNgayKT3);
            FilterDatafrm3();
        }

        private void FilterDatafrm3()
        {
            DateTime date1 = datNgayBD3.Value;
            DateTime date2 = datNgayKT3.Value;

            if (optNamfrm3.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD3.Value);
                date2 = GetEndDateForYear(datNgayKT3.Value);
            }
            else if (optQuyfrm3.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD3.Value);
                date2 = GetEndDateForQuarter(datNgayKT3.Value);
            }
            else if (optThangfrm3.Checked)
            {
                date1 = GetStartDateForMonth(datNgayBD3.Value);
                date2 = GetEndDateForMonth(datNgayKT3.Value);
            }
            if (date1 > date2)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbThongkeThuoc.Checked)
            {
                var ds = medicineService.GetAllMedicine();
                BindGridMedicine(ds, date1, date2);
            }
            else
            {
                var dsdonthuoc = prescriptionService.GetAllBetweenDates(date1, date2);
                BindGridThuoc(dsdonthuoc);
            }
        }


        private void btnXuatfrm3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvThuoc, saveFileDialog.FileName, "Thống kê tiền thuốc", "Ngay", "THỐNG KÊ DOANH THU THUỐC");
            }
        }

        private void btnLamMoifrm3_Click(object sender, EventArgs e)
        {
            optNamfrm3.Checked = false;
            optThangfrm3.Checked = false;
            optQuyfrm3.Checked = false;
            datNgayBD3.Format = DateTimePickerFormat.Long;
            datNgayKT3.Format = DateTimePickerFormat.Long;
            datNgayKT3.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD3.Value = GetStartDateForMonth(DateTime.Today);

            cbThongkeThuoc.Checked = false;
            var ds = prescriptionService.GetAll();
            BindGridThuoc(ds);
        }

        private void cbThongkeThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThongkeThuoc.Checked)
            {
                optNamfrm3.Checked = false;
                optThangfrm3.Checked = false;
                optQuyfrm3.Checked = false;
                var ds = medicineService.GetAllMedicine();
                BindGridMedicine(ds, DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                optNamfrm3.Checked = false;
                optThangfrm3.Checked = false;
                optQuyfrm3.Checked = false;
                var ds = prescriptionService.GetAll();
                BindGridThuoc(ds);
            }
        }


        //FORM TONG XUAT
        private void optThangfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm4.Checked)
            {
                UpdateMonthFormat(datNgayBD4);
                UpdateMonthFormat(datNgayKT4);
                FilterDatafrm4();
            }
        }

        private void optQuyfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm4.Checked)
            {
                UpdateQuaterFormat(datNgayBD4);
                UpdateQuaterFormat(datNgayKT4);
                FilterDatafrm4();
            }
        }

        private void optNamfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm4.Checked)
            {
                UpdateYearFormat(datNgayBD4);
                UpdateYearFormat(datNgayKT4);
                FilterDatafrm4();
            }
        }

        private void datNgayBD4_ValueChanged(object sender, EventArgs e)
        {
            if (optThangfrm4.Checked)
                UpdateMonthFormat(datNgayBD4);
            else if (optQuyfrm4.Checked)
                UpdateQuaterFormat(datNgayBD4);
            else if (optNamfrm4.Checked)
                UpdateYearFormat(datNgayBD4);
            FilterDatafrm4();
        }

        private void datNgayKT4_ValueChanged(object sender, EventArgs e)
        {
            if (optThangfrm4.Checked)
                UpdateMonthFormat(datNgayKT4);
            else if (optQuyfrm4.Checked)
                UpdateQuaterFormat(datNgayKT4);
            else if (optNamfrm4.Checked)
                UpdateYearFormat(datNgayKT4);
            FilterDatafrm4();
        }

        private void FilterDatafrm4()
        {
            DateTime date1 = datNgayBD4.Value;
            DateTime date2 = datNgayKT4.Value;

            if (optNamfrm4.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD4.Value);
                date2 = GetEndDateForYear(datNgayKT4.Value);
            }
            else if (optQuyfrm4.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD4.Value);
                date2 = GetEndDateForQuarter(datNgayKT4.Value);
            }
            else if (optThangfrm4.Checked)
            {
                date1 = GetStartDateForMonth(datNgayBD4.Value);
                date2 = GetEndDateForMonth(datNgayKT4.Value);
            }

            if (date1 > date2)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var dsxuat = dentalToolTransactionDetailsService.GetAllBetweenDates(date1, date2, true);
                BindGridTienXuat(dsxuat);
            }
        }

        private void btnXuatfrm4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvXuat, saveFileDialog.FileName, "Thống kê tiền xuất vật liệu","Ngay", "THỐNG KÊ DOANH THU XUẤT HÀNG");
            }
        }

        private void btnLammoifrm4_Click(object sender, EventArgs e)
        {
            optNamfrm4.Checked = false;
            optThangfrm4.Checked = false;
            optQuyfrm4.Checked = false;
            datNgayBD4.Format = DateTimePickerFormat.Long;
            datNgayKT4.Format = DateTimePickerFormat.Long;
            datNgayKT4.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD4.Value = GetStartDateForMonth(DateTime.Today);

            var ds = dentalToolTransactionDetailsService.GetAllByType(true);
            BindGridTienXuat(ds);
        }


        //FORM TONG NHAP
        private void optThangfrm5_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm5.Checked)
            {
                UpdateMonthFormat(datNgayBD5);
                UpdateMonthFormat(datNgayKT5);
                FilterDatafrm5();
            }
        }

        private void optQuyfrm5_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm5.Checked)
            {
                UpdateQuaterFormat(datNgayBD5);
                UpdateQuaterFormat(datNgayKT5);
                FilterDatafrm5();
            }
        }

        private void optNamfrm5_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm5.Checked)
            {
                UpdateYearFormat(datNgayBD5);
                UpdateYearFormat(datNgayKT5);
                FilterDatafrm5();
            }
        }

        private void datNgayBD5_ValueChanged(object sender, EventArgs e)
        {
            if (optNamfrm5.Checked)
                UpdateYearFormat(datNgayBD5);
            else if (optThangfrm5.Checked)
                UpdateMonthFormat(datNgayBD5);
            else if (optQuyfrm5.Checked)
                UpdateQuaterFormat(datNgayBD5);
            FilterDatafrm5();
        }

        private void datNgayKT5_ValueChanged(object sender, EventArgs e)
        {
            if (optNamfrm5.Checked)
                UpdateYearFormat(datNgayKT5);
            else if (optThangfrm5.Checked)
                UpdateMonthFormat(datNgayKT5);
            else if (optQuyfrm5.Checked)
                UpdateQuaterFormat(datNgayKT5);
            FilterDatafrm5();
        }

        private void FilterDatafrm5()
        {
            DateTime date1 = datNgayBD5.Value;
            DateTime date2 = datNgayKT5.Value;

            if (optNamfrm5.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD5.Value);
                date2 = GetEndDateForYear(datNgayKT5.Value);
            }
            else if (optQuyfrm5.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD5.Value);
                date2 = GetEndDateForQuarter(datNgayKT5.Value);
            }
            else if (optThangfrm5.Checked)
            {
                date1 = GetStartDateForMonth(datNgayBD5.Value);
                date2 = GetEndDateForMonth(datNgayKT5.Value);
            }

            if (date1 > date2)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var dsnhap = dentalToolTransactionDetailsService.GetAllBetweenDates(date1, date2, false);
                BindGridTienNhap(dsnhap);
            }
        }

        private void btnXuatfrm5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvNhap, saveFileDialog.FileName, "Thống kê tiền nhập vật liệu","Ngay","THỐNG KÊ TIỀN NHẬP HÀNG");
            }
        }

        private void btnLamMoifrm5_Click(object sender, EventArgs e)
        {
            optNamfrm5.Checked = false;
            optThangfrm5.Checked = false;
            optQuyfrm5.Checked = false;
            datNgayBD5.Format = DateTimePickerFormat.Long;
            datNgayKT5.Format = DateTimePickerFormat.Long;
            datNgayKT5.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD5.Value = GetStartDateForMonth(DateTime.Today);

            var ds = dentalToolTransactionDetailsService.GetAllByType(false);
            BindGridTienNhap(ds);
        }


    }
}
