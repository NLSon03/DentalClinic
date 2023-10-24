using gui.LoginForm;
using gui.DentalForm;
using gui.PatientForm;
using System;
using System.Threading;
using System.Windows.Forms;
using gui.StatisticForm;
namespace DentalClinic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenPatientForm()
        {
            frmPatient frmpatient = new frmPatient();
            frmpatient.ShowDialog();
        }

        private void btnPatientManager_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(OpenPatientForm));
            thread.Start();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn sẽ được trở về màn hình đăng nhập", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                LoginForm lf = new LoginForm();
                lf.ShowDialog();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            frmStatistic frmStatistic = new frmStatistic();
            frmStatistic.ShowDialog();
        }

        private void btnDentalMaterial_Click(object sender, EventArgs e)
        {
            frmDentalToolMain fr = new frmDentalToolMain();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
    }
}
