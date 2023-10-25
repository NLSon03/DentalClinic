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
using UnidecodeSharpFork;


namespace gui.StatisticForm.InventoryStatisticForm
{
    public partial class frmInventoryStatistic : Form
    {
        private readonly InventoryService inventoryService = new InventoryService();
        private readonly DentalToolTransactionDetailsService dentalToolTransactionDetailsService = new DentalToolTransactionDetailsService();
        List<DentalToolTransactionsDetail> dsnhapxuat;
        List<Inventory> dsvatlieu;

        private void BindGridNhapXuat(List<DentalToolTransactionsDetail> dsnhapxuat)
        {
            dgvHoaDon.Rows.Clear();
            decimal tongnhap = 0;
            decimal tongxuat = 0;
            foreach(var item in dsnhapxuat)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = index + 1;
                dgvHoaDon.Rows[index].Cells[1].Value = (item.DentalToolTransaction.TransactionType == true) ? "Xuất" : "Nhập";
                dgvHoaDon.Rows[index].Cells[2].Value = item.DentalTool.ToolName.ToString();
                dgvHoaDon.Rows[index].Cells[3].Value = item.Quantity;
                dgvHoaDon.Rows[index].Cells[4].Value = (long)item.UnitPrice;
                dgvHoaDon.Rows[index].Cells[5].Value = (long)item.TotalAmount;
                dgvHoaDon.Rows[index].Cells[6].Value = item.DentalToolTransaction.TransactionDate;
                if (item.DentalToolTransaction.TransactionType == true)
                    tongxuat += (decimal)item.TotalAmount;
                else
                    tongnhap += (decimal)item.TotalAmount;
            }
            lbTongNhap.Text = tongnhap.ToString("0");
            lbTongXuat.Text = tongxuat.ToString("0");
        }

        private void BindGridVatLieu(List<Inventory> dsvatlieu)
        {
            dgvVatLieu.Rows.Clear();
            foreach(var item in dsvatlieu)
            {
                int index = dgvVatLieu.Rows.Add();
                dgvVatLieu.Rows[index].Cells[0].Value = index + 1;
                dgvVatLieu.Rows[index].Cells[1].Value = item.ToolName;
                dgvVatLieu.Rows[index].Cells[2].Value = item.QuantityPurchased;
                dgvVatLieu.Rows[index].Cells[3].Value = item.QuantitySold;
                dgvVatLieu.Rows[index].Cells[4].Value = item.ConsumedQuantity;
                dgvVatLieu.Rows[index].Cells[5].Value = item.RemainingQuantity;
                dgvVatLieu.Rows[index].Cells[6].Value = item.LastUpdateDate;
            }
            lbVatlieunhap.Text = dsvatlieu.Count(x => x.QuantityPurchased != 0).ToString();
            lbVatlieuxuat.Text = dsvatlieu.Count(x=> x.QuantitySold != 0).ToString();
        }

