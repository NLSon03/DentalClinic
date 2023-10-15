using DentalClinic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void OpenForm()
        {
            MainForm mf = new MainForm ();
            mf.ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DentalClinicManagement;Integrated Security=True");
            try
            {
                if (txtLogin.Text == "" || txtPassword.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                }
                string tk = txtLogin.Text;
                string mk = txtPassword.Text;
                string sql = "Select * from Account where AccountName='" + tk + "' and Password = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if(dta.Read() == true ) 
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void cbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPW.Checked == true)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
                txtPassword.PasswordChar = '*';
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}
