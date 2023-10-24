using bus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmAnnoucement : Form
    {
        public Button btn1;
        public frmAnnoucement()
        {
            InitializeComponent();
            btn1 = btnEdit;
        }
        private readonly PatientInformationService patientService = new PatientInformationService();
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatient patient = new frmPatient();
                foreach (DataGridViewRow row in patient.dgv.Rows)
                {
                    if (row.Selected)
                    {
                        patientService.DeletePatient(patient.dgv.Rows[row.Index].Cells[0].Value.ToString());
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }
        public bool isClicked= false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditInfo editInfo = new frmEditInfo();
            isClicked = true;
            editInfo.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
