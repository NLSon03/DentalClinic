using bus;
using dal.Entities;
using DentalClinic;
using gui.PatientForm.MedicExamInforForm;
using gui.PatientForm.PrescriptionForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace gui.PatientForm
{
    public partial class frmPatient : Form
    {

        PatientInformationService patientInformationService = new PatientInformationService();

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
            foreach(var item in patients)
            {
                dgvPatient.Rows.Add(item.PatientID,item.FullName,item.Gender,"","","","","");
            }
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(this.dgvPatient);
                var ListPatient =  patientInformationService.GetAll();
                BindGrid(ListPatient);

            }
            catch(Exception ex)
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
            if (e.KeyCode == Keys.F1)
            {

            }
        }
        private void OpenPrescriptionForm()
        {
            frmPrescription f = new frmPrescription();
            f.ShowDialog();
        }
        private void btnCreatingPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                //  foreach(DataGridViewRow r in dgvPatient.Rows)
                //  {
                //    if (dgvPatient.Rows[r.Index].Cells[8].Value == null)
                //   {
                OpenPrescriptionForm();
                // }
                // else
                //  {
                //      string s = string.Format("Bệnh nhân đã có đơn thuốc.\n Vui lòng chọn bệnh nhân khác");
                //     throw new Exception(s);
                //  }

                //}
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
                btnMedicExamInfor.Enabled = true;
        }

    }
}
