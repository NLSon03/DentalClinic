using DentalClinic;
using gui.PatientForm.PrescriptionForm;
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

namespace gui.PatientForm
{
    public partial class frmPatient : Form
    {
        public frmPatient()
        {
            InitializeComponent();
        }
        private void ReopenMainForm()
        {
            MainForm main= new MainForm();
            main.ShowDialog();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReopenMainForm));
            thread.Start();
            this.Close();
        }

        private void frmPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                Thread t = new Thread(start: new ThreadStart(ReopenMainForm));
                t.Start();
                this.Close();
            }
            if(e.KeyCode == Keys.F1) 
            {

            }
        }
        private void OpenPrescriptionForm()
        {
            frmPrescription f = new frmPrescription();
            f.ShowDialog();
        }
        private void btnCreatingPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                //  foreach(DataGridViewRow r in dgvPatient.Rows)
                //  {
                //    if (dgvPatient.Rows[r.Index].Cells[8].Value == null)
                //   {
                OpenPrescriptionForm();
                   // }
                   // else
                  //  {
                  //      string s = string.Format("Bệnh nhân đã có đơn thuốc.\n Vui lòng chọn bệnh nhân khác");
                   //     throw new Exception(s);
                  //  }
                        
                //}
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK);
            }
        }

        private void frmPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReopenMainForm));
            thread.Start();
            this.Close();
        }
    }
}
