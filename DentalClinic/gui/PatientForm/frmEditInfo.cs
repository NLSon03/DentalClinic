using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bus;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace gui.PatientForm
{
    public partial class frmEditInfo : Form
    {
        public TextBox txt1;
        public TextBox txt2;
        public TextBox txt3;
        public TextBox txt4;
        public DateTimePicker datetime1;
        public DateTimePicker datetime2;
        public RadioButton rb1;
        public RadioButton rb2;
        public CheckBox chk1;
        private readonly PatientInformationService patientService = new PatientInformationService();
        public frmEditInfo()
        {
            InitializeComponent();
            txt1 = txtPatientName;
            txt2 = txtPhoneNum;
            txt3 = txtAddress;
            txt4 = txtReason;
            datetime1 = dateTimeYOB;
            datetime2 = dateTime1stTime;
            rb1 = rbMale;
            rb2 = rbFemale;
            chk1 = cbFirstTime;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbFirstTime_CheckedChanged(object sender, EventArgs e)
        {
            if(cbFirstTime.Checked)
            {
                dateTime1stTime.Enabled = true;
            }
        }

        private void frmEditInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDoneEditing_Click(object sender, EventArgs e)
        {
            try
            {
                using (var model = new DentalModel())
                {
                    frmPatient frm = new frmPatient();
                    foreach (DataGridViewRow row in frm.dgv.Rows)
                    {
                        if (row.Selected)
                        {
                            PatientInformation info = patientService.GetByID(frm.dgv.Rows[row.Index].Cells[0].Value.ToString());
                            if (info != null)
                            {
                                info.FullName = txtPatientName.Text;
                                if (dateTimeYOB.Value == DateTime.Today && (DateTime.Now.Year - dateTimeYOB.Value.Year) <= 5)
                                {
                                    throw new Exception("Tuổi phải lớn hơn 5");
                                }
                                else
                                {
                                    info.YearOfBirth = DateTime.Parse(dateTimeYOB.Value.ToString("dd-MM-yyyy"));
                                }
                                if (rbMale.Checked)
                                {
                                    info.Gender = true;
                                }
                                else if (rbFemale.Checked)
                                {
                                    info.Gender = false;
                                }
                                info.PhoneNumber = txtPhoneNum.Text;
                                info.Address = txtAddress.Text;
                                if (cbFirstTime.Checked)
                                {
                                    info.FirstExaminationDate = DateTime.Parse(dateTime1stTime.Value.ToString("dd-MM-yyyy"));
                                }
                                else
                                {
                                    info.FirstExaminationDate = null;
                                }
                                info.ReasonForExamination = txtReason.Text;
                                patientService.EditInfo(info);
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                                throw new Exception("Lỗi cập nhật");
                        }
                    } 
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmEditInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPatient info = new frmPatient();
            info.ReloadPatientList();
        }
    }
}
