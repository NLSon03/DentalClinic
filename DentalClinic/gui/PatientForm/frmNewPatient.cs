using bus;
using dal.Entities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmNewPatient : Form
    {
        private readonly PatientInformationService patient = new PatientInformationService();
        public frmNewPatient()
        {
            InitializeComponent();
        }

        private void frmNewPatient_Load(object sender, EventArgs e)
        {
            dateTime1stTime.Enabled = false;
            cbFirstTime.Enabled = false;
            rbFemale.Checked = true;
            txtPatientName.Focus();
            dateTimeYOB.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientName.Text == "" || txtPhoneNum.Text == "" || txtAddress.Text == "" ||
                txtReason.Text == "" || dateTimeYOB.Value == DateTime.Now)
                {
                    errorProvider1.SetError(txtPatientName, "!");
                    errorProvider2.SetError(txtPhoneNum, "!");
                    errorProvider3.SetError(txtAddress, "!");
                    errorProvider4.SetError(txtReason, "!");
                    errorProvider5.SetError(dateTimeYOB, "!");
                    throw new Exception("Phiếu thêm bệnh nhân trống");
                }
                if (txtPatientName.Text == "")
                {
                    errorProvider1.SetError(txtPatientName, "!");
                    throw new Exception("Tên người đến khám trống");
                }
                //if()
                if (txtPhoneNum.Text == "")
                {
                    errorProvider1.SetError(txtPhoneNum, "!");
                    throw new Exception("Số điện thoại của người đến khám trống");
                }
                if (txtAddress.Text == "")
                {
                    errorProvider1.SetError(txtAddress, "!");
                    throw new Exception("Địa chỉ người đến khám trống");
                }
                if (txtReason.Text == "")
                {
                    errorProvider1.SetError(txtReason, "!");
                    throw new Exception("Lý do đến khám trống");
                }
                if (dateTimeYOB.Value == DateTime.Today && (DateTime.Now.Year - dateTimeYOB.Value.Year) <= 5)
                {
                    errorProvider1.SetError(dateTimeYOB, "!");
                    throw new Exception("Tuổi phải lớn hơn 5");
                }
                bool check = false;
                //int  id,string name,bool gender, DateTime birthday,string phoneNo,string address,DateTime firstTime,string reason
                if (cbFirstTime.Checked == true)
                {
                    if (rbMale.Checked == true)
                    {
                        check = true;
                        var newPatient = new PatientInformation()
                        {
                            FullName = txtPatientName.Text,
                            Gender = check,
                            YearOfBirth = DateTime.Parse(dateTimeYOB.Value.ToString("dd-MM-yyyy")),
                            PhoneNumber = txtPhoneNum.Text,
                            Address = txtAddress.Text,
                            FirstExaminationDate = DateTime.Parse(dateTime1stTime.Value.ToString("dd-MM-yyyy")),
                            ReasonForExamination = txtReason.Text
                        };
                        patient.InsertNew(newPatient);
                    }
                    else if (rbMale.Checked == true)
                    {
                        var newPatient = new PatientInformation()
                        {
                            FullName = txtPatientName.Text,
                            Gender = check,
                            YearOfBirth = DateTime.Parse(dateTimeYOB.Value.ToString("dd-MM-yyyy")),
                            PhoneNumber = txtPhoneNum.Text,
                            Address = txtAddress.Text,
                            FirstExaminationDate = DateTime.Parse(dateTime1stTime.Value.ToString("dd-MM-yyyy")),
                            ReasonForExamination = txtReason.Text
                        };
                        patient.InsertNew(newPatient);
                    }
                }
                else if (cbFirstTime.Checked == false)
                {
                    if (rbMale.Checked == true)
                    {
                        check = true;
                        var newPatient = new PatientInformation()
                        {
                            FullName = txtPatientName.Text,
                            Gender = check,
                            YearOfBirth = DateTime.Parse(dateTimeYOB.Value.ToString("dd-MM-yyyy")),
                            PhoneNumber = txtPhoneNum.Text,
                            Address = txtAddress.Text,
                            FirstExaminationDate = null,
                            ReasonForExamination = txtReason.Text
                        };
                        patient.InsertNew(newPatient);
                    }
                    else if (rbMale.Checked == true)
                    {
                        var newPatient = new PatientInformation()
                        {
                            FullName = txtPatientName.Text,
                            Gender = check,
                            YearOfBirth = DateTime.Parse(dateTimeYOB.Value.ToString("dd-MM-yyyy")),
                            PhoneNumber = txtPhoneNum.Text,
                            Address = txtAddress.Text,
                            FirstExaminationDate = null,
                            ReasonForExamination = txtReason.Text
                        };
                        patient.InsertNew(newPatient);
                    }
                }
                DialogResult d = MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                if(d == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void cbFirstTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFirstTime.Checked)
            {
                dateTime1stTime.Enabled = true;
            }
        }

        private void frmNewPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.ReloadPatientList();
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
