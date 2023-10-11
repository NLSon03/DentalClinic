using gui.PatientForm;
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
    }
}
