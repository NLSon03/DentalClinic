using bus;
using dal.Entities;
using DentalClinic;
using System;
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

        private void ResetData()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            lblInfo.Text = "";
            prgLogin.Value = 0;
            txtLogin.Text = ""; 
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                prgLogin.Value = 0;
                lblInfo.Text = "Đang khởi tạo.";
                string acc = txtLogin.Text;
                string password = txtPassword.Text;

                if (await ValidateLoginAsync(acc, password))
                {
                    lblInfo.Text = "Kết nối thành công. Đang vào";
                    await Task.Delay(1000);
                    prgLogin.Value = 100;
                    OpenForm();
                }
                else
                {
                    prgLogin.Value = 0;
                    lblInfo.Text = "Đăng nhập thất bại";
                }
            }
            catch (Exception ex)
            {
                lblLogin.Text = "Lỗi kết nối";
            }
        }

        private async Task<bool> ValidateLoginAsync(string acc, string password)
        {
            lblInfo.Text = "Đang kết nối cơ sở dữ liệu.";
            prgLogin.Value = 50;
            await Task.Delay(500);
            if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(password))
            {
                lblLogin.Text="Vui lòng nhập đầy đủ thông tin";
                return false;
            }

            Account account = accountService.findByID(acc, password);

            if (account != null)
            {
                lblLogin.Text = "Đăng nhập thành công";
                return true;
            }
            else
            {
                lblLogin.Text = "Sai tên đăng nhập hoặc mật khẩu.";
                return false;
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblLogin.Text = "";
            lblInfo.Text = "";
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            lblLogin.Text = "";
            lblInfo.Text = "";
        }
    }
}
