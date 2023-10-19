using gui.StatisticForm.InventoryStatisticForm;
using gui.StatisticForm.RevenueStatisticForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.StatisticForm
{
    public partial class frmStatistic : Form
    {
        private frmInventoryStatistic frm1;
        private frmRevenueStatistic frm2;
        public frmStatistic()
        {
            InitializeComponent();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            btnRevenue.BackColor = Color.LightBlue;
            btnInventory.BackColor = SystemColors.Window;
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new frmRevenueStatistic();
                frm2.MdiParent = this;
                frm2.Dock = DockStyle.Fill;
                frm2.Show();
            }
            else
            {
                if (frm2.WindowState == FormWindowState.Minimized)
                    frm2.WindowState = FormWindowState.Normal;
                frm2.BringToFront();
            }
            
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            btnRevenue_Click(sender, e);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            btnInventory.BackColor = Color.LightBlue;
            btnRevenue.BackColor = SystemColors.Window;
            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new frmInventoryStatistic();
                frm1.MdiParent = this;
                frm1.Dock = DockStyle.Fill;
                frm1.Show();
            }
            else
            {
                if (frm1.WindowState == FormWindowState.Minimized)
                    frm1.WindowState = FormWindowState.Normal;
                frm1.BringToFront();
            }
        }
    }
}
