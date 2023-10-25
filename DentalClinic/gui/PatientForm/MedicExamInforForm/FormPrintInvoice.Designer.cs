namespace gui.PatientForm.MedicExamInforForm
{
    partial class FormPrintInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintInvoice));
            this.lblPatient = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRedLine = new System.Windows.Forms.Label();
            this.dgvClinicalInfor = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIDClinicInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTreatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTreatmentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicalInfor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatient
            // 
            this.lblPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPatient.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPatient.Location = new System.Drawing.Point(0, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(1248, 52);
            this.lblPatient.TabIndex = 3;
            this.lblPatient.Text = "ID | Name";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCheckAll);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblRedLine);
            this.groupBox1.Controls.Add(this.dgvClinicalInfor);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1226, 287);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách điều trị";
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckAll.Location = new System.Drawing.Point(779, 251);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(107, 25);
            this.chkCheckAll.TabIndex = 5;
            this.chkCheckAll.Text = "Chọn tất cả";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(1032, 249);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(170, 29);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(915, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng hóa đơn:";
            // 
            // lblRedLine
            // 
            this.lblRedLine.AutoSize = true;
            this.lblRedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedLine.ForeColor = System.Drawing.Color.Red;
            this.lblRedLine.Location = new System.Drawing.Point(20, 244);
            this.lblRedLine.Name = "lblRedLine";
            this.lblRedLine.Size = new System.Drawing.Size(183, 13);
            this.lblRedLine.TabIndex = 2;
            this.lblRedLine.Text = "Chọn các điều trị muốn xuất hóa đơn";
            // 
            // dgvClinicalInfor
            // 
            this.dgvClinicalInfor.AllowUserToAddRows = false;
            this.dgvClinicalInfor.AllowUserToDeleteRows = false;
            this.dgvClinicalInfor.ColumnHeadersHeight = 30;
            this.dgvClinicalInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnIDClinicInf,
            this.ColumnDiagnosis,
            this.ColumnTreatment,
            this.ColumnTreatmentMethod,
            this.ColumnUnit,
            this.ColumnQuantity,
            this.ColumnUnitPrice,
            this.ColumnTotalAmount,
            this.ColumnDate,
            this.ColumnInvoice});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClinicalInfor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClinicalInfor.Location = new System.Drawing.Point(23, 37);
            this.dgvClinicalInfor.Name = "dgvClinicalInfor";
            this.dgvClinicalInfor.Size = new System.Drawing.Size(1179, 204);
            this.dgvClinicalInfor.TabIndex = 1;
            this.dgvClinicalInfor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClinicalInfor_CellContentClick);
            this.dgvClinicalInfor.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClinicalInfor_CellValueChanged);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "STT";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 45;
            // 
            // ColumnIDClinicInf
            // 
            this.ColumnIDClinicInf.HeaderText = "ID";
            this.ColumnIDClinicInf.Name = "ColumnIDClinicInf";
            this.ColumnIDClinicInf.Visible = false;
            // 
            // ColumnDiagnosis
            // 
            this.ColumnDiagnosis.HeaderText = "Chẩn đoán";
            this.ColumnDiagnosis.Name = "ColumnDiagnosis";
            this.ColumnDiagnosis.ReadOnly = true;
            this.ColumnDiagnosis.Width = 200;
            // 
            // ColumnTreatment
            // 
            this.ColumnTreatment.HeaderText = "Điều Trị";
            this.ColumnTreatment.Name = "ColumnTreatment";
            this.ColumnTreatment.ReadOnly = true;
            this.ColumnTreatment.Width = 125;
            // 
            // ColumnTreatmentMethod
            // 
            this.ColumnTreatmentMethod.HeaderText = "Phương pháp điều trị";
            this.ColumnTreatmentMethod.Name = "ColumnTreatmentMethod";
            this.ColumnTreatmentMethod.ReadOnly = true;
            this.ColumnTreatmentMethod.Width = 175;
            // 
            // ColumnUnit
            // 
            this.ColumnUnit.HeaderText = "Đơn vị tính";
            this.ColumnUnit.Name = "ColumnUnit";
            this.ColumnUnit.ReadOnly = true;
            this.ColumnUnit.Width = 90;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.HeaderText = "Số lượng";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 90;
            // 
            // ColumnUnitPrice
            // 
            this.ColumnUnitPrice.HeaderText = "Đơn giá";
            this.ColumnUnitPrice.Name = "ColumnUnitPrice";
            this.ColumnUnitPrice.ReadOnly = true;
            // 
            // ColumnTotalAmount
            // 
            this.ColumnTotalAmount.HeaderText = "Thành tiền";
            this.ColumnTotalAmount.Name = "ColumnTotalAmount";
            this.ColumnTotalAmount.ReadOnly = true;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Ngày Khám";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 110;
            // 
            // ColumnInvoice
            // 
            this.ColumnInvoice.HeaderText = "Hóa Đơn";
            this.ColumnInvoice.Name = "ColumnInvoice";
            this.ColumnInvoice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInvoice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(472, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Hủy";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(670, 348);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 28);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Xuất";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FormPrintInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 387);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrintInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrintInvoice_FormClosed);
            this.Load += new System.EventHandler(this.FormPrintInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicalInfor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvClinicalInfor;
        private System.Windows.Forms.Label lblRedLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIDClinicInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTreatmentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnInvoice;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCheckAll;
    }
}