using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class frmMedicExamInfor : Form
    {
        //Mã bệnh nhân được truyền từ frm bệnh nhân
        public string _PatientID;

        private readonly SubClinicalInformationService subClinicalInformationService = new SubClinicalInformationService();
        private readonly PatientInformationService patientInformationService = new PatientInformationService();
        private readonly TreatmentService treatmentService = new TreatmentService();
        private readonly TreatmentNameService treatmentNameService = new TreatmentNameService();
        private readonly DiagnosisService diagnosisService = new DiagnosisService();
        private readonly ClinicalInformationService clinicalInformationService = new ClinicalInformationService();
        private readonly TreatmentInvoiceDetailsService treatmentInvoiceDetailService = new TreatmentInvoiceDetailsService();

        private static string ChangeNull(object param)
        {
            return (param == null || param.ToString() == "null" || param.ToString() == "") ? "" : param.ToString();
        }
        public void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public frmMedicExamInfor()
        {
            InitializeComponent();
        }

        //Load Form
        public void frmMedicExamInfor_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(this.dgvClinicalInfor);
                //Điền thông tin cận lâm sàng
                var SubCliInf = subClinicalInformationService.GetById(_PatientID);
                if (SubCliInf == null)
                {
                    subClinicalInformationService.Insert(_PatientID);
                    frmMedicExamInfor_Load(sender, e);
                }
                if (SubCliInf != null)
                {
                    FillSubClinicalInformation(SubCliInf);
                }
                //Điền thông tin lâm sàng
                var ClinInf = clinicalInformationService.GetByID(_PatientID);
                if (ClinInf != null)
                {
                    BindGrid(ClinInf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Điền thông tin lâm sàng vào bảng
        private void BindGrid(List<ClinicalInformation> ClinInf)
        {
            dgvClinicalInfor.Rows.Clear();
            int index = 1;
            foreach (var item in ClinInf)
            {
                string id = item.ID.ToString();
                string diag = ChangeNull(item.Diagnosi.Diagnosis);
                string treatment = "";
                string treatmentMethod = "";
                string unitPrice = "";
                string unit = "";
                if (item.Treatment != null)
                {
                    treatment = ChangeNull(item.Treatment.TreatmentName.Name);
                    treatmentMethod = ChangeNull(item.Treatment.TreatmentMethodName.Name);
                    unit = ChangeNull(item.Treatment.Unit);
                    unitPrice = ChangeNull(item.Treatment.UnitPrice.ToString());
                }
                string quantity = ChangeNull(item.Quantity.ToString());

                string totalAmount = ChangeNull(item.TotalAmount.ToString());
                string date = ChangeNull(item.Diagnosi.ExaminationTime.ToString());
                bool hasInvoice = treatmentInvoiceDetailService.GetByClinicInforID(item.ID.ToString()) == null ? false : true;
                dgvClinicalInfor.Rows.Add(index, id, diag, treatment, treatmentMethod, unit, quantity, unitPrice, totalAmount, date, hasInvoice);
                index++;
            }
        }

        //Điền thông tin bệnh nhân vào form
        private void FillSubClinicalInformation(SubClinicalInformation SubCliInf)
        {
            grbSubExamInfor.Text = _PatientID + "|" + patientInformationService.GetByID(_PatientID).FullName;
            lblBloodPressure.Text = ChangeNull(SubCliInf.BloodPressure);
            lblPulseRate.Text = ChangeNull(SubCliInf.PulseRate);
            lblBloodSugarLevel.Text = ChangeNull(SubCliInf.BloodSugarLevel);

            if (ChangeNull(SubCliInf.BloodCoagulation) != "TS" || ChangeNull(SubCliInf.BloodCoagulation) != "TC")
                lblBloodCoagulation.Text = "Không";
            else
                lblBloodCoagulation.Text = ChangeNull(SubCliInf.BloodCoagulation);
            if (SubCliInf.CongenitalHeartDisease == null)
                lblCongenitalHeartDisease.Text = "Không";
            else
                lblCongenitalHeartDisease.Text = ChangeNull((bool)(SubCliInf.CongenitalHeartDisease) ? "Có" : "Không");
            if (SubCliInf.IntellectualDisability == null)
                lblIntellectualDisability.Text = "Không";
            else
                lblIntellectualDisability.Text = ChangeNull((bool)SubCliInf.IntellectualDisability ? "Có" : "Không");
            lblWarrantyID.Text = ChangeNull(SubCliInf.WarrantyID);
            lblLaboName.Text = ChangeNull(SubCliInf.LaboName);
            lblOther.Text = ChangeNull(SubCliInf.Other);

            if (SubCliInf.XRayFilm == null)
                picXray.Image = null;
            else
            {
                using (var ms = new MemoryStream(SubCliInf.XRayFilm))
                {
                    picXray.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnUpdateSubClinicInf_Click(object sender, EventArgs e)
        {
            FormEditSubClinicInf formEditSubClinicInf = new FormEditSubClinicInf();
            formEditSubClinicInf._PatientID = this._PatientID;
            formEditSubClinicInf.PreForm = this;
            formEditSubClinicInf.ShowDialog();
        }

        private void menuBtnEditSubClinicInf_Click(object sender, EventArgs e)
        {
            btnUpdateSubClinicInf_Click(sender, e);
        }

        private void menuBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Thêm thông tin điều trị
        private void menu2BtnAdd_Click(object sender, EventArgs e)
        {
            FormAddDiagnosisTreatment form = new FormAddDiagnosisTreatment();
            form._PatientID = this._PatientID;
            form.MainForm = this;
            form.isEdit = false;
            form._ClinicInf = null;
            form.ShowDialog();
        }

        private void dgvClinicalInfor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClinicalInfor.SelectedRows.Count > 0 && !Convert.ToBoolean(dgvClinicalInfor.SelectedRows[0].Cells["ColumnInvoice"].Value))
            {
                menu2BtnEdit.Enabled = true;
                menu2BtnDelete.Enabled = true;
            }
            else if (dgvClinicalInfor.SelectedRows.Count > 0 && Convert.ToBoolean(dgvClinicalInfor.SelectedRows[0].Cells["ColumnInvoice"].Value))
            {
                menu2BtnEdit.Enabled = false;
                menu2BtnDelete.Enabled = false;
            }
        }

        //Chỉnh sửa thông tin điều trị
        private void menu2BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClinicalInfor.SelectedRows.Count > 0)
            {
                FormAddDiagnosisTreatment form = new FormAddDiagnosisTreatment();
                form._PatientID = this._PatientID;
                form.MainForm = this;
                form.isEdit = true;
                form._ClinicInf = Convert.ToInt32(dgvClinicalInfor.SelectedRows[0].Cells["ColumnIDClinicInf"].Value);
                form.ShowDialog();
            }
        }
        //Form xuất hóa đơn
        private void menu2Invoice_Click(object sender, EventArgs e)
        {
            FormPrintInvoice form = new FormPrintInvoice();
            form._PatientID = this._PatientID;
            form.mainForm = this;
            form.ShowDialog();
        }

        private bool isHasInvoice(DataGridViewRow row)
        {
            if (Convert.ToBoolean(row.Cells["ColumnInvoice"].Value))
                return true;
            return false;
        }
        //Bấm vào nút xóa thông tin điều trị.
        private void menu2BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClinicalInfor.SelectedRows.Count > 0)
                {
                    var row = dgvClinicalInfor.SelectedRows[0];
                    if (!isHasInvoice(row))
                    {
                        string id = row.Cells["ColumnIDClinicInf"].Value.ToString();
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            clinicalInformationService.Delete(id);
                            ShowMessage("Xóa thành công.");
                            frmMedicExamInfor_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        //Bấm nút hủy hóa đơn
        private void menu2BtnDeleteInvoice_Click(object sender, EventArgs e)
        {
            FormDeleteInvoice form = new FormDeleteInvoice();
            form._PatientID = this._PatientID;
            form.PreForm = this;
            form.ShowDialog();
        }
    }
}
