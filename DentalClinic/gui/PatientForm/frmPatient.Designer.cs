namespace gui.PatientForm
{
    partial class frmPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatient));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.hiểnThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toànBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đãCóĐơnThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đãTáiKhámToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewPatient = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearching = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditing = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreatingPrescription = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMedicExamInfor = new System.Windows.Forms.ToolStripButton();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHavePrescription = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPurchase = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFunction});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1303, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnFunction
            // 
            this.btnFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiểnThịToolStripMenuItem,
            this.btnAddNew,
            this.toolStripSeparator5,
            this.btnQuit});
            this.btnFunction.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnFunction.Image")));
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(139, 25);
            this.btnFunction.Text = "Chức năng";
            // 
            // hiểnThịToolStripMenuItem
            // 
            this.hiểnThịToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toànBộToolStripMenuItem,
            this.đãCóĐơnThuốcToolStripMenuItem,
            this.đãTáiKhámToolStripMenuItem});
            this.hiểnThịToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hiểnThịToolStripMenuItem.Image")));
            this.hiểnThịToolStripMenuItem.Name = "hiểnThịToolStripMenuItem";
            this.hiểnThịToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.hiểnThịToolStripMenuItem.Text = "Hiển thị";
            // 
            // toànBộToolStripMenuItem
            // 
            this.toànBộToolStripMenuItem.Name = "toànBộToolStripMenuItem";
            this.toànBộToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.toànBộToolStripMenuItem.Text = "Toàn bộ";
            // 
            // đãCóĐơnThuốcToolStripMenuItem
            // 
            this.đãCóĐơnThuốcToolStripMenuItem.Name = "đãCóĐơnThuốcToolStripMenuItem";
            this.đãCóĐơnThuốcToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.đãCóĐơnThuốcToolStripMenuItem.Text = "Đã có đơn thuốc";
            // 
            // đãTáiKhámToolStripMenuItem
            // 
            this.đãTáiKhámToolStripMenuItem.Name = "đãTáiKhámToolStripMenuItem";
            this.đãTáiKhámToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.đãTáiKhámToolStripMenuItem.Text = "Đã tái khám";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(239, 26);
            this.btnAddNew.Text = "Thêm mới       &F1";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(236, 6);
            // 
            // btnQuit
            // 
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(239, 26);
            this.btnQuit.Text = "Thoát               &F6";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewPatient,
            this.toolStripSeparator1,
            this.btnSearching,
            this.toolStripSeparator2,
            this.btnEditing,
            this.toolStripSeparator3,
            this.btnCreatingPrescription,
            this.btnPurchase,
            this.toolStripSeparator4,
            this.btnMedicExamInfor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1303, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewPatient
            // 
            this.btnAddNewPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPatient.Image")));
            this.btnAddNewPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Size = new System.Drawing.Size(100, 24);
            this.btnAddNewPatient.Text = "Thêm mới";
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnSearching
            // 
            this.btnSearching.Image = ((System.Drawing.Image)(resources.GetObject("btnSearching.Image")));
            this.btnSearching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearching.Name = "btnSearching";
            this.btnSearching.Size = new System.Drawing.Size(94, 24);
            this.btnSearching.Text = "Tìm kiếm";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnEditing
            // 
            this.btnEditing.Image = ((System.Drawing.Image)(resources.GetObject("btnEditing.Image")));
            this.btnEditing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditing.Name = "btnEditing";
            this.btnEditing.Size = new System.Drawing.Size(92, 24);
            this.btnEditing.Text = "Cập nhật";
            this.btnEditing.Click += new System.EventHandler(this.btnEditing_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnCreatingPrescription
            // 
            this.btnCreatingPrescription.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatingPrescription.Image")));
            this.btnCreatingPrescription.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreatingPrescription.Name = "btnCreatingPrescription";
            this.btnCreatingPrescription.Size = new System.Drawing.Size(129, 24);
            this.btnCreatingPrescription.Text = "Tạo đơn thuốc";
            this.btnCreatingPrescription.Click += new System.EventHandler(this.btnCreatingPrescription_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnMedicExamInfor
            // 
            this.btnMedicExamInfor.Enabled = false;
            this.btnMedicExamInfor.Image = global::gui.Properties.Resources.examination;
            this.btnMedicExamInfor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMedicExamInfor.Name = "btnMedicExamInfor";
            this.btnMedicExamInfor.Size = new System.Drawing.Size(173, 24);
            this.btnMedicExamInfor.Text = "Thông tin khám bệnh";
            this.btnMedicExamInfor.Click += new System.EventHandler(this.btnMedicExamInfor_Click);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatientID,
            this.colName,
            this.colGender,
            this.colYOB,
            this.colPhoneNumber,
            this.colAddress,
            this.colFirstTime,
            this.colReason,
            this.colHavePrescription});
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPatient.Location = new System.Drawing.Point(0, 83);
            this.dgvPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(1303, 591);
            this.dgvPatient.TabIndex = 3;
            this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
            this.dgvPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellContentClick);
            this.dgvPatient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellDoubleClick);
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "Mã bệnh nhân";
            this.colPatientID.MinimumWidth = 6;
            this.colPatientID.Name = "colPatientID";
            // 
            // colName
            // 
            this.colName.HeaderText = "Họ tên bệnh nhân";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            // 
            // colGender
            // 
            this.colGender.HeaderText = "Giới tính";
            this.colGender.MinimumWidth = 6;
            this.colGender.Name = "colGender";
            // 
            // colYOB
            // 
            this.colYOB.HeaderText = "Ngày sinh";
            this.colYOB.MinimumWidth = 6;
            this.colYOB.Name = "colYOB";
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.HeaderText = "Số điện thoại";
            this.colPhoneNumber.MinimumWidth = 6;
            this.colPhoneNumber.Name = "colPhoneNumber";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            // 
            // colFirstTime
            // 
            this.colFirstTime.HeaderText = "Lần đầu khám";
            this.colFirstTime.MinimumWidth = 6;
            this.colFirstTime.Name = "colFirstTime";
            // 
            // colReason
            // 
            this.colReason.HeaderText = "Lý do khám";
            this.colReason.MinimumWidth = 6;
            this.colReason.Name = "colReason";
            // 
            // colHavePrescription
            // 
            this.colHavePrescription.HeaderText = "Đã có đơn thuốc?";
            this.colHavePrescription.MinimumWidth = 6;
            this.colHavePrescription.Name = "colHavePrescription";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchase.Image")));
            this.btnPurchase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(178, 24);
            this.btnPurchase.Text = "Thanh toán đơn thuốc";
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // frmPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 674);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPatient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPatient_FormClosed);
            this.Load += new System.EventHandler(this.frmPatient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPatient_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnFunction;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNewPatient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSearching;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEditing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCreatingPrescription;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem hiểnThịToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toànBộToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đãCóĐơnThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đãTáiKhámToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAddNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.ToolStripButton btnMedicExamInfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHavePrescription;
        private System.Windows.Forms.ToolStripButton btnPurchase;
    }
}