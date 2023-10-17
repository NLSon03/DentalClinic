using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace gui.StatisticForm.RevenueStatisticForm
{
    public partial class frmRevenueStatistic : Form
    {
        public frmRevenueStatistic()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void BindGridTongDoanhThu() { }
        private void BindGridDieutri() { }
        private void BindGridThuoc() { }
        private void BindGridTienNhap() { }
        private void BindGridTienXuat() { }


        //FORM TONG DOANH THU
        private void frmRevenueStatistic_Load(object sender, EventArgs e)
        {

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

        }

        private void btnXuatfrmTong_Click(object sender, EventArgs e)
        {

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

        }

        private void btnXuatfrm2_Click(object sender, EventArgs e)
        {

        }


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

        }

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

        }

        private void btnXuatfrm4_Click(object sender, EventArgs e)
        {

        }

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

        }

        private void btnXuatfrm5_Click(object sender, EventArgs e)
        {

        }
    }
}
