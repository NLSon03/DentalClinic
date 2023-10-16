using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dal.Entities;
using bus;
namespace gui.PatientForm.PrescriptionForm.SearchingForm
{
    public partial class frmPrescriptionSearching : Form
    {
        private readonly PrescriptionDetailsService pds = new PrescriptionDetailsService();
        private readonly PrescriptionService prescriptionService = new PrescriptionService();
        private readonly MedicineService med = new MedicineService();
        public frmPrescriptionSearching()
        {
            InitializeComponent();
        }
        private void FillComboBox(List<Prescription> medList)
        {
            medList.Insert(0, new Prescription());
            this.cboSearch.DataSource = medList;
            this.cboSearch.DisplayMember = "PrescriptionID";
            this.cboSearch.ValueMember = "PrescriptionID";
        }
        private void BindGrid(List<PrescriptionDetails> details)
        {
            dgvMedicine.Rows.Clear();
            foreach (var item in details)
            {
                int i = dgvMedicine.Rows.Add();
                if (item != null)
                {
                    dgvMedicine.Rows[i].Cells[1].Value = item.Medicine.MedicineName;
                    dgvMedicine.Rows[i].Cells[2].Value = item.Medicine.Dosage;
                    dgvMedicine.Rows[i].Cells[3].Value = item.Unit;
                    dgvMedicine.Rows[i].Cells[4].Value = item.Quantity;
                    dgvMedicine.Rows[i].Cells[5].Value = item.UnitPrice;
                    dgvMedicine.Rows[i].Cells[6].Value = item.TotalAmount;
                }
            }
        }
        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = cboSearch.SelectedItem as Prescription;
            if(list != null)
            {
                var item = pds.GetPrescriptionDetails(list.PrescriptionID);
                BindGrid(item);
            }
        }

        private void dgvMedicine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvMedicine.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void frmPrescriptionSearching_Load(object sender, EventArgs e)
        {
            var pdList = pds.GetPrescriptionDetails();
            var preList = prescriptionService.GetAll();
            FillComboBox(preList);
        }
    }
}