        private void ToExcel(DataGridView dataGrid, string fileName, string tenexcel,string tencotngay)
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
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGrid.Columns[i].HeaderText;
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
                            worksheet.Cells[i + 2, j + 1] = DateTime.Parse(dataGrid.Rows[i].Cells[j].Value.ToString()).ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            // Giữ nguyên giá trị của các cột khác
                            worksheet.Cells[i + 2, j + 1] = dataGrid.Rows[i].Cells[j].Value.ToString();
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
                    return inputDate;
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
                    return inputDate;
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
                    dsnhapxuat = dentalToolTransactionDetailsService.GetAll();
                    BindGridNhapXuat(dsnhapxuat);
                }
                if (selectedTab == tabDungcu)
                {
                    dsvatlieu = inventoryService.GetAll();
                    BindGridVatLieu(dsvatlieu);
                }
            }
        }
        private void optThangfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm1.Checked)
            {
                UpdateMonthFormat(datNgayBD1);
                UpdateMonthFormat(datNgayKT1);
                btnLocfrm1_Click(sender, e);
            }
        }

        private void optQuyfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optQuyfrm1.Checked)
            {
                UpdateQuaterFormat(datNgayBD1);
                UpdateQuaterFormat(datNgayKT1);
                btnLocfrm1_Click(sender, e);
            }
        }

        private void optNamfrm1_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamfrm1.Checked)
            {
                UpdateYearFormat(datNgayBD1);
                UpdateYearFormat(datNgayKT1);
                btnLocfrm1_Click(sender, e);
            }
        }

        private DateTime GetStartDateForm1()
        {
            if (optNamfrm1.Checked)
            {
                return GetStartDateForYear(datNgayBD1.Value);
            }
            else if (optQuyfrm1.Checked)
            {
                return GetStartDateForQuarter(datNgayBD1.Value);
            }
            else if (optThangfrm1.Checked)
            {
                return GetStartDateForMonth(datNgayBD1.Value);
            }
            else
            {
                return datNgayBD1.Value;
            }
        }
        private DateTime GetEndDateForm1()
        {
            if (optNamfrm1.Checked)
            {
                return GetEndDateForYear(datNgayKT1.Value);
            }
            else if (optQuyfrm1.Checked)
            {
                return GetEndDateForQuarter(datNgayKT1.Value);
            }
            else if (optThangfrm1.Checked)
            {
                return GetEndDateForMonth(datNgayKT1.Value);
            }
            else
            {
                return datNgayKT1.Value;
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
            FilterData();
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
            FilterData();
        }

        private void FilterData()
        {
            DateTime startDate = GetStartDateForm1();
            DateTime endDate = GetEndDateForm1();

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (optXuat.Checked)
            {
                dsnhapxuat = dentalToolTransactionDetailsService.GetAllBetweenDates(startDate, endDate, true);
            }
            else if (optNhap.Checked)
            {
                dsnhapxuat = dentalToolTransactionDetailsService.GetAllBetweenDates(startDate, endDate, false);
            }
            else
            {
                dsnhapxuat = dentalToolTransactionDetailsService.GetAllBetweenDates(startDate, endDate);
            }

            BindGridNhapXuat(dsnhapxuat);
        }

        private void btnLocfrm1_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnLamMoifrm1_Click(object sender, EventArgs e)
        {
            optNamfrm1.Checked = false;
            optThangfrm1.Checked = false;
            optQuyfrm1.Checked = false;
            optXuat.Checked = false;
            optNhap.Checked = false;
            datNgayBD1.Format = DateTimePickerFormat.Long;
            datNgayKT1.Format = DateTimePickerFormat.Long;
            datNgayKT1.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD1.Value = GetStartDateForMonth(DateTime.Today);
            dsnhapxuat = dentalToolTransactionDetailsService.GetAll();
            BindGridNhapXuat(dsnhapxuat);
        }

        private void btnXuatfrm1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvHoaDon, saveFileDialog.FileName, "Thống kê nhập xuất","ngay");
            }
        }

        private void optNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm1.Checked || optQuyfrm1.Checked || optNamfrm1.Checked)
                btnLocfrm1_Click(sender, e);
            else
            if (optNhap.Checked)
            {
                var ds = dsnhapxuat;
                dsnhapxuat = dsnhapxuat.Where(p => p.DentalToolTransaction.TransactionType == false).ToList();
                BindGridNhapXuat(dsnhapxuat);
                dsnhapxuat = ds;
            }
        }

        private void optXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm1.Checked || optQuyfrm1.Checked || optNamfrm1.Checked)
                btnLocfrm1_Click(sender, e);
            else
            if (optXuat.Checked)
            {
                var ds = dsnhapxuat;
                dsnhapxuat = dsnhapxuat.Where(p => p.DentalToolTransaction.TransactionType == true).ToList();
                BindGridNhapXuat(dsnhapxuat);
                dsnhapxuat = ds;
            }
        }

        //FORM 2
        private DateTime GetStartDateForm2()
        {
            if (optNamfrm2.Checked)
            {
                return GetStartDateForYear(datNgayBD2.Value);
            }
            else if (optQuyfrm2.Checked)
            {
                return GetStartDateForQuarter(datNgayBD2.Value);
            }
            else if (optThangfrm2.Checked)
            {
                return GetStartDateForMonth(datNgayBD2.Value);
            }
            else
            {
                return datNgayBD2.Value;
            }
        }
        private DateTime GetEndDateForm2()
        {
            if (optNamfrm2.Checked)
            {
                return GetEndDateForYear(datNgayKT2.Value);
            }
            else if (optQuyfrm2.Checked)
            {
                return GetEndDateForQuarter(datNgayKT2.Value);
            }
            else if (optThangfrm2.Checked)
            {
                return GetEndDateForMonth(datNgayKT2.Value);
            }
            else
            {
                return datNgayKT2.Value;
            }
        }


        private void FilterDatafrm2()
        {
            DateTime startDate = GetStartDateForm2();
            DateTime endDate = GetEndDateForm2();

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (optXuatfrm2.Checked)
            {
                dsvatlieu = inventoryService.GetAllBetweenDates(startDate, endDate);
                dsvatlieu = dsvatlieu.Where(p => p.QuantityPurchased == 0 && p.QuantitySold != 0).ToList();
                BindGridVatLieu(dsvatlieu);
            }
            else if (optNhapfrm2.Checked)
            {
                dsvatlieu = inventoryService.GetAllBetweenDates(startDate, endDate);
                dsvatlieu = dsvatlieu.Where(p => p.QuantityPurchased != 0 && p.QuantitySold == 0).ToList();
                BindGridVatLieu(dsvatlieu);
            }
            else
            {
                dsvatlieu = inventoryService.GetAllBetweenDates(startDate, endDate);
                BindGridVatLieu(dsvatlieu);
            }
        }

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
            {
                UpdateQuaterFormat(datNgayKT2);
            }
            else if (optThangfrm2.Checked)
            {
                UpdateMonthFormat(datNgayKT2);
            }
            else if (optNamfrm2.Checked)
            {
                UpdateYearFormat(datNgayKT2);
            }
            FilterDatafrm2();
        }

        private void btnLamMoifrm2_Click(object sender, EventArgs e)
        {
            optNamfrm2.Checked = false;
            optThangfrm2.Checked = false;
            optQuyfrm2.Checked = false;
            optNhapfrm2.Checked = false;
            optXuatfrm2.Checked = false;
            datNgayBD2.Format = DateTimePickerFormat.Long;
            datNgayKT2.Format = DateTimePickerFormat.Long;
            datNgayKT2.Value = GetEndDateForMonth(DateTime.Today);
            datNgayBD2.Value = GetStartDateForMonth(DateTime.Today);
            dsvatlieu = inventoryService.GetAll();
            BindGridVatLieu(dsvatlieu);
        }

        private void btnXuatfrm2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvVatLieu, saveFileDialog.FileName, "Thống kê dụng cụ", "lan update cuoi");
            }
        }

        private void optNhapfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm2.Checked || optQuyfrm2.Checked || optNamfrm2.Checked)
                FilterDatafrm2();
            else if (optNhapfrm2.Checked)
            {
                var ds = dsvatlieu;
                dsvatlieu = dsvatlieu.Where(p => p.QuantitySold == 0 && p.QuantityPurchased != 0).ToList();
                BindGridVatLieu(dsvatlieu);
                dsvatlieu = ds;
            }
        }

        private void optXuatfrm2_CheckedChanged(object sender, EventArgs e)
        {
            if (optThangfrm2.Checked || optQuyfrm2.Checked || optNamfrm2.Checked)
                FilterDatafrm2();
            else if (optXuatfrm2.Checked)
            {
                var ds = dsvatlieu;
                dsvatlieu = dsvatlieu.Where(p => p.QuantityPurchased == 0 && p.QuantitySold != 0).ToList();
                BindGridVatLieu(dsvatlieu);
                dsvatlieu = ds;
            }
        }

        private void frmInventoryStatistic_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tabControl1_SelectedIndexChanged(sender, e);
        }


    }
}
