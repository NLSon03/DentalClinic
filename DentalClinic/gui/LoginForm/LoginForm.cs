using bus;
using dal.Entities;
using DentalClinic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.LoginForm
{
    public partial class LoginForm : Form
    {
        private readonly AccountService accountService = new AccountService();
        public LoginForm()
        {
            InitializeComponent();
        }
        private void OpenForm()
        {
            MainForm mf = new MainForm();
            mf.ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
                    {
                        throw new Exception("Vui lòng nhập đầy đủ thông tin");
                    }
                    string tk = txtLogin.Text;
                    string mk = txtPassword.Text;

                    Account account = accountService.findByID(tk, mk);

                    if (account != null)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        OpenForm();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void cbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPW.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }
    }
}
