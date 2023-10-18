﻿using bus;
using dal.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormEditSubClinicInf : Form
    {
        public frmMedicExamInfor PreForm;

        public string _PatientID;

        private PatientInformationService patientInformationService = new PatientInformationService();

        private SubClinicalInformationService subClinicInforService = new SubClinicalInformationService();

        private SubClinicalInformation DefaultInfor = new SubClinicalInformation();

        private byte[] xrayData;

        public FormEditSubClinicInf()
        {
            InitializeComponent();
        }
        //Nếu các dữ liệu là null thì gán các dữ liệu trong textbox = ""
        private static string ChangeNull(object param)
        {
            return (param == null || param.ToString() == "null" || param.ToString() == "") ? "" : param.ToString();
        }


        //Truyền dữ liệu đã có sẵn/mặc định của bệnh nhân vào form
        private void AddDataWhenFormLoad(SubClinicalInformation Patient)
        {
            //Lable ID_Name bệnh nhân
            string PatientID = Patient.PatientID.ToString();
            string PatientName = Patient.PatientInformation.FullName.ToString();
            lblPatient.Text = ChangeNull(PatientID) + " | " + ChangeNull(PatientName);
            //Các textbox huyết áp, mạch, đường huyết
            txtBloodPressure.Text = ChangeNull(Patient.BloodPressure);
            txtPulseRate.Text = ChangeNull(Patient.PulseRate);
            txtBloodSugarLevel.Text = ChangeNull(Patient.BloodSugarLevel);
            //Radio button máu khó đông
            if (Patient.BloodCoagulation == "TS")
                radTS.Checked = true;
            else if (Patient.BloodCoagulation == "TC")
                radTC.Checked = true;
            else
                radBC_No.Checked = true;
            //Radio button thiểu năng trí tuệ
            _ = Patient.IntellectualDisability.ToString() == "1" ? radID_Yes.Checked = true : radID_No.Checked = true;
            //Radio button tim bẩm sinh
            _ = Patient.CongenitalHeartDisease.ToString() == "1" ? radCHD_Yes.Checked = true : radCHD_No.Checked = true;
            //Thông tin bảo hành
            txtWarrantyID.Text = ChangeNull(Patient.WarrantyID);
            txtLaboName.Text = ChangeNull(Patient.LaboName);
            //Khác
            txtOther.Text = ChangeNull(Patient.Other);
            //Xray Film
            if(xrayData!=null)
            using (var ms = new MemoryStream(xrayData))
            {
                picXray.Image = Image.FromStream(ms);
            }
        }
        //Event Load Form
        private void FormEditSubClinicInf_Load(object sender, EventArgs e)
        {
            try
            {
                SubClinicalInformation Patient = subClinicInforService.GetById(_PatientID);
                if (Patient.XRayFilm == null)
                    xrayData = null;
                else
                    xrayData = Patient.XRayFilm;
                //Nếu chưa có thông tin cận lâm sàng thì tạo mới thông tin cận lâm sàng
                if (Patient == null)
                {
                    subClinicInforService.Insert(_PatientID);
                    FormEditSubClinicInf_Load(sender, e);
                }
                else
                {
                    DefaultInfor = Patient;
                    AddDataWhenFormLoad(Patient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Event add hình ảnh
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;",
                        Title = "Chọn ảnh chụp X-Ray"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                        xrayData = bytes;
                        MemoryStream ms = new MemoryStream(bytes);
                        picXray.Image = Image.FromStream(ms);
                    }
                });
                thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA
                thread.Start();
                thread.Join(); // Wait for the thread to end
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditSubClinicInf_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private SubClinicalInformation EditInfor()
        {
            string bloodPressure = txtBloodPressure.Text;
            string pulseRate = txtPulseRate.Text;
            string bloodSugarLevel = txtBloodSugarLevel.Text;

            string bloodCoagulation;
            if (radBC_No.Checked == true)
                bloodCoagulation = "No";
            else
                bloodCoagulation = radTC.Checked == true ? "TC" : "TS";

            bool congenitalHeartDisease = radCHD_Yes.Checked == true ? true : false;

            bool intellectualDisability = radID_Yes.Checked == true ? true : false;

            byte[] imgData = xrayData;

            string warrantyID = txtWarrantyID.Text;
            string laboName = txtLaboName.Text;
            string other = txtOther.Text;
            SubClinicalInformation subClinicalInformation
                = new SubClinicalInformation()
                {
                    PatientID = Convert.ToInt32(_PatientID),
                    BloodPressure = bloodPressure,
                    PulseRate = pulseRate,
                    BloodSugarLevel = bloodSugarLevel,
                    BloodCoagulation = bloodCoagulation,
                    CongenitalHeartDisease = congenitalHeartDisease,
                    IntellectualDisability = intellectualDisability,
                    XRayFilm = imgData,
                    WarrantyID = warrantyID,
                    LaboName = laboName,
                    Other = other
                };
            return subClinicalInformation;
        }

        private bool isChangeValue(SubClinicalInformation defaultInfor, SubClinicalInformation newInfor)
        {
            if (defaultInfor.BloodPressure != newInfor.BloodPressure)
                return true;
            if (defaultInfor.PulseRate != newInfor.PulseRate)
                return true;
            if (defaultInfor.BloodSugarLevel != newInfor.BloodSugarLevel)
                return true;
            if (defaultInfor.BloodCoagulation != newInfor.BloodCoagulation)
                return true;
            if (defaultInfor.CongenitalHeartDisease != newInfor.CongenitalHeartDisease)
                return true;
            if (defaultInfor.IntellectualDisability != newInfor.IntellectualDisability)
                return true;
            if (defaultInfor.XRayFilm != newInfor.XRayFilm)
                return true;
            if (defaultInfor.WarrantyID != newInfor.WarrantyID)
                return true;
            if (defaultInfor.LaboName != newInfor.LaboName)
                return true;
            if (defaultInfor.Other != newInfor.Other)
                return true;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckValidData.ValidInput(txtBloodPressure.Text, txtPulseRate.Text, txtBloodSugarLevel.Text);

                SubClinicalInformation NewInfor = EditInfor();
                if (!isChangeValue(DefaultInfor, NewInfor))
                    throw new Exception("Thông tin không có thay đổi");

                subClinicInforService.Update(NewInfor);
                FormEditSubClinicInf_Load(sender, e);
                PreForm.frmMedicExamInfor_Load(sender, e);
                throw new Exception("Cập nhật thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            picXray.Image = null;
            xrayData = null;
        }
    }
}
