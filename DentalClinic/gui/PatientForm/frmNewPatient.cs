using bus;
using dal.Entities;
using System;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmNewPatient : Form
    {
        public frmPatient mainForm;
        private readonly PatientInformationService patient = new PatientInformationService();
        public frmNewPatient()
        {
            InitializeComponent();
        }

        private void frmNewPatient_Load(object sender, EventArgs e)
        {
            rbFemale.Checked = true;
            txtPatientName.Focus();
            dateTimeYOB.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường dữ liệu
                if (string.IsNullOrEmpty(txtPatientName.Text)) throw new Exception("Tên người đến khám trống");
                if (string.IsNullOrEmpty(txtPhoneNum.Text)) throw new Exception("Số điện thoại của người đến khám trống");
                if (string.IsNullOrEmpty(txtAddress.Text)) throw new Exception("Địa chỉ người đến khám trống");
                if (string.IsNullOrEmpty(txtReason.Text)) throw new Exception("Lý do đến khám trống");
                if (dateTimeYOB.Value == DateTime.Today && (DateTime.Now.Year - dateTimeYOB.Value.Year) <= 5) throw new Exception("Tuổi phải lớn hơn 5");

                // Tạo thông tin bệnh nhân mới
                var newPatient = new PatientInformation()
                {
                    FullName = txtPatientName.Text,
                    Gender = rbMale.Checked,
                    YearOfBirth = dateTimeYOB.Value,
                    PhoneNumber = txtPhoneNum.Text,
                    Address = txtAddress.Text,
                    FirstExaminationDate = dateTime1stTime.Value,
                    ReasonForExamination = txtReason.Text
                };

                // Thêm bệnh nhân mới
                patient.InsertNew(newPatient);

                // Hiển thị thông báo thành công và đóng form
                DialogResult d = MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                mainForm.frmPatient_Load(sender, e);
                if (d == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void frmNewPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
