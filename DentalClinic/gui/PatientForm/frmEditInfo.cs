using bus;
using dal.Entities;
using System;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmEditInfo : Form
    {
        public string PatientID;
        private PatientInformation patient;
        public frmPatient MainForm;
        private readonly PatientInformationService patientService = new PatientInformationService();
        public frmEditInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private static string ChangeNull(object param)
        {
            if (param == null)
            {
                return "";
            }

            string paramString = param.ToString();
            return (paramString == "null" || paramString == "") ? "" : paramString;
        }

        private void AddData(PatientInformation patient)
        {
            txtPatientName.Text = ChangeNull(patient.FullName);
            if (patient.Gender)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbMale.Checked = false;
                rbFemale.Checked = true;
            }
            txtPhoneNum.Text = ChangeNull(patient.PhoneNumber);
            txtAddress.Text = ChangeNull(patient.Address);
            txtReason.Text = ChangeNull(patient.ReasonForExamination);
            dateTime1stTime.Text = patient.FirstExaminationDate.ToString();
            dateTimeYOB.Text = patient.YearOfBirth.ToString();
        }

        private void frmEditInfo_Load(object sender, EventArgs e)
        {
            try
            {
                patient = patientService.GetByID(PatientID);
                AddData(patient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoneEditing_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường dữ liệu
                if (string.IsNullOrEmpty(txtPatientName.Text)) throw new Exception("Tên người đến khám trống");
                if (string.IsNullOrEmpty(txtPhoneNum.Text)) throw new Exception("Số điện thoại của người đến khám trống");
                if (string.IsNullOrEmpty(txtAddress.Text)) throw new Exception("Địa chỉ người đến khám trống");
                if (string.IsNullOrEmpty(txtReason.Text)) throw new Exception("Lý do đến khám trống");
                if (dateTimeYOB.Value == DateTime.Today && (DateTime.Now.Year - dateTimeYOB.Value.Year) <= 5) throw new Exception("Tuổi phải lớn hơn 5");
                var newPatient = new PatientInformation()
                {
                    PatientID = Convert.ToInt32(PatientID),
                    FullName = txtPatientName.Text,
                    Gender = rbMale.Checked,
                    YearOfBirth = dateTimeYOB.Value,
                    PhoneNumber = txtPhoneNum.Text,
                    Address = txtAddress.Text,
                    FirstExaminationDate = dateTime1stTime.Value,
                    ReasonForExamination = txtReason.Text
                };

                patientService.UpdatePatientInformation(newPatient);
                MessageBox.Show("Chỉnh sửa thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MainForm.frmPatient_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmEditInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
