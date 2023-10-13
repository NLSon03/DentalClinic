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

namespace gui.PatientForm.PrescriptionForm
{

    public partial class frmPrescription : Form
    {
        DentalModel dentalModel;
        private readonly MedicineService medicineService = new MedicineService();
        List<Unit> units;
        public frmPrescription()
        {
            InitializeComponent();
        }
        private void FillMedicineComboBox(List<Medicine> medList)
        {
            medList.Insert(0, new Medicine());
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
               new Unit(){IDUnit =1,UnitValueName="Cái"},
                new Unit(){IDUnit =2,UnitValueName="Viên"},
               new Unit(){IDUnit =3,UnitValueName="Hộp"}
            };
            return units;
        }
        public void InstantiateMyNumericUpDown()
        {
            numQuantity.Value = 1;
            numQuantity.Maximum = 2500;
            numQuantity.Minimum =1;
        }
        private void frmPrescription_Load(object sender, EventArgs e)
        {
            try
            {
                dentalModel = new DentalModel();
                //var medicine = medicineService.GetAllMedicine();
                var unit = GetUnits();
                //FillMedicineComboBox(medicine);
                InstantiateMyNumericUpDown();
                FillUnitCombobox(unit);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data into controls needed", "Annoucement", MessageBoxButtons.OK);
            }
        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedIndex > -1)
            {
                foreach(var item in medicineService.GetAllMedicine())
                {
                    if(int.Parse(cmbMedicine.SelectedValue.ToString()) == item.MedicineID)
                        txtPricePer.Text = item.UnitPrice.ToString();
                }
            }
        }
    }
    public class Unit
    {
        public int IDUnit { get; set; }
        public string UnitValueName { get; set; }
    }
}
