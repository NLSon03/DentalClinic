using bus;
using dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                   

                }
            }
        }

        private void btnExitDentalTool_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn quay lại trang trước", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemDentalTool_Click(object sender, EventArgs e)
        {
            
            DentalModel context = new DentalModel();
            int ms = Int32.Parse(txtMaDungCu.Text);
            DentalTool db = dentalToolService.findByID(ms);
            DentalTool s = new DentalTool()
            {
                ToolID = int.Parse(txtMaDungCu.Text),
                ToolName = txtTenDungCu.Text,
                Unit = txtDonViTinh.Text,
                Quantity = int.Parse(txtSoLuong.Text),
            };

            context.DentalTools.Add(s);
            context.SaveChanges();

            frmDentalTool_Load(sender, e);
        }

        private void btnSuaDentalTool_Click(object sender, EventArgs e)
        {
            try
            {
                
                DentalTool sv = dentalToolService.findByID(int.Parse(txtMaDungCu.Text));
                if (sv == null) throw new Exception("Không tìm thấy mã cần sửa.");
                DentalTool sinhvien = new DentalTool() { ToolID =int.Parse(txtMaDungCu.Text), ToolName = txtTenDungCu.Text, Unit = txtDonViTinh.Text, Quantity = int.Parse(txtSoLuong.Text) };
                dentalToolService.InsertUpdate(sinhvien);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDentalTool_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaDentalTool_Click(object sender, EventArgs e)
        {
            try
            {
                DentalTool sinhvien = dentalToolService.findByID(int.Parse(txtMaDungCu.Text));
                if (sinhvien == null)
                    throw new Exception("Không tìm thấy mã sinh viên cần xóa.");

                DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    dentalToolService.DeleteById(int.Parse(txtMaDungCu.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmDentalTool_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDentalTool_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dgvDentalTool.Rows[e.RowIndex];
            txtMaDungCu.Text = row.Cells[0].Value.ToString();
            txtTenDungCu.Text = row.Cells[1].Value.ToString();
            txtDonViTinh.Text = row.Cells[2].Value.ToString();
            txtSoLuong.Text = row.Cells[3].Value.ToString();

        }
    }
}
