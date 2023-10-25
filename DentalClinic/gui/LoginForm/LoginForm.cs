using bus;
using dal.Entities;
using DentalClinic;
using System;
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

        private void ResetData()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            cbShowPW.Checked = false;
        }

        private void OpenForm()
        {
            ResetData();
            this.Hide();
            MainForm mf = new MainForm();
            mf.ShowDialog();
            this.Show();
        }

        private bool ValidateLogin(string acc, string password)
        {
            if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }

            Account account = accountService.findByID(acc, password);

            if (account != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                return true;
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string acc = txtLogin.Text;
                string password = txtPassword.Text;

                if (ValidateLogin(acc, password))
                {
                    OpenForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
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

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
