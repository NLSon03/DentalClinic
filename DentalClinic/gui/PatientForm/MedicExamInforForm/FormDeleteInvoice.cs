using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gui.PatientForm.MedicExamInforForm
{
    public partial class FormDeleteInvoice : Form
    {
        public frmMedicExamInfor PreForm;
        public string _PatientID;

        private readonly PatientInformationService patientInformationService = new PatientInformationService();
        private readonly TreatmentInvoiceService treatmentInvoiceService = new TreatmentInvoiceService();

        public FormDeleteInvoice()
        {
            InitializeComponent();
        }

        private void btnDropInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa các hóa đơn đã chọn?\nSau khi xóa không thể hoàn tác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool isInvoiceDeleted = DeleteSelectedInvoices();
                if (!isInvoiceDeleted)
                    MessageBox.Show("Không có hóa đơn nào được chọn.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                else
                {
                    PreForm.frmMedicExamInfor_Load(sender, e);
                    this.FormDeleteInvoice_Load(sender, e);
                }
            }
        }

        private bool DeleteSelectedInvoices()
        {
            bool isInvoiceDeleted = false;
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ColumnDrop"].Value))
                {
                    treatmentInvoiceService.DeleteInvoiceByID(row.Cells["Id"].Value.ToString());
                    isInvoiceDeleted = true;
                }
            }
            return isInvoiceDeleted;
        }

        private void FormDeleteInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataForLabelName();
                setGridViewStyle(this.dgvInvoice);

                var list = treatmentInvoiceService.GetAllByPatientID(_PatientID);

                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetDataForLabelName()
        {
            var patient = patientInformationService.GetByID(_PatientID);
            int id = patient.PatientID;
            string name = patient.FullName;
            lblPatient.Text = id + " | " + name;
        }

        private void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn column in dgvInvoice.Columns)
            {
                column.ReadOnly = true;
            }

            // Cho phép chỉnh sửa cho cột "ColumnDrop"
            dgvInvoice.Columns["ColumnDrop"].ReadOnly = false;
        }

        private void BindGrid(List<TreatmentInvoice> list)
        {
            dgvInvoice.Rows.Clear();

            string client = CheckNull(patientInformationService.GetByID(_PatientID)?.FullName);

            foreach (var item in list)
            {
                string date = CheckNull(item.Date.Value.ToString());
                string type = "Hóa đơn dịch vụ";
                string totalAmount = item.TotalAmount.ToString();
                string status = DateTime.Now.Subtract(item.Date.Value) <= TimeSpan.FromDays(3) ? "Có thể hủy" : "Không thể hủy";
                string id = CheckNull(item.ID.ToString());

                dgvInvoice.Rows.Add(date, client, type, totalAmount, status, id, false);
            }
        }

        private static string CheckNull(object param)
        {
            return param == null || string.IsNullOrEmpty(param.ToString()) ? "" : param.ToString();
        }

        private void chkShowAbleDeleteInvoice_CheckedChanged(object sender, EventArgs e)
        {
            var list = treatmentInvoiceService.GetAllByPatientID(_PatientID);

            if (chkShowAbleDeleteInvoice.Checked)
            {
                list.RemoveAll(item => (DateTime.Now - item.Date.Value).TotalDays > 3);
            }

            BindGrid(list);
        }

        private void dgvInvoice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var column = dgvInvoice.Columns[e.ColumnIndex];

            if (column.Name == "ColumnDrop")
            {
                var cellValue = dgvInvoice.Rows[e.RowIndex].Cells["ColumnDeteleInvoice"].Value.ToString();

                if (cellValue == "Không thể hủy")
                    e.Cancel = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDeleteInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
