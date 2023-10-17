using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.StatisticForm.InventoryStatisticForm
{
    public partial class frmInventoryStatistic : Form
    {
        private readonly DentalToolService dentalToolService = new DentalToolService();
        private readonly DentalToolTransactionDetailsService dentalToolTransactionDetailsService = new DentalToolTransactionDetailsService();

        private void BindGridNhapXuat(List<DentalToolTransactionsDetail> dsnhapxuat)
        {
            dgvNhapXuat.Rows.Clear();
            decimal tongnhap = 0;
            decimal tongxuat = 0;
            foreach(var item in dsnhapxuat)
            {
                int index = dgvNhapXuat.Rows.Add();
                dgvNhapXuat.Rows[index].Cells[0].Value = index + 1;
                dgvNhapXuat.Rows[index].Cells[1].Value = (item.DentalToolTransaction.TransactionType == true) ? "Xuất" : "Nhập";
                dgvNhapXuat.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvNhapXuat.Rows[index].Cells[3].Value = item.Quantity;
                dgvNhapXuat.Rows[index].Cells[4].Value = item.UnitPrice;
                dgvNhapXuat.Rows[index].Cells[5].Value = item.TotalAmount;
                dgvNhapXuat.Rows[index].Cells[6].Value = item.DentalToolTransaction.TransactionDate;
                if (item.DentalToolTransaction.TransactionType == true)
                    tongxuat += (decimal)item.TotalAmount;
                else
                    tongnhap += (decimal)item.TotalAmount;
            }
            lbTongNhap.Text = tongnhap.ToString();
            lbTongXuat.Text = tongxuat.ToString();
            lbTongTien.Text = (tongxuat - tongnhap).ToString();
        }

        private void BindGridDungcu(List<DentalTool> dsdungcu)
        {
            dgvDungcu.Rows.Clear();
            foreach(var item in dsdungcu)
            {
                int index = dgvDungcu.Rows.Add();
                dgvDungcu.Rows[index].Cells[0].Value = index + 1;
                dgvDungcu.Rows[index].Cells[1].Value = item.ToolName;
                dgvDungcu.Rows[index].Cells[4].Value = item.Quantity;
            }
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
        public frmInventoryStatistic()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            if (selectedTab != null)
            {
                if (selectedTab == tabNhapxuat)
                {
                    var ds = dentalToolTransactionDetailsService.GetAll();
                    BindGridNhapXuat(ds);
                }
                if (selectedTab == tabDungcu)
                {
                    var ds = dentalToolService.GetAll();
                    BindGridDungcu(ds);
                }
            }
        }
        private void optThangfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm1.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
                UpdateMonthFormat(datNgayKT1);
            }
        }

        private void optQuyfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm1.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
                UpdateQuaterFormat(datNgayKT1);
            }
        }

        private void optNamfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm1.Checked)
            {
                UpdateYearFormat(datNgayBD1);
                UpdateYearFormat(datNgayKT1);
            }
        }

        private void datNgayBD1_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm1.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
            }
            else if (optThangfrm1.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
            }
            else if (optNamfrm1.Checked)
            {
                UpdateYearFormat(datNgayBD1);
            }
        }

        private void datNgayKT1_ValueChanged(object sender, EventArgs e)
        {
            if (optQuyfrm1.Checked)
            {
                UpdateQuaterFormat(datNgayKT1);
            }
            else if (optThangfrm1.Checked)
            {
                UpdateMonthFormat(datNgayKT1);
            }
            else if (optNamfrm1.Checked)
            {
                UpdateYearFormat(datNgayKT1);
            }
        }

        private void btnLocfrm1_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today;

            if (optNamfrm1.Checked)
            {
                date1 = GetStartDateForYear(datNgayBD1.Value);
                date2 = GetEndDateForYear(datNgayKT1.Value);
            }
            else if (optQuyfrm1.Checked)
            {
                date1 = GetStartDateForQuarter(datNgayBD1.Value);
                date2 = GetEndDateForQuarter(datNgayKT1.Value);
            }
            else if (optThangfrm1.Checked)
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

        private void btnLamMoifrm1_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatfrm1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvNhapXuat, saveFileDialog.FileName, "Thống kê nhập xuất");
            }
        }

        private void optNhap_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optXuat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optThangfrm2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optQuyfrm2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optNamfrm2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLocfrm2_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoifrm2_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatfrm2_Click(object sender, EventArgs e)
        {

        }

        private void optNhapfrm2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optXuatfrm2_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
