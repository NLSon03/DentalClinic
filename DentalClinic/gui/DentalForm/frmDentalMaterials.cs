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
using bus;
using gui.DentalForm;

namespace gui.DentalMaterials
{
    public partial class frmDentalMaterials : Form
    {

        private readonly DentalToolService dentalToolService = new DentalToolService();
        private readonly DentalToolTransactionService dentalToolTransactionService = new DentalToolTransactionService();
        private readonly DentalToolTransactionDetails dentalToolTransactionDetailService = new DentalToolTransactionDetails();
        
        
        public frmDentalMaterials()
        {
            InitializeComponent();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn quay lại trang chủ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void btnThoatThongKe_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn quay lại trang chủ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }


       // form nhap xuat dung cu vat lieu
        /*Them dung cu vat lieu*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                checkValid();
                DentalToolTransactionsDetail sv = dentalToolTransactionDetailService.findByID(int.Parse(txtMaGiaoDich.Text));
                if (sv != null) throw new Exception("Mã sinh viên đã tồn tại.");
                DentalToolTransactionsDetail sinhvien = new DentalToolTransactionsDetail() {
                    TransactionID = int.Parse(txtMaGiaoDich.Text),
                    ToolID = int.Parse(cmbDungCu.SelectedValue.ToString()),
                    Unit = cmbDonViTinh.SelectedValue.ToString(),
                    UnitPrice = decimal.Parse(txtDonGia.Text),
                    Quantity = int.Parse(txtSoLuong.Text),
                    TotalAmount = decimal.Parse(txtThanhTien.Text),
                };

                dentalToolTransactionDetailService.InsertUpdate(sinhvien);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDentalMaterials_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkValid()
        {
            if (txtMaGiaoDich.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
                throw new Exception("Vui lòng nhập đầy đủ thông tin");
        }


        private void frmDentalMaterials_Load(object sender, EventArgs e)
        {
            try
            {
               
                var listDentalTool = dentalToolService.getAll();
                var listDentalToolTransactionDetail = dentalToolTransactionDetailService.getAll();
                FillFaculty(listDentalTool);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            cmbDonViTinh.Text = "";
        }

        private void FillFaculty(List<DentalTool> listDentalTool)
        {
            cmbDungCu.Items.Clear();
            cmbDungCu.DataSource = listDentalTool;
            cmbDungCu.ValueMember = "ToolID";
            cmbDungCu.DisplayMember = "ToolName";
        }


        private void BindGrid(List<DentalToolTransactionsDetail> listDentalToolTranscationDetail)
        {
            dgvDungCu.Rows.Clear();
            foreach (var item in listDentalToolTranscationDetail)
            {
                if(item != null)
                {
                    
                    int index = dgvDungCu.Rows.Add();                    
                    dgvDungCu.Rows[index].Cells[0].Value = item.TransactionID;
                    dgvDungCu.Rows[index].Cells[1].Value = item.DentalTool.ToolName;
                    dgvDungCu.Rows[index].Cells[2].Value = item.DentalTool.Unit;
                    dgvDungCu.Rows[index].Cells[3].Value = item.DentalTool.Quantity;
                    dgvDungCu.Rows[index].Cells[4].Value = item.UnitPrice;
                    dgvDungCu.Rows[index].Cells[5].Value = item.TotalAmount;
                   
                }               
            }
        }


        /*Xoa dung cu vat lieu*/
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DentalModel context = new DentalModel();
            int ms = Int32.Parse(txtMaGiaoDich.Text);
            DentalToolTransactionsDetail dbDelete = dentalToolTransactionDetailService.findByID(ms);

            if (dbDelete != null)
            {
                context.DentalToolTransactionsDetails.Remove(dbDelete);
                context.SaveChanges();
            }

            frmDentalMaterials_Load(sender, e);
        }


        /*Chinh sua*/
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DentalToolTransactionsDetail sinhvien = dentalToolTransactionDetailService.findByID(int.Parse(txtMaGiaoDich.Text));
                if (sinhvien == null)
                    throw new Exception("Không tìm thấy mã sinh viên cần xóa.");

                DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    dentalToolTransactionDetailService.DeleteById(int.Parse(txtMaGiaoDich.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmDentalMaterials_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            frmDentalMaterials_Load(sender, e);
        }

        private void dgvDungCu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dgvDungCu.Rows[e.RowIndex];
            txtMaGiaoDich.Text = row.Cells[0].Value.ToString();
            cmbDungCu.Text = row.Cells[1].Value.ToString();
            cmbDonViTinh.Text = row.Cells[2].Value.ToString();
            txtSoLuong.Text = row.Cells[3].Value.ToString();
            txtDonGia.Text = row.Cells[4].Value.ToString();
            txtThanhTien.Text = row.Cells[5].Value.ToString();
        }


       
        // ket thuc form quan li dung cu vat lieu.

        /*Ham tinh tong tien*/
        private decimal SumMoney(decimal money, decimal sl)
        {
            return money*sl;
        }

        /*code form thống kê*/
        // tao form load de tai lai du lieu
        private void loadFormThongKe(object sender, EventArgs e)
        {
            try
            {
                if (txtFindYear.Text.Length == 0)
                    throw new Exception("Vui long nhap nam thong ke");
                
               
              /*  BindGridThongKe();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimThongKe_Click(object sender, EventArgs e)
        {
            loadFormThongKe(sender,e);  
        }

        private void BindGridThongKe(List<DentalToolTransactionsDetail> listDentalToolTranscationDetail)
        {

            dgvThongKe.Rows.Clear();
            foreach (var item in listDentalToolTranscationDetail)
            {
                if (item != null)
                {

                    int index = dgvThongKe.Rows.Add();
                    dgvThongKe.Rows[index].Cells[0].Value = item.TransactionID;
                    dgvThongKe.Rows[index].Cells[1].Value = item.DentalTool.ToolName;
                    dgvThongKe.Rows[index].Cells[2].Value = item.DentalTool.Unit;
                    dgvThongKe.Rows[index].Cells[3].Value = item.DentalTool.Quantity;
                    dgvThongKe.Rows[index].Cells[4].Value = item.UnitPrice;
                    dgvThongKe.Rows[index].Cells[5].Value = item.TotalAmount;
                }
            }
        }

        

        private void btnDentalTool_Click(object sender, EventArgs e)
        {
            frmDentalTool fr = new frmDentalTool();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
    }
}
