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
        private PatientInformationService patientInformationService = new PatientInformationService();

        public frmMedicExamInfor()
        {
            InitializeComponent();
        }

        //Load Form
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

        //Điền thông tin bệnh nhân vào form
        private void FillSubClinicalInformation(SubClinicalInformation SubCliInf)
        {
            grbSubExamInfor.Text = SubCliInf.PatientID + "|"+ patientInformationService.GetByID(_PatientID).FullName;
            lblBloodPressure.Text = SubCliInf.BloodPressure;
            lblPulseRate.Text = SubCliInf.PulseRate;
            lblBloodSugarLevel.Text = SubCliInf.BloodSugarLevel;
            lblBloodCoagulation.Text = SubCliInf.BloodCoagulation;
            lblCongenitalHeartDisease.Text = (bool)(SubCliInf.CongenitalHeartDisease) ? "Có" : "Không";
            lblIntellectualDisability.Text = (bool)SubCliInf.IntellectualDisability ? "Có" : "Không";
            lblWarrantyID.Text = SubCliInf.WarrantyID;
            lblLaboName.Text = SubCliInf.LaboName;
            lblOther.Text = SubCliInf.Other;
        }

        /*private void EnableUnitSubExInf()
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
        }*/

        /*private void btnEditSubExamInfor_Click(object sender, EventArgs e)
        {
            EnableUnitSubExInf();
        }*/
    }
}
