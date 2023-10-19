﻿namespace gui.PatientForm.PrescriptionForm
{
    partial class frmPrescription
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
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteMedicine = new System.Windows.Forms.Button();
            this.btnPrintMedicinePrescription = new System.Windows.Forms.Button();
            this.btnAddMedicine = new System.Windows.Forms.Button();
            this.dgvMedicine = new System.Windows.Forms.DataGridView();
            this.colOrdinaNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameOfMedicine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPerSe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.cmbMedicine = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtPricePer = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchingPrescription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(99, 84);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(69, 22);
            this.numQuantity.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Đơn vị tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Thuốc";
            // 
            // btnDeleteMedicine
            // 
            this.btnDeleteMedicine.Location = new System.Drawing.Point(41, 543);
            this.btnDeleteMedicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteMedicine.Name = "btnDeleteMedicine";
            this.btnDeleteMedicine.Size = new System.Drawing.Size(105, 49);
            this.btnDeleteMedicine.TabIndex = 11;
            this.btnDeleteMedicine.Text = "Xóa";
            this.btnDeleteMedicine.UseVisualStyleBackColor = true;
            this.btnDeleteMedicine.Click += new System.EventHandler(this.btnDeleteMedicine_Click);
            // 
            // btnPrintMedicinePrescription
            // 
            this.btnPrintMedicinePrescription.Location = new System.Drawing.Point(183, 454);
            this.btnPrintMedicinePrescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintMedicinePrescription.Name = "btnPrintMedicinePrescription";
            this.btnPrintMedicinePrescription.Size = new System.Drawing.Size(145, 49);
            this.btnPrintMedicinePrescription.TabIndex = 13;
            this.btnPrintMedicinePrescription.Text = "In hóa đơn";
            this.btnPrintMedicinePrescription.UseVisualStyleBackColor = true;
            this.btnPrintMedicinePrescription.Click += new System.EventHandler(this.btnPrintMedicinePrescription_Click);
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.Location = new System.Drawing.Point(41, 432);
            this.btnAddMedicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(105, 49);
            this.btnAddMedicine.TabIndex = 12;
            this.btnAddMedicine.Text = "Thêm";
            this.btnAddMedicine.UseVisualStyleBackColor = true;
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);
            // 
            // dgvMedicine
            // 
            this.dgvMedicine.AllowUserToAddRows = false;
            this.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrdinaNumber,
            this.colNameOfMedicine,
            this.Column1,
            this.colUnit,
            this.colQuantity,
            this.colPrice,
            this.colTotalPerSe});
            this.dgvMedicine.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvMedicine.Location = new System.Drawing.Point(350, 0);
            this.dgvMedicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMedicine.Name = "dgvMedicine";
            this.dgvMedicine.RowHeadersWidth = 51;
            this.dgvMedicine.RowTemplate.Height = 24;
            this.dgvMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicine.Size = new System.Drawing.Size(974, 704);
            this.dgvMedicine.TabIndex = 10;
            this.dgvMedicine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicine_CellClick);
            this.dgvMedicine.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMedicine_RowPostPaint);
            // 
            // colOrdinaNumber
            // 
            this.colOrdinaNumber.HeaderText = "STT";
            this.colOrdinaNumber.MinimumWidth = 6;
            this.colOrdinaNumber.Name = "colOrdinaNumber";
            this.colOrdinaNumber.Width = 50;
            // 
            // colNameOfMedicine
            // 
            this.colNameOfMedicine.HeaderText = "Tên thuốc";
            this.colNameOfMedicine.MinimumWidth = 6;
            this.colNameOfMedicine.Name = "colNameOfMedicine";
            this.colNameOfMedicine.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Liều lượng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "ĐVT";
            this.colUnit.MinimumWidth = 6;
            this.colUnit.Name = "colUnit";
            this.colUnit.Width = 75;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 50;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 125;
            // 
            // colTotalPerSe
            // 
            this.colTotalPerSe.HeaderText = "Thành tiền";
            this.colTotalPerSe.MinimumWidth = 6;
            this.colTotalPerSe.Name = "colTotalPerSe";
            this.colTotalPerSe.Width = 150;
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(99, 129);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(135, 24);
            this.cmbUnit.TabIndex = 8;
            // 
            // cmbMedicine
            // 
            this.cmbMedicine.FormattingEnabled = true;
            this.cmbMedicine.Location = new System.Drawing.Point(99, 27);
            this.cmbMedicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMedicine.Name = "cmbMedicine";
            this.cmbMedicine.Size = new System.Drawing.Size(217, 24);
            this.cmbMedicine.TabIndex = 9;
            this.cmbMedicine.SelectedIndexChanged += new System.EventHandler(this.cmbMedicine_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(41, 487);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 49);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 654);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tổng tiền";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDosage);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtPricePer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbMedicine);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(332, 331);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm thuốc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Liều lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Đơn giá";
            // 
            // txtDosage
            // 
            this.txtDosage.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosage.Location = new System.Drawing.Point(99, 220);
            this.txtDosage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDosage.Multiline = true;
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(188, 85);
            this.txtDosage.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(99, 220);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 27);
            this.textBox2.TabIndex = 20;
            // 
            // txtPricePer
            // 
            this.txtPricePer.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPricePer.Location = new System.Drawing.Point(99, 175);
            this.txtPricePer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPricePer.Name = "txtPricePer";
            this.txtPricePer.Size = new System.Drawing.Size(188, 27);
            this.txtPricePer.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(119, 649);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 27);
            this.textBox1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(158, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 159);
            this.label5.TabIndex = 21;
            // 
            // btnSearchingPrescription
            // 
            this.btnSearchingPrescription.Location = new System.Drawing.Point(183, 518);
            this.btnSearchingPrescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchingPrescription.Name = "btnSearchingPrescription";
            this.btnSearchingPrescription.Size = new System.Drawing.Size(145, 49);
            this.btnSearchingPrescription.TabIndex = 13;
            this.btnSearchingPrescription.Text = "Tìm kiếm";
            this.btnSearchingPrescription.UseVisualStyleBackColor = true;
            this.btnSearchingPrescription.Click += new System.EventHandler(this.btnSearchingPrescription_Click);
            // 
            // frmPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 704);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeleteMedicine);
            this.Controls.Add(this.btnSearchingPrescription);
            this.Controls.Add(this.btnPrintMedicinePrescription);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddMedicine);
            this.Controls.Add(this.dgvMedicine);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPrescription";
            this.Text = "Đơn thuốc";
            this.Load += new System.EventHandler(this.frmPrescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteMedicine;
        private System.Windows.Forms.Button btnPrintMedicinePrescription;
        private System.Windows.Forms.Button btnAddMedicine;
        private System.Windows.Forms.DataGridView dgvMedicine;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.ComboBox cmbMedicine;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPricePer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdinaNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameOfMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPerSe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSearchingPrescription;
    }
}