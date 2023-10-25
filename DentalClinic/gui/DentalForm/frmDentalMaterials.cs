using bus;
using dal.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gui.DentalForm
{
    public partial class frmDentalMaterials : Form
    {

        private readonly DentalToolService dentalToolService = new DentalToolService();
        private readonly DentalToolTransactionService dentalToolTransactionService = new DentalToolTransactionService();
        private readonly DentalToolTransactionDetailsService dentalToolTransactionDetailService = new DentalToolTransactionDetailsService();
        public frmDentalMaterials()
        {
            InitializeComponent();
        }

        private void frmDentalMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvDungCu);
                var listDentalTool = dentalToolService.getAll();
                var listDentalToolTransactionDetail = dentalToolTransactionDetailService.GetAll();
                FillFaculty(listDentalTool);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            txtDonViTinh.Text = "";
        }



        private void checkValid()
        {
            if (txtSoLuong.Text == "" || txtDonGia.Text == "")
                throw new Exception("Vui lòng nhập đầy đủ thông tin");
        }

        private void BindGrid(List<DentalToolTransactionsDetail> listDentalToolTranscationDetail)
        {
            dgvDungCu.Rows.Clear();
            foreach (var item in listDentalToolTranscationDetail)
            {
                if (item != null)
                {
                    int index = dgvDungCu.Rows.Add();
                    dgvDungCu.Rows[index].Cells[0].Value = item.TransactionID;
                    dgvDungCu.Rows[index].Cells[1].Value = item.DentalTool.ToolName;
                    dgvDungCu.Rows[index].Cells[2].Value = item.DentalTool.Unit;
                    dgvDungCu.Rows[index].Cells[3].Value = item.Quantity;
                    dgvDungCu.Rows[index].Cells[4].Value = item.UnitPrice;
                    dgvDungCu.Rows[index].Cells[5].Value = item.TotalAmount;
                }
            }
        }

        private void FillFaculty(List<DentalTool> listDentalTool)
        {
            cmbDungCu.DataSource = listDentalTool;
            cmbDungCu.ValueMember = "ToolID";
            cmbDungCu.DisplayMember = "ToolName";
        }

        public void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }




        private void dgvDungCu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dgvDungCu.Rows[e.RowIndex];
            txtMaGiaoDich.Text = row.Cells[0].Value.ToString();
            cmbDungCu.Text = row.Cells[1].Value.ToString();
            txtDonViTinh.Text = row.Cells[2].Value.ToString();
            txtSoLuong.Text = row.Cells[3].Value.ToString();
            txtDonGia.Text = row.Cells[4].Value.ToString();
            txtThanhTien.Text = row.Cells[5].Value.ToString();
        }



        private void cmbDungCu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDungCu.SelectedIndex != -1)
            {
                DentalTool a = cmbDungCu.SelectedItem as DentalTool;
                txtDonViTinh.Text = a.Unit;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn quay lại trang chủ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void thêmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                checkValid();
                DentalToolTransaction hoadon = dentalToolTransactionService.GetAllDentalToolTransaction(int.Parse(txtMaGiaoDich.Text));
                if (hoadon == null)
                {
                    hoadon = new DentalToolTransaction()
                    {
                        TransactionID = int.Parse(txtMaGiaoDich.Text),
                        TransactionType = (optNhap.Checked) ? false : true,
                        TransactionDate = DateTime.Now,
                        TotalAmount = 0,
                    };
                    dentalToolTransactionService.InsertUpdate(hoadon);
                }
                DentalToolTransactionsDetail phieuHoaDon = new DentalToolTransactionsDetail();
                phieuHoaDon.TransactionID = int.Parse(txtMaGiaoDich.Text);
                phieuHoaDon.ToolID = int.Parse(cmbDungCu.SelectedValue.ToString());
                phieuHoaDon.Unit = txtDonViTinh.Text;
                phieuHoaDon.UnitPrice = decimal.Parse(txtDonGia.Text);
                phieuHoaDon.Quantity = int.Parse(txtSoLuong.Text);
                phieuHoaDon.TotalAmount = 0;
                dentalToolTransactionDetailService.InsertUpdate(phieuHoaDon);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ds = dentalToolTransactionDetailService.GetAllByid(int.Parse(txtMaGiaoDich.Text));
                frmDentalMaterials_Load(sender, e);
                BindGrid(ds);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                checkValid();
                DentalToolTransaction hoadon = dentalToolTransactionService.GetAllDentalToolTransaction(int.Parse(txtMaGiaoDich.Text));
                if (hoadon == null)
                {
                    hoadon = new DentalToolTransaction()
                    {
                        TransactionID = int.Parse(txtMaGiaoDich.Text),
                        TransactionType = (optNhap.Checked) ? false : true,
                        TransactionDate = DateTime.Now,
                        TotalAmount = 0,
                    };
                    dentalToolTransactionService.InsertUpdate(hoadon);
                }
                DentalToolTransactionsDetail phieuHoaDon = new DentalToolTransactionsDetail();
                phieuHoaDon.TransactionID = int.Parse(txtMaGiaoDich.Text);
                phieuHoaDon.ToolID = int.Parse(cmbDungCu.SelectedValue.ToString());
                phieuHoaDon.Unit = txtDonViTinh.Text;
                phieuHoaDon.UnitPrice = decimal.Parse(txtDonGia.Text);
                phieuHoaDon.Quantity = int.Parse(txtSoLuong.Text);
                phieuHoaDon.TotalAmount = 0;
                dentalToolTransactionDetailService.InsertUpdate(phieuHoaDon);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ds = dentalToolTransactionDetailService.GetAllByid(int.Parse(txtMaGiaoDich.Text));
                frmDentalMaterials_Load(sender, e);
                BindGrid(ds);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DentalToolTransactionsDetail sinhvien = dentalToolTransactionDetailService.findDentalToolTransactionDetails(int.Parse(txtMaGiaoDich.Text), int.Parse(cmbDungCu.SelectedValue.ToString()));

                if (sinhvien == null)
                    throw new Exception("Không tìm thấy mã sinh viên cần xóa.");


                DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    dentalToolTransactionDetailService.DeleteById(int.Parse(txtMaGiaoDich.Text), int.Parse(cmbDungCu.SelectedValue.ToString()));
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var ds = dentalToolTransactionDetailService.GetAllByid(int.Parse(txtMaGiaoDich.Text));
                    frmDentalMaterials_Load(sender, e);
                    BindGrid(ds);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentalTool fr = new frmDentalTool();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
        private bool IsInvoiceCheckboxChecked()
        {
            return dgvDungCu.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToBoolean(row.Cells["colMedInvoice"].Value));
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDungCu.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (.pdf)|.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Không thể ghi dữ liệu vào đĩa" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvDungCu.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dgvDungCu.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dgvDungCu.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("In hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xuất hóa đơn" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDungCu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbDungCu.SelectedIndex != -1)
            {
                DentalTool a = cmbDungCu.SelectedItem as DentalTool;
                txtDonViTinh.Text = a.Unit;
                txtDonGia.Text = (optXuat.Checked) ? a.SellingPrice.ToString("0") : a.PurchasedPrice.ToString("0");
            }
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGia.Text) && (!string.IsNullOrEmpty(txtDonGia.Text)))
                txtThanhTien.Text = decimal.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text) + "";
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGia.Text) && (!string.IsNullOrEmpty(txtDonGia.Text)))
                txtThanhTien.Text = decimal.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text) + "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                checkValid();
                DentalToolTransaction hoadon = dentalToolTransactionService.GetAllDentalToolTransaction(int.Parse(txtMaGiaoDich.Text));
                if (hoadon == null)
                {
                    hoadon = new DentalToolTransaction()
                    {
                        TransactionID = int.Parse(txtMaGiaoDich.Text),
                        TransactionType = false,
                        TransactionDate = DateTime.Now,
                        TotalAmount = 0,
                    };
                    dentalToolTransactionService.InsertUpdate(hoadon);
                }
                DentalToolTransactionsDetail phieuHoaDon = new DentalToolTransactionsDetail();
                phieuHoaDon.TransactionID = int.Parse(txtMaGiaoDich.Text);
                phieuHoaDon.ToolID = int.Parse(cmbDungCu.SelectedValue.ToString());
                phieuHoaDon.Unit = txtDonViTinh.Text;
                phieuHoaDon.UnitPrice = decimal.Parse(txtDonGia.Text);
                phieuHoaDon.Quantity = int.Parse(txtSoLuong.Text);
                phieuHoaDon.TotalAmount = 0;
                dentalToolTransactionDetailService.InsertUpdate(phieuHoaDon);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ds = dentalToolTransactionDetailService.GetAllByid(int.Parse(txtMaGiaoDich.Text));
                frmDentalMaterials_Load(sender, e);
                BindGrid(ds);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMaGiaoDich_Leave(object sender, EventArgs e)
        {
            DentalToolTransaction hoadon = dentalToolTransactionService.GetAllDentalToolTransaction(int.Parse(txtMaGiaoDich.Text));
            if (hoadon != null)
            {
                optNhap.Enabled = false;
                optXuat.Enabled = false;
                optNhap.Checked = (hoadon.TransactionType == true) ? true : false;
                optXuat.Checked = (hoadon.TransactionType == true) ? false : true;
                var ds = dentalToolTransactionDetailService.GetAllByid(int.Parse(txtMaGiaoDich.Text));
                BindGrid(ds);
            }
            else
            {
                optNhap.Enabled = true;
                optXuat.Enabled = true;
            }


        }
    }
}
