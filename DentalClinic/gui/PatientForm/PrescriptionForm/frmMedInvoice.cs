using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gui.PatientForm.PrescriptionForm
{
    public partial class frmMedInvoice : Form
    {
        public frmMedInvoice()
        {
            InitializeComponent();
        }
        public void AddItemsToList(ListViewItem lvi)
        {
            lvMedInvoice.Items.Add(lvi);
        }
        private int GenerateID()
        {
            Random rnd = new Random();
            return rnd.Next(1, 10000000);
        }
        private int GetID(string name)
        {
            using (var model = new DentalModel())
            {
                var a = (from b in model.Medicine
                         where b.MedicineName == name
                         select b.MedicineID).FirstOrDefault();
                return a;
            }
        }
        private decimal Total()
        {
            decimal total = 0;
            foreach (ListViewItem lv in lvMedInvoice.Items)
            {
                total += Convert.ToDecimal(lv.SubItems[6].Text);
            }
            return total;
        }

        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            try
            {
                using (var model = new DentalModel())
                {
                    foreach (ListViewItem lv in lvMedInvoice.Items)
                    {
                        var item = new PrescriptionDetails()
                        {
                            PrescriptionID = GenerateID(),
                            MedicineID = GetID(lv.SubItems[1].Text),
                            Unit = lv.SubItems[3].Text,
                            Quantity = int.Parse(lv.SubItems[4].Text),
                            UnitPrice = decimal.Parse(lv.SubItems[5].Text),
                            TotalAmount = decimal.Parse(lv.SubItems[6].Text)
                        };
                        model.PrescriptionDetails.Add(item);
                    }
                    model.SaveChanges();
                    // MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmMedInvoice_Load(object sender, EventArgs e)
        {
            textBox1.Text = Total().ToString();
            string s = string.Format("Mã DT: {0}", GenerateID());
            lblIDMed.Text = s;
        }
        private ListViewItem unique = new ListViewItem();
        private void lvMedInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMedInvoice.SelectedItems.Count > 0)
            {
                ListViewItem lv = lvMedInvoice.SelectedItems[0];
                unique = lv;
            }
        }
    }
}
