using bus;
using dal.Entities;
using gui.PatientForm.CompletingMedInvoiceForm;
using gui.PatientForm.MedicExamInforForm;
using gui.PatientForm.PrescriptionForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmPatient : Form
    {

        PatientInformationService patientInformationService = new PatientInformationService();
        frmPatient patient;
        public DataGridView dgv;
        //set style cho bảng
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

        public frmPatient()
        {
            InitializeComponent();
            dgv = dgvPatient;
            patient = this;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Nhập thông tin bệnh nhân vào bảng
        private void BindGrid(List<PatientInformation> patients)
        {
            dgvPatient.Rows.Clear();
            foreach (var item in patients)
            {
                int index = dgvPatient.Rows.Add();
                dgvPatient.Rows[index].Cells[0].Value = item.PatientID;
                dgvPatient.Rows[index].Cells[1].Value = item.FullName;
                dgvPatient.Rows[index].Cells[2].Value = item.Gender ? "Nam" : "Nữ";
                dgvPatient.Rows[index].Cells[3].Value = item.YearOfBirth.ToString("dd-MM-yyyy") ?? "";
                dgvPatient.Rows[index].Cells[4].Value = item.PhoneNumber;
                dgvPatient.Rows[index].Cells[5].Value = item.Address;
                dgvPatient.Rows[index].Cells[6].Value = item.FirstExaminationDate?.ToString("dd-MM-yyyy") ?? "";
                dgvPatient.Rows[index].Cells[7].Value = item.ReasonForExamination;
            }
        }


        public void frmPatient_Load(object sender, EventArgs e)
        {
            try
            {
                btnCreatingPrescription.Enabled = false;
                //btnPurchase.Enabled = false;
                setGridViewStyle(this.dgvPatient);
                var ListPatient = patientInformationService.GetAll();
                BindGrid(ListPatient);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                btnAddNewPatient.PerformClick();
            }
        }
        private void OpenPrescriptionForm()
        {
            // Kiểm tra xem có hàng nào được chọn không
            var selectedRows = dgvPatient.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // Lấy ID của bệnh nhân từ hàng được chọn
            int patientId = int.Parse(selectedRows[0].Cells[0].Value.ToString());

            // Tạo và hiển thị form kê đơn
            frmPrescription f = new frmPrescription
            {
                p_id = patientId
            };
            f.ShowDialog();
        }
        private void btnCreatingPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvPatient.Rows)
                {
                    if (r.Selected)
                    {
                        if (dgvPatient.Rows[r.Index].Cells[8].Value == null)
                        {
                            OpenPrescriptionForm();
                        }
                        else
                        {
                            string s = string.Format("Bệnh nhân đã có đơn thuốc.\n Vui lòng chọn bệnh nhân khác");
                            throw new Exception(s);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        //Mở Form thông tin khám bệnh
        private void btnMedicExamInfor_Click(object sender, EventArgs e)
        {
            //Nếu có bệnh nhân trong bảng đươc chọn
            if (dgvPatient.SelectedRows.Count > 0)
            {
                //Truyền mã bệnh nhân được chọn sang frmMedicExamInfor
                string _PatientID = dgvPatient.SelectedRows[0].Cells[0].Value.ToString();

                frmMedicExamInfor frmMedicExamInfo = new frmMedicExamInfor();
                frmMedicExamInfo._PatientID = _PatientID;
                //Hiển thị form
                frmMedicExamInfo.ShowDialog();
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nút xem thông tin khám bệnh chỉ enable khi có một bệnh nhân được chọn
            if (dgvPatient.SelectedRows.Count > 0)
            {
                btnEditing.Enabled = true;
                menuBtnDelete.Enabled = true;
                btnMedicExamInfor.Enabled = true;
                btnCreatingPrescription.Enabled = true;
                foreach (DataGridViewRow r in dgvPatient.Rows)
                {
                    if (Convert.ToBoolean(r.Cells[8].Value))
                    {
                        btnPurchase.Enabled = true;
                    }
                }
            }
        }
        public void ReloadPatientList()
        {
            List<PatientInformation> list = patientInformationService.GetAll();
            BindGrid(list);
        }
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            frmNewPatient newPatient = new frmNewPatient();
            newPatient.mainForm = this;
            newPatient.ShowDialog();
        }

        private void btnEditing_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count > 0)
            {
                var row = dgvPatient.SelectedRows[0];
                var patientID = row.Cells["colPatientID"].Value.ToString();
                frmEditInfo frmEditInfo = new frmEditInfo();
                frmEditInfo.PatientID = patientID;
                frmEditInfo.MainForm = this;
                frmEditInfo.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn một bệnh nhân trước.");
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPatient.RefreshEdit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNewPatient_Click(sender, e);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvPatient.Rows)
            {
                if (r.Selected)
                {
                    if (Convert.ToBoolean(r.Cells[8].Value) == false)
                    {
                        btnPurchase.Enabled = true;
                        frmPurchase purchase = new frmPurchase();
                        purchase.ID_p = int.Parse(r.Cells[0].Value.ToString());
                        purchase.ShowDialog();
                    }
                }
            }
        }

        private void menuBtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân trước.");
                return;
            }

            var row = dgvPatient.SelectedRows[0];
            var patientID = row.Cells["colPatientID"].Value.ToString();

            try
            {
                if (!patientInformationService.IsAbleToDelete(patientID))
                {
                    MessageBox.Show("Bệnh nhân đã có đơn thuốc/ điều trị.\nKhông thể xóa.");
                    return;
                }

                patientInformationService.DeletePatient(patientID);
                MessageBox.Show("Xóa thành công");
                frmPatient_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa bệnh nhân: {ex.Message}");
            }
        }

    }
}
