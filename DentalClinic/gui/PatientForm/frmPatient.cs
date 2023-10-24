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
            foreach(DataGridViewRow r in dgvPatient.Rows )
            {
                if (r.Selected)
                {
                    f.p_id = int.Parse(r.Cells[0].Value.ToString());
                    if (r.Cells[8].Value == null)
                    {
                        f.remainChecked = false;
                    }
                    else
                        f.remainChecked = true;
                }
            }
            f.ShowDialog();
        }
        private void btnCreatingPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                //  foreach(DataGridViewRow r in dgvPatient.Rows)
                //  {
                //      if(row.Selected)
                //      {
                //              if (dgvPatient.Rows[r.Index].Cells[8].Value == null)
                                    OpenPrescriptionForm();
                // 
                //              else
                //              {
                //                  string s = string.Format("Bệnh nhân đã có đơn thuốc.\n Vui lòng chọn bệnh nhân khác");
                //                  throw new Exception(s);
                //              }
                //      }
                //  }

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

        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dgvPatient.Rows)
            {
                if(row.Selected) 
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
                        frmEdit.datetime1.Value = DateTime.ParseExact(dgvPatient.Rows[row.Index].Cells[3].Value.ToString(),
                            "dd--MM--yyyy",System.Globalization.CultureInfo.InvariantCulture);
                        if ((bool)dgvPatient.Rows[row.Index].Cells[2].Value == false)
                        {
                            frmEdit.rb1.Checked = false;
                            frmEdit.rb2.Checked = true;
                        }
                        else if ((bool)dgvPatient.Rows[row.Index].Cells[2].Value == true)
                        {
                            frmEdit.rb1.Checked = true;
                            frmEdit.rb2.Checked = false;
                        }
                        if(dgvPatient.Rows[row.Index].Cells[6].Value != null)
                        {
                            frmEdit.chk1.Checked = true;
                            frmEdit.datetime1.Value = DateTime.ParseExact(dgvPatient.Rows[row.Index].Cells[6].Value.ToString(),
                            "dd--MM--yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else if (dgvPatient.Rows[row.Index].Cells[6].Value == null)
                        {
                            frmEdit.chk1.Checked = false;
                        }
                        frmEdit.ShowDialog();
                    }
                }
            }
        }
    }
}
