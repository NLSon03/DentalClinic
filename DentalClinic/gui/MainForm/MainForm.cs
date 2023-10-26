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
            this.Hide();
            frmPatient frmpatient = new frmPatient();
            frmpatient.ShowDialog();
            this.Show();
        }

        private void btnPatientManager_Click(object sender, EventArgs e)
        {
            OpenPatientForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn sẽ được trở về màn hình đăng nhập", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStatistic form = new frmStatistic();
            form.ShowDialog();
            this.Show();
        }

        private void btnDentalMaterial_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDentalToolMain fr = new frmDentalToolMain();
            fr.ShowDialog();
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
