using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using static iTextSharp.text.TabStop;
using static System.Net.WebRequestMethods;

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
            if (param == null)
            {
                return "";
            }

            string paramString = param.ToString();
            return (paramString == "null" || paramString == "") ? "" : paramString;
        }
        public void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
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
                    SubCliInf = subClinicalInformationService.GetById(_PatientID);
                }
                FillSubClinicalInformation(SubCliInf);

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

        private string FixWarrantyID(object param)
        {
            if (param == null)
            {
                return "";
            }

            string paramString = param.ToString();
            if (paramString.Contains("null") || paramString == "" || paramString.Contains(" "))
            {
                return paramString.Replace(" ", "").Replace("null", "");
            }

            return paramString;
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
                string quantity = ChangeNull(item.Quantity.ToString());
                string totalAmount = Convert.ToDecimal(ChangeNull(item.TotalAmount)).ToString("N0");
                string date = ChangeNull(item.Diagnosi.ExaminationTime.ToString());
                bool hasInvoice = treatmentInvoiceDetailService.GetByClinicInforID(id) != null;

                if (item.Treatment != null)
                {
                    treatment = ChangeNull(item.Treatment.TreatmentName.Name);
                    treatmentMethod = ChangeNull(item.Treatment.TreatmentMethodName.Name);
                    unit = ChangeNull(item.Treatment.Unit);
                    unitPrice = Convert.ToDecimal(ChangeNull(item.Treatment.UnitPrice)).ToString("N0");
                }

                dgvClinicalInfor.Rows.Add(index++, id, diag, treatment, treatmentMethod, unit, quantity, unitPrice, totalAmount, date, hasInvoice);
            }
        }

        //Điền thông tin bệnh nhân vào form
        private void FillSubClinicalInformation(SubClinicalInformation SubCliInf)
        {
            var patient = patientInformationService.GetByID(_PatientID);
            lblPatient.Text = $"Mã số: {patient.PatientID} - Tên: {patient.FullName}";

            lblBloodPressure.Text = ChangeNull(SubCliInf.BloodPressure);
            lblPulseRate.Text = ChangeNull(SubCliInf.PulseRate);
            lblBloodSugarLevel.Text = ChangeNull(SubCliInf.BloodSugarLevel);

            lblBloodCoagulation.Text = (ChangeNull(SubCliInf.BloodCoagulation) != "TS" && ChangeNull(SubCliInf.BloodCoagulation) != "TC") ? "Không" : ChangeNull(SubCliInf.BloodCoagulation);

            lblCongenitalHeartDisease.Text = SubCliInf.CongenitalHeartDisease == null ? "Không" : (bool)SubCliInf.CongenitalHeartDisease ? "Có" : "Không";
            lblIntellectualDisability.Text = SubCliInf.IntellectualDisability == null ? "Không" : (bool)SubCliInf.IntellectualDisability ? "Có" : "Không";

            lblWarrantyID.Text = FixWarrantyID(SubCliInf.WarrantyID);
            lblLaboName.Text = ChangeNull(SubCliInf.LaboName);
            lblOther.Text = ChangeNull(SubCliInf.Other);

            picXray.Image = SubCliInf.XRayFilm == null ? null : Image.FromStream(new MemoryStream(SubCliInf.XRayFilm));
        }

        private void btnUpdateSubClinicInf_Click(object sender, EventArgs e)
        {
            using (FormEditSubClinicInf formEditSubClinicInf = new FormEditSubClinicInf())
            {
                formEditSubClinicInf._PatientID = this._PatientID;
                formEditSubClinicInf.PreForm = this;
                formEditSubClinicInf.ShowDialog(this);
            }
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
                menuBtnEditClinicInfor.Enabled = true;
                menuBtnDeleteClinicInf.Enabled = true;
            }
            else if (dgvClinicalInfor.SelectedRows.Count > 0 && Convert.ToBoolean(dgvClinicalInfor.SelectedRows[0].Cells["ColumnInvoice"].Value))
            {
                menu2BtnEdit.Enabled = false;
                menu2BtnDelete.Enabled = false;
                menuBtnEditClinicInfor.Enabled = false;
                menuBtnEditClinicInfor.Enabled = false;
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
                    else
                    {
                        ShowMessage("Không thể xóa thông tin lâm sàng vì đã có hóa đơn.");
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

        private void menuBtnEditClinicInfor_Click(object sender, EventArgs e)
        {
            menu2BtnEdit_Click(sender, e);
        }

        private void menuBtnDeleteClinicInf_Click(object sender, EventArgs e)
        {
            menu2BtnDelete_Click(sender, e);
        }

        private void menuBtnPrintInvoice_Click(object sender, EventArgs e)
        {
            menu2Invoice_Click(sender, e);
        }

        private void menuBtnAddClinicInf_Click(object sender, EventArgs e)
        {
            menu2BtnAdd_Click(sender, e);
        }
    }
}
