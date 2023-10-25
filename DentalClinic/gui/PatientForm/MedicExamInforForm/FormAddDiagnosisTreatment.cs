using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormAddDiagnosisTreatment : Form
    {
        public frmMedicExamInfor MainForm;
        public string _PatientID;
        public bool isEdit = false;
        public int? _ClinicInf = null;

        private PatientInformationService patientInformationService = new PatientInformationService();
        private ClinicalInformationService clinicalInformationService = new ClinicalInformationService();
        private TreatmentService treatmentService = new TreatmentService();
        private TreatmentNameService treatmentNameService = new TreatmentNameService();
        private TreatmentMethodNameService treatmentMethodNameService = new TreatmentMethodNameService();
        private DiagnosisService diagnosisService = new DiagnosisService();
        public FormAddDiagnosisTreatment()
        {
            InitializeComponent();
        }

        private void FillComboBoxTreatment(List<TreatmentName> ListTreatment)
        {
            ListTreatment.Insert(0, new TreatmentName());
            cmbTreatment.DataSource = ListTreatment;
            cmbTreatment.DisplayMember = "Name";
            cmbTreatment.ValueMember = "ID";
        }

        private void RefreshData()
        {
            txtUnit.Text = null;
            txtUnitPrice.Text = null;
            txtTotalAmount.Text = null;
        }

        private void FillComboBoxTreatmentMethod(List<Treatment> list)
        {
            var listName = treatmentMethodNameService.GetAll();
            var newList = list.Select(treatment => new
            {
                ID = treatment.TreatmentMethod,
                Name = listName.FirstOrDefault(x => x.ID == treatment.TreatmentMethod)?.Name
            }).ToList();
            cmbTreatmentMethod.DataSource = newList;
            cmbTreatmentMethod.ValueMember = "ID";
            cmbTreatmentMethod.DisplayMember = "Name";
        }

        private void FillDataWhenLoadUpdate()
        {
            var clinicInfor = clinicalInformationService.GetByClinicID(_ClinicInf.ToString());
            //Combobox điều trị
            var ListTreatment = treatmentNameService.GetAll();
            FillComboBoxTreatment(ListTreatment);
            string treatment = clinicInfor.Treatment.TreatmentName.Name;
            cmbTreatment.Text = treatment;
            //Combobox phương pháp điều trị
            cmbTreatmentMethod.Text = clinicInfor.Treatment.TreatmentMethodName.Name;
            //Các textbox khác
            txtDiagnosis.Text = clinicInfor.Diagnosi.Diagnosis == null ? "" : clinicInfor.Diagnosi.Diagnosis;
            numQuantity.Value = clinicInfor.Quantity < 1 ? 1 : clinicInfor.Quantity;
        }

        private void FormAddDiagnosisTreatment_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    var ListTreatment = treatmentNameService.GetAll();
                    FillComboBoxTreatment(ListTreatment);
                }
                else
                {
                    FillDataWhenLoadUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatment.SelectedIndex != -1 && cmbTreatment.SelectedIndex != 0)
            {
                var list = treatmentService.GetByTreatmentNameID(cmbTreatment.SelectedValue.ToString());
                FillComboBoxTreatmentMethod(list);
            }
            else
            {
                cmbTreatmentMethod.DataSource = null;
                RefreshData();
            }
        }

        private void cmbTreatmentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatmentMethod.SelectedIndex != -1)
            {
                numQuantity.Enabled = true;
                var item = treatmentService.GetByTreatmentNameID_And_TreatmentMethodID(cmbTreatment.SelectedValue.ToString(), cmbTreatmentMethod.SelectedValue.ToString());
                if (item != null)
                {
                    txtUnit.Text = item.Unit;
                    txtUnitPrice.Text = item.UnitPrice.ToString();
                    txtTotalAmount.Text = (item.UnitPrice * Convert.ToInt32(numQuantity.Value)).ToString();
                }
            }
            else
            {
                numQuantity.Enabled = false;
                numQuantity.Value = 1;
                RefreshData();
            }

        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (numQuantity.Enabled == true)
            {
                var item = treatmentService.GetByTreatmentNameID_And_TreatmentMethodID(cmbTreatment.SelectedValue.ToString(), cmbTreatmentMethod.SelectedValue.ToString());
                txtTotalAmount.Text = (item.UnitPrice * Convert.ToInt32(numQuantity.Value)).ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddDiagnosisTreatment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private bool isNullTreatment()
        {
            return (string.IsNullOrEmpty(cmbTreatment.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNullTreatment())
                    throw new Exception("Không được để trống Điều trị.");

                int patientID = Convert.ToInt32(_PatientID);
                string diag = txtDiagnosis.Text ?? "";
                int diagID = diagnosisService.AddDiagnosisAndReturnID(diag);

                bool isTreatmentEmpty = string.IsNullOrEmpty(cmbTreatment.Text);
                int? treatID = isTreatmentEmpty ? (int?)null : treatmentService.GetID(cmbTreatment.SelectedValue.ToString(), cmbTreatmentMethod.SelectedValue.ToString());
                int quantity = isTreatmentEmpty ? 0 : Convert.ToInt32(numQuantity.Value);
                decimal? totalAmount = isTreatmentEmpty ? (decimal?)null : Convert.ToDecimal(txtTotalAmount.Text);

                if (!isEdit)
                {
                    clinicalInformationService.Insert(patientID, diagID, treatID, quantity, totalAmount);
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var clinicInfor = clinicalInformationService.GetByClinicID(_ClinicInf.ToString());
                    Diagnosi diagn = new Diagnosi { ID = clinicInfor.Diagnosi.ID, Diagnosis = diag };
                    diagnosisService.Update(diagn);

                    var updateClinicInf = new ClinicalInformation
                    {
                        ID = clinicInfor.ID,
                        Patient_ID = clinicInfor.Patient_ID,
                        Diagnosis_ID = diagID,
                        Treatment_ID = treatID,
                        Quantity = quantity,
                        TotalAmount = totalAmount
                    };

                    clinicalInformationService.Update(updateClinicInf);
                    MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MainForm.frmMedicExamInfor_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
