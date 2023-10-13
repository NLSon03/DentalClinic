using bus;
using dal.Entities;
using System;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class frmMedicExamInfor : Form
    {
        //Mã bệnh nhân được truyền từ frm bệnh nhân
        public string _PatientID;

        private SubClinicalInformationService subClinicalInformationService = new SubClinicalInformationService();

        public frmMedicExamInfor()
        {
            InitializeComponent();
        }

        //Điền thông tin bệnh nhân vào form
        private void FillSubClinicalInformation(SubClinicalInformation SubCliInf)
        {
            //textbox Huyết áp
            txtBloodPressure.Text = SubCliInf.BloodPressure;
            //textbox Mạch
            txtPulseRate.Text = SubCliInf.PulseRate;
            //textbox đường huyết
            txtBloodSugarLevel.Text = SubCliInf.BloodSugarLevel;

            //radio button máu khó đông
            if (SubCliInf.BloodCoagulation == "TS")
                radBloodCoagulation_TS.Checked = true;
            else if (SubCliInf.BloodCoagulation == "TC")
                radBloodCoagulation_TS.Checked = true;
            else
                radBloodCoagulationNo.Checked = true;

            //radio button bệnh tim bẩm sinh
            if (SubCliInf.CongenitalHeartDisease == true)
                radCongenitalHeartDisease_Yes.Checked = true;

            //radio button thiểu năng trí tuệ
            if (SubCliInf.IntellectualDisability == true)
                radIntellectualDisability_Yes.Checked = true;

            //thông tin bảo hành
            txtWarrantyID.Text = SubCliInf.WarrantyID;
            txtWarrantyName.Text = SubCliInf.LaboName;

            //Thông tin khác
            txtOtherInfor.Text = SubCliInf.Other;
        }

        //Event Load Form
        private void frmMedicExamInfor_Load(object sender, EventArgs e)
        {
            try
            {
                var SubCliInf = subClinicalInformationService.GetById(_PatientID);
                if (SubCliInf != null)
                {
                    FillSubClinicalInformation(SubCliInf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnableUnitSubExInf()
        {
            //enable textbox
            txtBloodPressure.Enabled = true;
            txtBloodSugarLevel.Enabled = true;
            txtOtherInfor.Enabled = true;
            txtPulseRate.Enabled = true;
            txtWarrantyID.Enabled = true;
            txtWarrantyName.Enabled = true;
            //button add image
            btnAddImage.Enabled = true;
            //rad butt blood coagulation
            radBloodCoagulationNo.Enabled = true;
            radBloodCoagulation_TC.Enabled = true;
            radBloodCoagulation_TS.Enabled = true;
            //rad butt congenital heart disease
            radCongenitalHeartDisease_No.Enabled = true;
            radCongenitalHeartDisease_Yes.Enabled = true;
            //rad butt Intellectual Disability 
            radIntellectualDisability_No.Enabled = true;
            radIntellectualDisability_Yes.Enabled = true;
        }

        private void btnEditSubExamInfor_Click(object sender, EventArgs e)
        {
            EnableUnitSubExInf();
        }
    }
}
