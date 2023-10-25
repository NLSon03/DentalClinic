using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gui.DentalForm
{
    public partial class frmDentalToolMain : Form
    {

        private readonly DentalToolService dentalToolService = new DentalToolService();
        private readonly DentalToolTransactionService dentalToolTransactionService = new DentalToolTransactionService();
        private readonly DentalToolTransactionDetailsService dentalToolTransactionDetailService = new DentalToolTransactionDetailsService();
        public frmDentalToolMain()
        {
            InitializeComponent();
        }

        private void btnAddBillDentalTool_Click(object sender, EventArgs e)
        {
            frmDentalMaterials fr = new frmDentalMaterials();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void frmDentalToolMain_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvListBillDentalTool);
                var listDentalTool = dentalToolService.getAll();
                var listDentalToolTransactionDetail = dentalToolTransactionDetailService.GetAll();
                BindGrid(listDentalToolTransactionDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void BindGrid(List<DentalToolTransactionsDetail> listDentalToolTranscationDetail)
        {
            dgvListBillDentalTool.Rows.Clear();
            foreach (var item in listDentalToolTranscationDetail)
            {
                if (item != null)
                {

                    int index = dgvListBillDentalTool.Rows.Add();
                    dgvListBillDentalTool.Rows[index].Cells[0].Value = item.TransactionID;
                    dgvListBillDentalTool.Rows[index].Cells[1].Value = item.DentalTool.ToolName;
                    dgvListBillDentalTool.Rows[index].Cells[2].Value = item.DentalTool.Unit;
                    dgvListBillDentalTool.Rows[index].Cells[3].Value = item.Quantity;
                    dgvListBillDentalTool.Rows[index].Cells[4].Value = item.UnitPrice;
                    dgvListBillDentalTool.Rows[index].Cells[5].Value = item.TotalAmount;

                }
            }
        }

        public void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDentalTool frm = new frmDentalTool();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thêmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentalMaterials frm = new frmDentalMaterials();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentalTool fr = new frmDentalTool();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDentalToolMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
