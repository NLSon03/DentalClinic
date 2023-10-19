namespace gui.DentalForm
{
    partial class frmDentalTool
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
            this.dgvDentalTool = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExitDentalTool = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaDungCu = new System.Windows.Forms.TextBox();
            this.txtTenDungCu = new System.Windows.Forms.TextBox();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThemDentalTool = new System.Windows.Forms.Button();
            this.btnSuaDentalTool = new System.Windows.Forms.Button();
            this.btnXoaDentalTool = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentalTool)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDentalTool
            // 
            this.dgvDentalTool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDentalTool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDentalTool.Location = new System.Drawing.Point(438, 23);
            this.dgvDentalTool.Name = "dgvDentalTool";
            this.dgvDentalTool.RowHeadersWidth = 51;
            this.dgvDentalTool.RowTemplate.Height = 24;
            this.dgvDentalTool.Size = new System.Drawing.Size(841, 455);
            this.dgvDentalTool.TabIndex = 0;
            this.dgvDentalTool.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDentalTool_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã dụng cụ";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên dụng cụ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Đơn vị tính";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số lượng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // btnExitDentalTool
            // 
            this.btnExitDentalTool.Location = new System.Drawing.Point(1164, 498);
            this.btnExitDentalTool.Name = "btnExitDentalTool";
            this.btnExitDentalTool.Size = new System.Drawing.Size(115, 42);
            this.btnExitDentalTool.TabIndex = 1;
            this.btnExitDentalTool.Text = "Quay lại";
            this.btnExitDentalTool.UseVisualStyleBackColor = true;
            this.btnExitDentalTool.Click += new System.EventHandler(this.btnExitDentalTool_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã dụng cụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên dụng cụ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số lượng";
            // 
            // txtMaDungCu
            // 
            this.txtMaDungCu.Location = new System.Drawing.Point(149, 64);
            this.txtMaDungCu.Name = "txtMaDungCu";
            this.txtMaDungCu.Size = new System.Drawing.Size(209, 22);
            this.txtMaDungCu.TabIndex = 3;
            // 
            // txtTenDungCu
            // 
            this.txtTenDungCu.Location = new System.Drawing.Point(149, 135);
            this.txtTenDungCu.Name = "txtTenDungCu";
            this.txtTenDungCu.Size = new System.Drawing.Size(209, 22);
            this.txtTenDungCu.TabIndex = 3;
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(149, 214);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(209, 22);
            this.txtDonViTinh.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(149, 291);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(209, 22);
            this.txtSoLuong.TabIndex = 3;
            // 
            // btnThemDentalTool
            // 
            this.btnThemDentalTool.Location = new System.Drawing.Point(25, 455);
            this.btnThemDentalTool.Name = "btnThemDentalTool";
            this.btnThemDentalTool.Size = new System.Drawing.Size(89, 55);
            this.btnThemDentalTool.TabIndex = 4;
            this.btnThemDentalTool.Text = "Thêm";
            this.btnThemDentalTool.UseVisualStyleBackColor = true;
            this.btnThemDentalTool.Click += new System.EventHandler(this.btnThemDentalTool_Click);
            // 
            // btnSuaDentalTool
            // 
            this.btnSuaDentalTool.Location = new System.Drawing.Point(149, 455);
            this.btnSuaDentalTool.Name = "btnSuaDentalTool";
            this.btnSuaDentalTool.Size = new System.Drawing.Size(89, 55);
            this.btnSuaDentalTool.TabIndex = 4;
            this.btnSuaDentalTool.Text = "Sửa";
            this.btnSuaDentalTool.UseVisualStyleBackColor = true;
            this.btnSuaDentalTool.Click += new System.EventHandler(this.btnSuaDentalTool_Click);
            // 
            // btnXoaDentalTool
            // 
            this.btnXoaDentalTool.Location = new System.Drawing.Point(269, 455);
            this.btnXoaDentalTool.Name = "btnXoaDentalTool";
            this.btnXoaDentalTool.Size = new System.Drawing.Size(89, 55);
            this.btnXoaDentalTool.TabIndex = 4;
            this.btnXoaDentalTool.Text = "Xóa";
            this.btnXoaDentalTool.UseVisualStyleBackColor = true;
            this.btnXoaDentalTool.Click += new System.EventHandler(this.btnXoaDentalTool_Click);
            // 
            // frmDentalTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 565);
            this.Controls.Add(this.btnXoaDentalTool);
            this.Controls.Add(this.btnSuaDentalTool);
            this.Controls.Add(this.btnThemDentalTool);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.txtTenDungCu);
            this.Controls.Add(this.txtMaDungCu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExitDentalTool);
            this.Controls.Add(this.dgvDentalTool);
            this.Name = "frmDentalTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDentalTool";
            this.Load += new System.EventHandler(this.frmDentalTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentalTool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDentalTool;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnExitDentalTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaDungCu;
        private System.Windows.Forms.TextBox txtTenDungCu;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThemDentalTool;
        private System.Windows.Forms.Button btnSuaDentalTool;
        private System.Windows.Forms.Button btnXoaDentalTool;
    }
}