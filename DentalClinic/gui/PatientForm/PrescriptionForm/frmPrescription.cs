using bus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using dal.Entities;
using gui.PatientForm.PrescriptionForm.MedInvoiceForm;

namespace gui.PatientForm.PrescriptionForm
{

    public partial class frmPrescription : Form
    {
        DentalModel dentalModel;
        public int p_id;
        public bool remainChecked;
        DentalModel model;
        private readonly MedicineService medicineService = new MedicineService();
        private readonly PatientInformationService patient = new PatientInformationService();
        List<Unit> units;
        public frmPrescription()
        {
            InitializeComponent();
        }
        private void FillMedicineComboBox(List<Medicine> medList)
        {
            this.cmbMedicine.DataSource = medList;
            this.cmbMedicine.DisplayMember = "MedicineName";
            this.cmbMedicine.ValueMember = "MedicineID";
        }
        private void FillUnitCombobox(List<Unit> unitList)
        {
            this.cmbUnit.DataSource = unitList;
            this.cmbUnit.DisplayMember = "UnitValueName";
            this.cmbUnit.ValueMember = "IDUnit";
        }
        List<Unit> GetUnits()
        {
            units = new List<Unit>()
           {
               new Unit(){IDUnit =1,UnitValueName="Chai"},
               new Unit(){IDUnit =2,UnitValueName="Hộp"}
            };
            return units;
        }
        public int GetPatientID()
        {
            int a;
            a = p_id;
            return a;
        }
        public void InstantiateMyNumericUpDown()
        {
            numQuantity.Value = 1;
            numQuantity.Maximum = 2500;
            numQuantity.Minimum = 1;
        }
        private void frmPrescription_Load(object sender, EventArgs e)
        {
            try
            {
                dentalModel = new DentalModel();
                var medicine = medicineService.GetAllMedicine();
                var unit = GetUnits();
                FillMedicineComboBox(medicine);
                InstantiateMyNumericUpDown();
                FillUnitCombobox(unit);
                string s = string.Format("ID bệnh nhân: {0}\n\nTên bệnh nhân: {1}", GetPatientID(), patient.GetByID(GetPatientID().ToString()).FullName);
                lblID.Text = s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Annoucement", MessageBoxButtons.OK);
            }
        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedIndex > -1)
            {
                var item = cmbMedicine.SelectedItem as Medicine;
                if (item != null)
                {
                    txtPricePer.Text = item.UnitPrice.ToString();
                    cmbUnit.Text = item.Unit.ToString();
                    txtDosage.Text = item.Dosage.ToString();
                }
            }
        }
        private void InsertGrid(int selectedRow)
        {
            dgvMedicine.Rows[selectedRow].Cells[1].Value = cmbMedicine.Text;
            dgvMedicine.Rows[selectedRow].Cells[2].Value = txtDosage.Text;
            dgvMedicine.Rows[selectedRow].Cells[3].Value = cmbUnit.Text;
            dgvMedicine.Rows[selectedRow].Cells[4].Value = numQuantity.Value;
            dgvMedicine.Rows[selectedRow].Cells[5].Value = txtPricePer.Text;
        }

        private int GetSelectedRow(string id)
        {
            for (int i = 0; i < dgvMedicine.Rows.Count; i++)
            {
                if (dgvMedicine.Rows[i].Cells[1].Value != null)
                {
                    if (dgvMedicine.Rows[i].Cells[1].Value.ToString() == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        private void dgvMedicine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvMedicine.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow r in dgvMedicine.Rows)
            {
                if (r.Selected)
                {
                    cmbMedicine.Text = dgvMedicine.Rows[r.Index].Cells[1].Value.ToString();
                    cmbUnit.Text = dgvMedicine.Rows[r.Index].Cells[3].Value.ToString();
                    numQuantity.Value = int.Parse(dgvMedicine.Rows[r.Index].Cells[4].Value.ToString());
                    txtDosage.Text = dgvMedicine.Rows[r.Index].Cells[2].Value.ToString();
                    txtPricePer.Text = dgvMedicine.Rows[r.Index].Cells[5].Value.ToString();
                }
            }
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMedicine.Rows)
                {
                    if (row.Cells[1].Value.ToString() == cmbMedicine.Text)
                    {
                        throw new Exception("Đã có thuốc trong danh sách.");
                    }
                }
                int r = GetSelectedRow(cmbMedicine.SelectedItem.ToString());
                if (r == -1)
                {
                    decimal c1 = 0, c2 = 0, total = 0;
                    r = dgvMedicine.Rows.Add();
                    InsertGrid(r);
                    for (int i = 0; i < dgvMedicine.Rows.Count; i++)
                    {
                        c1 = Convert.ToDecimal(dgvMedicine.Rows[i].Cells[4].Value.ToString());
                        c2 = Convert.ToDecimal(dgvMedicine.Rows[i].Cells[5].Value.ToString());
                        total = c1 * c2;
                        dgvMedicine.Rows[i].Cells[6].Value = total.ToString();
                    }
                    RefreshGB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void RefreshGB()
        {
            cmbMedicine.SelectedIndex = 0;
            numQuantity.Value = 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMedicine.Rows)
                {
                    if (row.Selected)
                    {
                        decimal c1 = 0, c2 = 0, total = 0;
                        InsertGrid(row.Index);
                        c1 = Convert.ToDecimal(dgvMedicine.Rows[row.Index].Cells[4].Value.ToString());
                        c2 = Convert.ToDecimal(dgvMedicine.Rows[row.Index].Cells[5].Value.ToString());
                        total = c1 * c2;
                        dgvMedicine.Rows[row.Index].Cells[6].Value = total.ToString();
                        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK);
                    }
                    RefreshGB();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDeleteMedicine_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvMedicine.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvMedicine.Rows)
                    {
                        if (row.Selected)
                        {
                            dgvMedicine.Rows.RemoveAt(row.Index);
                        }
                    }
                }
                else
                    throw new Exception("Không có dữ liệu để xóa");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnPrintMedicinePrescription_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedDetail medInvoice = new frmMedDetail();
                if (dgvMedicine.Rows.Count <= 0)
                    throw new Exception("Danh sách trống");
                foreach (DataGridViewRow r in dgvMedicine.Rows)
                {

                    ListViewItem lv = new ListViewItem(r.Cells[0].Value.ToString());
                    lv.SubItems.Add(r.Cells[1].Value.ToString());
                    lv.SubItems.Add(r.Cells[2].Value.ToString());
                    lv.SubItems.Add(r.Cells[3].Value.ToString());
                    lv.SubItems.Add(r.Cells[4].Value.ToString());
                    lv.SubItems.Add(r.Cells[5].Value.ToString());
                    lv.SubItems.Add(r.Cells[6].Value.ToString());
                    medInvoice.AddItemsToList(lv);
                }
                medInvoice.PatientID = p_id;
                medInvoice.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

    }
    public class Unit
    {
        public int IDUnit { get; set; }
        public string UnitValueName { get; set; }
    }
}
