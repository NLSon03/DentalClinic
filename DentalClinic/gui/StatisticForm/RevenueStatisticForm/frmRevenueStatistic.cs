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
                dgvTongDoanhThu.Rows[index].Cells[2].Value = item.TienThu;
                dgvTongDoanhThu.Rows[index].Cells[3].Value = item.TienChi;
                dgvTongDoanhThu.Rows[index].Cells[4].Value = item.Tong;
                tongtien += (decimal)item.Tong;
                tongthu += (decimal)item.TienThu;
                tongchi += (decimal)item.TienChi;
            }
            lbTongDT.Text = tongtien.ToString();
            lbTongThu.Text = tongthu.ToString();
            lbTongChi.Text = tongchi.ToString();
        }
        private void BindGridDieutri(List<ClinicalInformation> dsdieutri) 
        {
            dgvDieutri.Rows.Clear();
            decimal tongtien = 0;
            foreach(var item in dsdieutri)
            {
                int index = dgvDieutri.Rows.Add();
                dgvDieutri.Rows[index].Cells[0].Value = index+1;
                dgvDieutri.Rows[index].Cells[1].Value = clinicalInformationService.GetTreatmentInvoiceDate(item.ID).ToString();
                dgvDieutri.Rows[index].Cells[2].Value = clinicalInformationService.GetTreatmentName(item.ID);
                dgvDieutri.Rows[index].Cells[3].Value = clinicalInformationService.GetTreatmentMethodName(item.ID);
                dgvDieutri.Rows[index].Cells[4].Value = item.Quantity;
                dgvDieutri.Rows[index].Cells[5].Value = item.Treatment.UnitPrice;
                dgvDieutri.Rows[index].Cells[6].Value = item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTiendieutri.Text = tongtien.ToString();
            lbTongcadieutri.Text = (dgvDieutri.Rows.Count).ToString();

        }
        private void BindGridThuoc(List<Prescription> dsdonthuoc)
        {
            dgvTienThuoc.Rows.Clear();
            decimal tongtien = 0;
            foreach(var item in  dsdonthuoc)
            {
                int index = dgvTienThuoc.Rows.Add();
                dgvTienThuoc.Rows[index].Cells[0].Value = index + 1;
                dgvTienThuoc.Rows[index].Cells[1].Value = prescriptionService.GetMedicineInvoiceDate(item.ID).ToString();
                dgvTienThuoc.Rows[index].Cells[2].Value = prescriptionService.GetMedicineName(item.ID);
                dgvTienThuoc.Rows[index].Cells[3].Value = item.Quantity;
                dgvTienThuoc.Rows[index].Cells[4].Value = item.Medicine.UnitPrice.ToString();
                dgvTienThuoc.Rows[index].Cells[5].Value = item.TotalAmount.ToString();
                tongtien += (decimal)item.TotalAmount;
            }
            lbTongtienthuoc.Text = tongtien.ToString();
            lbTongthuoc.Text = dgvTienThuoc.Rows.Count.ToString();
        }
        private void BindGridTienNhap(List<DentalToolTransactionsDetail> dsnhap) 
        {
            dgvTienNhap.Rows.Clear();
            decimal tongtien = 0;
            foreach (var item in dsnhap)
            {
                int index = dgvTienNhap.Rows.Add();
                dgvTienNhap.Rows[index].Cells[0].Value = index + 1;
                dgvTienNhap.Rows[index].Cells[1].Value = item.DentalToolTransaction.TransactionDate.ToString();
                dgvTienNhap.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvTienNhap.Rows[index].Cells[3].Value = item.Quantity;
                dgvTienNhap.Rows[index].Cells[4].Value = item.UnitPrice;
                dgvTienNhap.Rows[index].Cells[5].Value = item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTienNhap.Text = tongtien.ToString();
            lbTongnhap.Text = dgvTienNhap.Rows.Count.ToString();
        }
        private void BindGridTienXuat(List<DentalToolTransactionsDetail> dsxuat) 
        {
            dgvTienXuat.Rows.Clear();
            decimal tongtien = 0;
            foreach(var item in dsxuat)
            {
                int index = dgvTienXuat.Rows.Add();
                dgvTienXuat.Rows[index].Cells[0].Value = index + 1;
                dgvTienXuat.Rows[index].Cells[1].Value = item.DentalToolTransaction.TransactionDate.ToString();
                dgvTienXuat.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvTienXuat.Rows[index].Cells[3].Value = item.Quantity;
                dgvTienXuat.Rows[index].Cells[4].Value = item.UnitPrice;
                dgvTienXuat.Rows[index].Cells[5].Value = item.TotalAmount;
                tongtien += (decimal)item.TotalAmount;
            }
            lbTienXuat.Text = tongtien.ToString();
            lbTongXuat.Text = dgvTienXuat.Rows.Count.ToString();
        }

        private void ToExcel(DataGridView dataGrid, string fileName, string tenexcel)
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

                // export header trong DataGridView
                for (int i = 0; i < dgvDieutri.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvDieutri.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGrid.Rows[i].Cells[j].Value.ToString();
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
                    break;
                case 2:
                    return new DateTime(year, 4, 1);
                    break;
                case 3:
                    return new DateTime(year, 7, 1);
                    break;
                case 4:
                    return new DateTime(year, 10, 1);
                    break;
                default:
                    return DateTime.Today;
                    break;
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
                    break;
                case 2:
                    return new DateTime(year, 6, 30);
                    break;
                case 3:
                    return new DateTime(year, 9, 30);
                    break;
                case 4:
                    return new DateTime(year, 12, 31);
                    break;
                default:
                    return DateTime.Today;
                    break;
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
        }

        private void optQuyfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrmTong.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
                UpdateQuaterFormat(datNgayKT1);
            }
        }

        private void optThangfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrmTong.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
                UpdateMonthFormat(datNgayKT1);
            }
        }

        private void optNamfrmTong_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrmTong.Checked)
            {
                UpdateYearFormat(datNgayBD1);
                UpdateYearFormat(datNgayKT1);
            }
        }

        private void btnLocfrmTong_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

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
                ToExcel(dgvTongDoanhThu, saveFileDialog.FileName, "Thống kê doanh thu");
            }
        }

        private void btnLamMoifrmTong_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void optQuyfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm2.Checked)
            {
                UpdateQuaterFormat(datNgayBD2);
                UpdateQuaterFormat(datNgayKT2);
            }
        }

        private void optNamfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm2.Checked)
            {
                UpdateYearFormat(datNgayBD2);
                UpdateYearFormat(datNgayKT2);
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
        }

        private void datNgayKT2_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm2.Checked)
                UpdateQuaterFormat(datNgayKT2);
            else if (optThangfrm2.Checked)
                UpdateMonthFormat(datNgayKT2);
            else if (optNamfrm2.Checked)
                UpdateYearFormat(datNgayKT2);
        }

        private void btnLocfrm2_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

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
                ToExcel(dgvDieutri, saveFileDialog.FileName,"Thống kê tiền điều trị");
            }
        }

        private void btnLamMoifrm2_Click(object sender, EventArgs e)
        {
            var ds = clinicalInformationService.GetAll();
            BindGridDieutri(ds);
        }
    
        //FORM TONG DON THUOC
        private void optThangfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm3.Checked)
            {
                UpdateMonthFormat(datNgayBD3);
                UpdateMonthFormat(datNgayKT3);
            }
        }

        private void optQuyfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm3.Checked)
            {
                UpdateQuaterFormat(datNgayBD3);
                UpdateQuaterFormat(datNgayKT3);
            }

        }

        private void optNamfrm3_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm3.Checked)
            {
                UpdateYearFormat(datNgayBD3);
                UpdateYearFormat(datNgayKT3);
            }
        }

        private void btnLocfrm3_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

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
            else
            {
                var dsdonthuoc = prescriptionService.GetAllBetweenDates(date1, date2);
                BindGridThuoc(dsdonthuoc);
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
        }

        private void datNgayKT3_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm3.Checked)
                UpdateQuaterFormat(datNgayKT3);
            else if (optNamfrm3.Checked)
                UpdateYearFormat(datNgayKT3);
            else if (optThangfrm3.Checked)
                UpdateMonthFormat(datNgayKT3);
        }

        private void btnXuatfrm3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvTienThuoc, saveFileDialog.FileName, "Thống kê tiền thuốc");
            }
        }
        private void btnLamMoifrm3_Click(object sender, EventArgs e)
        {
            var ds = prescriptionService.GetAll();
            BindGridThuoc(ds);
        }

        //FORM TONG XUAT
        private void optThangfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm4.Checked)
            {
                UpdateMonthFormat(datNgayBD4);
                UpdateMonthFormat(datNgayKT4);
            }
        }

        private void optQuyfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm4.Checked)
            {
                UpdateQuaterFormat(datNgayKT4);
                UpdateQuaterFormat(datNgayBD4);
            }
        }

        private void optNamfrm4_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm4.Checked)
            {
                UpdateYearFormat(datNgayBD4);
                UpdateYearFormat(datNgayKT4);
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
        }

        private void datNgayKT4_ValueChanged(object sender, EventArgs e)
        {
            if (optThangfrm4.Checked)
                UpdateMonthFormat(datNgayKT4);
            else if (optQuyfrm4.Checked)
                UpdateQuaterFormat(datNgayKT4);
            else if (optNamfrm4.Checked)
                UpdateYearFormat(datNgayKT4);
        }

        private void btnLocfrm4_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

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
                ToExcel(dgvTienXuat, saveFileDialog.FileName, "Thống kê tiền xuất vật liệu");
            }
        }

        private void btnLammoifrm4_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void optQuyfrm5_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm5.Checked)
            {
                UpdateQuaterFormat(datNgayBD5);
                UpdateQuaterFormat(datNgayKT5);
            }
        }

        private void optNamfrm5_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm5.Checked)
            {
                UpdateYearFormat(datNgayBD5);
                UpdateYearFormat(datNgayKT5);
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
        }

        private void datNgayKT5_ValueChanged(object sender, EventArgs e)
        {
            if (optNamfrm5.Checked)
                UpdateYearFormat(datNgayKT5);
            else if (optThangfrm5.Checked)
                UpdateMonthFormat(datNgayKT5);
            else if (optQuyfrm5.Checked)
                UpdateQuaterFormat(datNgayKT5);
        }

        private void btnLocfrm5_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

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
                ToExcel(dgvTienNhap, saveFileDialog.FileName, "Thống kê tiền nhập vật liệu");
            }
        }

        private void btnLamMoifrm5_Click(object sender, EventArgs e)
        {
            var ds = dentalToolTransactionDetailsService.GetAllByType(false);
            BindGridTienNhap(ds);
        }
    }
}
