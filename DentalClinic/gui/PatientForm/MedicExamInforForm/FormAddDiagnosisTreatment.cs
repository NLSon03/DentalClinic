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

        private TreatmentInvoiceDetailsService treatmentInvoiceDetailsService = new TreatmentInvoiceDetailsService();
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

            //label tên bệnh nhân
            lblPatient.Text = _PatientID + "|" + patientInformationService.GetByID(_PatientID).FullName;
            //Combobox điều trị
            var ListTreatment = treatmentNameService.GetAll();
            FillComboBoxTreatment(ListTreatment);

            bool isNullTreatment = (clinicInfor.Treatment_ID == null) ? true : false;

            string treatment = "";
            if (!isNullTreatment)
                treatment = clinicInfor.Treatment.TreatmentName.Name;
            else
                treatment = null;
            cmbTreatment.Text = treatment;
            //Combobox phương pháp điều trị
            if (!isNullTreatment)
                cmbTreatmentMethod.Text = clinicInfor.Treatment.TreatmentMethodName.Name;
            //Các textbox khác
            txtDiagnosis.Text = clinicInfor.Diagnosi.Diagnosis==null?"": clinicInfor.Diagnosi.Diagnosis;
            numQuantity.Value = clinicInfor.Quantity<1?1: clinicInfor.Quantity;
        }

        private void FormAddDiagnosisTreatment_Load(object sender, EventArgs e)
        {
            //ADD
            if (!isEdit)
            {
                try
                {
                    lblPatient.Text = _PatientID + "|" + patientInformationService.GetByID(_PatientID).FullName;
                    var ListTreatment = treatmentNameService.GetAll();
                    FillComboBoxTreatment(ListTreatment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Edit
            else
            {
                try
                {
                    FillDataWhenLoadUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private bool isNullDiagAndTreatment()
        {
            if ((txtDiagnosis.Text == "" || txtDiagnosis.Text == null) && (cmbTreatment.Text == "" || cmbTreatment.Text == null))
                return true;
            return false;
        }

        //private bool isHasInvoice()
        //{
        //    return treatmentInvoiceDetailsService.GetByClinicInforID(_ClinicInf.ToString()) == null ? false : true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                try
                {
                    if (isNullDiagAndTreatment())
                        throw new Exception("Không được đồng thời để trống Chẩn đoán và Điều trị.");

                    //Table ClinicalInfor gồm các cột:
                    //[ID],
                    //[Patient_ID][int?],
                    //[Diagnosis_ID][int?],
                    //[Treatment_ID][int?],
                    //[Quantity][int],
                    //[TotalAmount][int?]

                    //[Patient_ID][int?]
                    int patientID = Convert.ToInt32(_PatientID);

                    //[Diagnosis_ID][int?],
                    string diag = (txtDiagnosis.Text != null || txtDiagnosis.Text != "") ? txtDiagnosis.Text : "";
                    int diagID = diagnosisService.AddDiagnosisAndReturnID(diag);

                    //[Treatment_ID][int?]
                    int? treatID;
                    if (cmbTreatment.Text == "" || cmbTreatment.Text == null)
                        treatID = null;
                    else
                        treatID = treatmentService.GetID(cmbTreatment.SelectedValue.ToString(), cmbTreatmentMethod.SelectedValue.ToString());
                    //[Quantity][int]
                    int quantity = (cmbTreatment.Text == "" || cmbTreatment.Text == null)?0:(Convert.ToInt32(numQuantity.Value));
                    //[TotalAmount][int?]
                    decimal? totalAmount;
                    if (cmbTreatment.Text == "" || cmbTreatment.Text == null)
                        totalAmount = null;
                    else
                        totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    //Insert new Clinic Infor
                    clinicalInformationService.Insert(patientID, diagID, treatID, quantity, totalAmount);
                    MainForm.frmMedicExamInfor_Load(sender,e);
                    throw new Exception("Thêm thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {
                    if (isNullDiagAndTreatment())
                        throw new Exception("Không được đồng thời để trống Chẩn đoán và Điều trị.");
                    var clinicInfor = clinicalInformationService.GetByClinicID(_ClinicInf.ToString());

                    int patientID = Convert.ToInt32(_PatientID);

                    int diagID = clinicInfor.Diagnosi.ID;
                    string diag = (txtDiagnosis.Text != null || txtDiagnosis.Text != "") ? txtDiagnosis.Text : "";
                    Diagnosi diagn = new Diagnosi {ID = diagID,Diagnosis = diag};
                    diagnosisService.Update(diagn) ;

                    int? treatID;
                    if (cmbTreatment.Text == "" || cmbTreatment.Text == null)
                        treatID = null;
                    else
                        treatID = treatmentService.GetID(cmbTreatment.SelectedValue.ToString(), cmbTreatmentMethod.SelectedValue.ToString());

                    int quantity = (cmbTreatment.Text == "" || cmbTreatment.Text == null) ? 0 : (Convert.ToInt32(numQuantity.Value));

                    decimal? totalAmount;
                    if (cmbTreatment.Text == "" || cmbTreatment.Text == null)
                        totalAmount = null;
                    else
                        totalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                    var updateClinicInf = new ClinicalInformation {
                        ID = clinicInfor.ID,
                        Patient_ID = clinicInfor.Patient_ID,
                        Diagnosis_ID = diagID,
                        Treatment_ID = treatID,
                        Quantity = quantity,
                        TotalAmount = totalAmount
                    };

                    clinicalInformationService.Update(updateClinicInf);
                    MainForm.frmMedicExamInfor_Load(sender, e);
                    throw new Exception("Sửa thành công.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
