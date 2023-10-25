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
            this.btnAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewPatient = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditing = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreatingPrescription = new System.Windows.Forms.ToolStripButton();
            this.btnPurchase = new System.Windows.Forms.ToolStripButton();
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
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // btnFunction
            // 
            this.btnFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.toolStripSeparator5,
            this.btnQuit});
            resources.ApplyResources(this.btnFunction, "btnFunction");
            this.btnFunction.Name = "btnFunction";
            // 
            // btnAddNew
            // 
            resources.ApplyResources(this.btnAddNew, "btnAddNew");
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // btnQuit
            // 
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewPatient,
            this.toolStripSeparator1,
            this.btnEditing,
            this.toolStripSeparator3,
            this.btnCreatingPrescription,
            this.btnPurchase,
            this.toolStripSeparator4,
            this.btnMedicExamInfor});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnAddNewPatient
            // 
            resources.ApplyResources(this.btnAddNewPatient, "btnAddNewPatient");
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnEditing
            // 
            resources.ApplyResources(this.btnEditing, "btnEditing");
            this.btnEditing.Name = "btnEditing";
            this.btnEditing.Click += new System.EventHandler(this.btnEditing_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnCreatingPrescription
            // 
            resources.ApplyResources(this.btnCreatingPrescription, "btnCreatingPrescription");
            this.btnCreatingPrescription.Name = "btnCreatingPrescription";
            this.btnCreatingPrescription.Click += new System.EventHandler(this.btnCreatingPrescription_Click);
            // 
            // btnPurchase
            // 
            resources.ApplyResources(this.btnPurchase, "btnPurchase");
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // btnMedicExamInfor
            // 
            resources.ApplyResources(this.btnMedicExamInfor, "btnMedicExamInfor");
            this.btnMedicExamInfor.Image = global::gui.Properties.Resources.examination;
            this.btnMedicExamInfor.Name = "btnMedicExamInfor";
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
            resources.ApplyResources(this.dgvPatient, "dgvPatient");
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
            this.dgvPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellContentClick);
            // 
            // colPatientID
            // 
            resources.ApplyResources(this.colPatientID, "colPatientID");
            this.colPatientID.Name = "colPatientID";
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.Name = "colName";
            // 
            // colGender
            // 
            resources.ApplyResources(this.colGender, "colGender");
            this.colGender.Name = "colGender";
            // 
            // colYOB
            // 
            resources.ApplyResources(this.colYOB, "colYOB");
            this.colYOB.Name = "colYOB";
            // 
            // colPhoneNumber
            // 
            resources.ApplyResources(this.colPhoneNumber, "colPhoneNumber");
            this.colPhoneNumber.Name = "colPhoneNumber";
            // 
            // colAddress
            // 
            resources.ApplyResources(this.colAddress, "colAddress");
            this.colAddress.Name = "colAddress";
            // 
            // colFirstTime
            // 
            resources.ApplyResources(this.colFirstTime, "colFirstTime");
            this.colFirstTime.Name = "colFirstTime";
            // 
            // colReason
            // 
            resources.ApplyResources(this.colReason, "colReason");
            this.colReason.Name = "colReason";
            // 
            // colHavePrescription
            // 
            resources.ApplyResources(this.colHavePrescription, "colHavePrescription");
            this.colHavePrescription.Name = "colHavePrescription";
            // 
            // frmPatient
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "frmPatient";
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
        private System.Windows.Forms.ToolStripButton btnEditing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCreatingPrescription;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
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