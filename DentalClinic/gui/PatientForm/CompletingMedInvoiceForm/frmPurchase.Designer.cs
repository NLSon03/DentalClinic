namespace gui.PatientForm.CompletingMedInvoiceForm
{
    partial class frmPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.dgvMed = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTIme = new System.Windows.Forms.Label();
            this.lblIDAndName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lưuHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintMed = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMed
            // 
            this.dgvMed.AllowUserToAddRows = false;
            this.dgvMed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.colId,
            this.Column1,
            this.colMedInvoice});
            this.dgvMed.Location = new System.Drawing.Point(0, 276);
            this.dgvMed.Name = "dgvMed";
            this.dgvMed.RowHeadersWidth = 51;
            this.dgvMed.RowTemplate.Height = 24;
            this.dgvMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMed.Size = new System.Drawing.Size(1352, 187);
            this.dgvMed.TabIndex = 0;
            this.dgvMed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMed_CellContentClick);
            this.dgvMed.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMed_CellValueChanged);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 106.9519F;
            this.Column3.HeaderText = "STT";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // colId
            // 
            this.colId.FillWeight = 97.68271F;
            this.colId.HeaderText = "Mã đơn thuốc";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 97.68271F;
            this.Column1.HeaderText = "Số tiền";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // colMedInvoice
            // 
            this.colMedInvoice.HeaderText = "Hóa đơn";
            this.colMedInvoice.MinimumWidth = 6;
            this.colMedInvoice.Name = "colMedInvoice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTIme);
            this.groupBox1.Controls.Add(this.lblIDAndName);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1261, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // lblTIme
            // 
            this.lblTIme.AutoSize = true;
            this.lblTIme.Location = new System.Drawing.Point(806, 45);
            this.lblTIme.Name = "lblTIme";
            this.lblTIme.Size = new System.Drawing.Size(124, 19);
            this.lblTIme.TabIndex = 0;
            this.lblTIme.Text = "                       ";
            // 
            // lblIDAndName
            // 
            this.lblIDAndName.AutoSize = true;
            this.lblIDAndName.Location = new System.Drawing.Point(47, 45);
            this.lblIDAndName.Name = "lblIDAndName";
            this.lblIDAndName.Size = new System.Drawing.Size(124, 19);
            this.lblIDAndName.TabIndex = 0;
            this.lblIDAndName.Text = "                       ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(536, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "THANH TOÁN HÓA ĐƠN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lưuHóaĐơnToolStripMenuItem,
            this.btnPrintMed,
            this.btnQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1352, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lưuHóaĐơnToolStripMenuItem
            // 
            this.lưuHóaĐơnToolStripMenuItem.Name = "lưuHóaĐơnToolStripMenuItem";
            this.lưuHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.lưuHóaĐơnToolStripMenuItem.Text = "Lưu hóa đơn";
            this.lưuHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.lưuHóaĐơnToolStripMenuItem_Click);
            // 
            // btnPrintMed
            // 
            this.btnPrintMed.Name = "btnPrintMed";
            this.btnPrintMed.Size = new System.Drawing.Size(94, 24);
            this.btnPrintMed.Text = "In hóa đơn";
            this.btnPrintMed.Click += new System.EventHandler(this.btnPrintMed_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.btnQuit.Size = new System.Drawing.Size(61, 24);
            this.btnQuit.Text = "Thoát";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(43, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn hóa đơn muốn xuất";
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMed);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPurchase";
            this.Text = "Thanh toán hóa đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPurchase_FormClosed);
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIDAndName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lưuHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnPrintMed;
        private System.Windows.Forms.Label lblTIme;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMedInvoice;
    }
}