using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui.DentalForm
{
    public partial class frmDentalTool : Form
    {

        private readonly DentalToolService dentalToolService = new DentalToolService();

        public frmDentalTool()
        {
            InitializeComponent();
        }

        private void frmDentalTool_Load(object sender, EventArgs e)
        {  
            try
            {
                setGridViewStyle(dgvDentalTool);
                var listDentalTool = dentalToolService.getAll();
               
                BindGrid(listDentalTool);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<DentalTool> listDentalTool)
        {
            dgvDentalTool.Rows.Clear();
            foreach (var item in listDentalTool)
            {
                if (item != null)
                {

                    int index = dgvDentalTool.Rows.Add();
                    dgvDentalTool.Rows[index].Cells[0].Value = item.ToolID;
                    dgvDentalTool.Rows[index].Cells[1].Value = item.ToolName;
                    dgvDentalTool.Rows[index].Cells[2].Value = item.Unit;
                    dgvDentalTool.Rows[index].Cells[3].Value = item.Quantity;
                    dgvDentalTool.Rows[index].Cells[4].Value = (long)item.PurchasedPrice;
                    dgvDentalTool.Rows[index].Cells[5].Value = (long)item.SellingPrice;

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

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thêmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentalMaterials frm = new frmDentalMaterials();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

            private void txtFindDentalTool_TextChanged(object sender, EventArgs e)
        {
            string findName = txtFindDentalTool.Text;
            findName = RemoveDiacritics(findName);
            for (int i = 0; i < dgvDentalTool.Rows.Count; i++)
            {
                string name = dgvDentalTool.Rows[i].Cells[1].Value.ToString();


                name = RemoveDiacritics(name);


                bool contains = name.IndexOf(findName, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    dgvDentalTool.Rows[i].Visible = true;
                }
                else
                {
                    dgvDentalTool.Rows[i].Visible = false;
                }
            }
        }
    }
}
