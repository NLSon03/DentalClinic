﻿namespace gui.PatientForm.MedicExamInforForm
{
    partial class FormDeleteInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeleteInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowAbleDeleteInvoice = new System.Windows.Forms.CheckBox();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDropInvoice = new System.Windows.Forms.Button();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTypeInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeteleInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDrop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowAbleDeleteInvoice);
            this.groupBox1.Controls.Add(this.dgvInvoice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 208);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hủy Hóa Đơn";
            // 
            // chkShowAbleDeleteInvoice
            // 
            this.chkShowAbleDeleteInvoice.AutoSize = true;
            this.chkShowAbleDeleteInvoice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAbleDeleteInvoice.Location = new System.Drawing.Point(554, 16);
            this.chkShowAbleDeleteInvoice.Name = "chkShowAbleDeleteInvoice";
            this.chkShowAbleDeleteInvoice.Size = new System.Drawing.Size(212, 24);
            this.chkShowAbleDeleteInvoice.TabIndex = 2;
            this.chkShowAbleDeleteInvoice.Text = "Chỉ hiện hóa đơn có thể hủy";
            this.chkShowAbleDeleteInvoice.UseVisualStyleBackColor = true;
            this.chkShowAbleDeleteInvoice.CheckedChanged += new System.EventHandler(this.chkShowAbleDeleteInvoice_CheckedChanged);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.Id,
            this.ColumnClient,
            this.ColumnTypeInvoice,
            this.ColumnTotalAmount,
            this.ColumnDeteleInvoice,
            this.ColumnDrop});
            this.dgvInvoice.Location = new System.Drawing.Point(9, 43);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.Size = new System.Drawing.Size(760, 136);
            this.dgvInvoice.TabIndex = 1;
            this.dgvInvoice.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInvoice_CellBeginEdit);
            this.dgvInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInvoice_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Không thể hủy các hóa đơn đã xuất hơn 03 ngày";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(254, 216);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Quay Lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDropInvoice
            // 
            this.btnDropInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropInvoice.Location = new System.Drawing.Point(443, 216);
            this.btnDropInvoice.Name = "btnDropInvoice";
            this.btnDropInvoice.Size = new System.Drawing.Size(110, 30);
            this.btnDropInvoice.TabIndex = 6;
            this.btnDropInvoice.Text = "Hủy";
            this.btnDropInvoice.UseVisualStyleBackColor = true;
            this.btnDropInvoice.Click += new System.EventHandler(this.btnDropInvoice_Click);
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Ngày Lập";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 90;
            // 
            // Id
            // 
            this.Id.HeaderText = "Mã HĐ";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 80;
            // 
            // ColumnClient
            // 
            this.ColumnClient.HeaderText = "Khách Hàng";
            this.ColumnClient.Name = "ColumnClient";
            this.ColumnClient.ReadOnly = true;
            this.ColumnClient.Width = 150;
            // 
            // ColumnTypeInvoice
            // 
            this.ColumnTypeInvoice.HeaderText = "Loại Hóa Đơn";
            this.ColumnTypeInvoice.Name = "ColumnTypeInvoice";
            this.ColumnTypeInvoice.ReadOnly = true;
            this.ColumnTypeInvoice.Width = 120;
            // 
            // ColumnTotalAmount
            // 
            this.ColumnTotalAmount.HeaderText = "Tổng Giá Trị";
            this.ColumnTotalAmount.Name = "ColumnTotalAmount";
            this.ColumnTotalAmount.ReadOnly = true;
            this.ColumnTotalAmount.Width = 120;
            // 
            // ColumnDeteleInvoice
            // 
            this.ColumnDeteleInvoice.HeaderText = "Trạng Thái";
            this.ColumnDeteleInvoice.Name = "ColumnDeteleInvoice";
            this.ColumnDeteleInvoice.ReadOnly = true;
            // 
            // ColumnDrop
            // 
            this.ColumnDrop.HeaderText = "Hủy";
            this.ColumnDrop.Name = "ColumnDrop";
            this.ColumnDrop.ReadOnly = true;
            this.ColumnDrop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDrop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDrop.Width = 50;
            // 
            // FormDeleteInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 250);
            this.Controls.Add(this.btnDropInvoice);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDeleteInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hủy Hóa Đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDeleteInvoice_FormClosed);
            this.Load += new System.EventHandler(this.FormDeleteInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.CheckBox chkShowAbleDeleteInvoice;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDropInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTypeInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeteleInvoice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDrop;
    }
}