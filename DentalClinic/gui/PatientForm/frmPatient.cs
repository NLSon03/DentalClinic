using bus;
using dal.Entities;
using DentalClinic;
using gui.PatientForm.CompletingMedInvoiceForm;
using gui.PatientForm.MedicExamInforForm;
using gui.PatientForm.PrescriptionForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmPatient : Form
    {

        PatientInformationService patientInformationService = new PatientInformationService();
        frmPatient patient;
        public DataGridView dgv;
        //set style cho bảng
        public void setGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public frmPatient()
        {
            InitializeComponent();
            dgv = dgvPatient;
            patient = this;
        }
        private void ReopenMainForm()
        {
            MainForm main = new MainForm();
            main.ShowDialog();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReopenMainForm));
            thread.Start();
            this.Close();
        }
        //Nhập thông tin bệnh nhân vào bảng
        private void BindGrid(List<PatientInformation> patients)
        {
            dgvPatient.Rows.Clear();
            foreach (var item in patients)
            {
                int index = dgvPatient.Rows.Add();
                dgvPatient.Rows[index].Cells[0].Value = item.PatientID;
                dgvPatient.Rows[index].Cells[1].Value = item.FullName;
                if (item.Gender == true)
                {
                    dgvPatient.Rows[index].Cells[2].Value = "Nam";
                }
                else if (item.Gender == false)
                {
                    dgvPatient.Rows[index].Cells[2].Value = "Nữ";
                }

                dgvPatient.Rows[index].Cells[3].Value = item.YearOfBirth;
                dgvPatient.Rows[index].Cells[4].Value = item.PhoneNumber;
                dgvPatient.Rows[index].Cells[5].Value = item.Address;
                if (item.FirstExaminationDate == null)
                {
                    dgvPatient.Rows[index].Cells[6].Value = "";
                }
                else
                    dgvPatient.Rows[index].Cells[6].Value = item.FirstExaminationDate;
                dgvPatient.Rows[index].Cells[7].Value = item.ReasonForExamination;

                /*dgvPatient.Rows.Add(item.PatientID, item.FullName, item.Gender,item.YearOfBirth, item.PhoneNumber,
                    item.Address, item.FirstExaminationDate, item.ReasonForExamination);*/
            }
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            try
            {
                btnCreatingPrescription.Enabled = false;
                //btnPurchase.Enabled = false;
                setGridViewStyle(this.dgvPatient);
                var ListPatient = patientInformationService.GetAll();
                BindGrid(ListPatient);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                Thread t = new Thread(start: new ThreadStart(ReopenMainForm));
                t.Start();
                this.Close();
            }
            if(e.KeyCode == Keys.F1)
            {
                btnAddNewPatient.PerformClick();
            }
        }
        private void OpenPrescriptionForm()
        {
            frmPrescription f = new frmPrescription();
            foreach (DataGridViewRow r in dgvPatient.Rows)
            {
                if (r.Selected)
                {
                    f.p_id = int.Parse(r.Cells[0].Value.ToString());
                }
            }
            f.ShowDialog();
        }
        private void btnCreatingPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvPatient.Rows)
                {
                    if (r.Selected)
                    {
                        if (dgvPatient.Rows[r.Index].Cells[8].Value == null)
                        {
                            OpenPrescriptionForm();
                        }
                        else
                        {
                            string s = string.Format("Bệnh nhân đã có đơn thuốc.\n Vui lòng chọn bệnh nhân khác");
                            throw new Exception(s);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReopenMainForm));
            thread.Start();
            this.Close();
        }

        //Mở Form thông tin khám bệnh
        private void btnMedicExamInfor_Click(object sender, EventArgs e)
        {
            //Nếu có bệnh nhân trong bảng đươc chọn
            if (dgvPatient.SelectedRows.Count > 0)
            {
                //Truyền mã bệnh nhân được chọn sang frmMedicExamInfor
                string _PatientID = dgvPatient.SelectedRows[0].Cells[0].Value.ToString();

                frmMedicExamInfor frmMedicExamInfo = new frmMedicExamInfor();
                frmMedicExamInfo._PatientID = _PatientID;
                //Hiển thị form
                frmMedicExamInfo.ShowDialog();
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nút xem thông tin khám bệnh chỉ enable khi có một bệnh nhân được chọn
            if (dgvPatient.SelectedRows.Count > 0)
            {
                btnMedicExamInfor.Enabled = true;
                btnCreatingPrescription.Enabled = true;
                foreach (DataGridViewRow r in dgvPatient.Rows)
                {
                    if (Convert.ToBoolean(r.Cells[8].Value))
                    {
                        btnPurchase.Enabled = true;
                    }
                }
            }
        }
        public void ReloadPatientList()
        {
            List<PatientInformation> list = patientInformationService.GetAll();
            BindGrid(list);
        }
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            frmNewPatient newPatient = new frmNewPatient();
            newPatient.ShowDialog();
        }

        private void btnEditing_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPatient.Rows)
            {
                if (row.Selected)
                {
                    frmAnnoucement annouce = new frmAnnoucement();
                    annouce.ShowDialog();
                    if (annouce.isClicked == true)
                    {
                        frmEditInfo frmEdit = new frmEditInfo();
                        frmEdit.txt1.Text = dgvPatient.Rows[row.Index].Cells[1].Value.ToString();
                        frmEdit.txt2.Text = dgvPatient.Rows[row.Index].Cells[4].Value.ToString();
                        frmEdit.txt3.Text = dgvPatient.Rows[row.Index].Cells[5].Value.ToString();
                        frmEdit.txt4.Text = dgvPatient.Rows[row.Index].Cells[7].Value.ToString();
                        frmEdit.datetime1.Value = DateTime.Parse(dgvPatient.Rows[row.Index].Cells[3].Value.ToString());
                        if (dgvPatient.Rows[row.Index].Cells[2].Value.ToString() == "Nữ")
                        {
                            frmEdit.rb1.Checked = false;
                            frmEdit.rb2.Checked = true;
                        }
                        else if (dgvPatient.Rows[row.Index].Cells[2].Value.ToString() == "Nam")
                        {
                            frmEdit.rb1.Checked = true;
                            frmEdit.rb2.Checked = false;
                        }
                        if (dgvPatient.Rows[row.Index].Cells[6].Value != null)
                        {
                            frmEdit.chk1.Checked = true;
                            frmEdit.datetime2.Value = DateTime.Parse(dgvPatient.Rows[row.Index].Cells[6].Value.ToString());
                        }
                        else if (dgvPatient.Rows[row.Index].Cells[6].Value == null)
                        {
                            frmEdit.chk1.Checked = false;
                        }
                        frmEdit.ShowDialog();
                    }
                    else if (annouce.isClicked == false)
                    {
                        try
                        {
                            DialogResult d = MessageBox.Show("Bạn có muốn xóa bệnh nhân này?","Thông báo",
                                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if(d == DialogResult.Yes)
                            {
                                patientInformationService.DeletePatient(dgvPatient.Rows[row.Index].Cells[0].Value.ToString());
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPatient.RefreshEdit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNewPatient_Click(sender, e);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvPatient.Rows)
            {
                if (r.Selected)
                {
                    if (Convert.ToBoolean(r.Cells[8].Value) == false)
                    {
                        btnPurchase.Enabled = true;
                        frmPurchase purchase = new frmPurchase();
                        purchase.ID_p = int.Parse(r.Cells[0].Value.ToString());
                        purchase.ShowDialog();
                    }
                }
            }
        }
    }
}
