namespace gui.StatisticForm.InventoryStatisticForm
{
    partial class frmInventoryStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryStatistic));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhapxuat = new System.Windows.Forms.TabPage();
            this.dgvNhapXuat = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.optXuat = new System.Windows.Forms.RadioButton();
            this.optNhap = new System.Windows.Forms.RadioButton();
            this.btnLamMoifrm1 = new System.Windows.Forms.Button();
            this.btnLocfrm1 = new System.Windows.Forms.Button();
            this.btnXuatfrm1 = new System.Windows.Forms.Button();
            this.lbTongXuat = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.optNamfrm1 = new System.Windows.Forms.RadioButton();
            this.optQuyfrm1 = new System.Windows.Forms.RadioButton();
            this.optThangfrm1 = new System.Windows.Forms.RadioButton();
            this.datNgayKT1 = new System.Windows.Forms.DateTimePicker();
            this.datNgayBD1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTongNhap = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabDungcu = new System.Windows.Forms.TabPage();
            this.dgvDungcu = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.optXuatfrm2 = new System.Windows.Forms.RadioButton();
            this.optNhapfrm2 = new System.Windows.Forms.RadioButton();
            this.btnLamMoifrm2 = new System.Windows.Forms.Button();
            this.btnLocfrm2 = new System.Windows.Forms.Button();
            this.btnXuatfrm2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.optNamfrm2 = new System.Windows.Forms.RadioButton();
            this.optQuyfrm2 = new System.Windows.Forms.RadioButton();
            this.optThangfrm2 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lbVatlieuxuat = new System.Windows.Forms.Label();
            this.lbVatlieunhap = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabNhapxuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapXuat)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabDungcu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDungcu)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhapxuat);
            this.tabControl1.Controls.Add(this.tabDungcu);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1202, 673);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabNhapxuat
            // 
            this.tabNhapxuat.Controls.Add(this.dgvNhapXuat);
            this.tabNhapxuat.Controls.Add(this.panel1);
            this.tabNhapxuat.Location = new System.Drawing.Point(4, 27);
            this.tabNhapxuat.Name = "tabNhapxuat";
            this.tabNhapxuat.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhapxuat.Size = new System.Drawing.Size(1194, 642);
            this.tabNhapxuat.TabIndex = 0;
            this.tabNhapxuat.Text = "Thống kê theo hóa đơn";
            this.tabNhapxuat.UseVisualStyleBackColor = true;
            // 
            // dgvNhapXuat
            // 
            this.dgvNhapXuat.AllowUserToAddRows = false;
            this.dgvNhapXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvNhapXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhapXuat.Location = new System.Drawing.Point(3, 169);
            this.dgvNhapXuat.Name = "dgvNhapXuat";
            this.dgvNhapXuat.RowHeadersWidth = 51;
            this.dgvNhapXuat.RowTemplate.Height = 24;
            this.dgvNhapXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhapXuat.Size = new System.Drawing.Size(1188, 470);
            this.dgvNhapXuat.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Loại";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên vật liệu";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số lượng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Đơn giá";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Thành tiền";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Ngày";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnLamMoifrm1);
            this.panel1.Controls.Add(this.btnLocfrm1);
            this.panel1.Controls.Add(this.btnXuatfrm1);
            this.panel1.Controls.Add(this.lbTongXuat);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.optNamfrm1);
            this.panel1.Controls.Add(this.optQuyfrm1);
            this.panel1.Controls.Add(this.optThangfrm1);
            this.panel1.Controls.Add(this.datNgayKT1);
            this.panel1.Controls.Add(this.datNgayBD1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbTongNhap);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 166);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.optXuat);
            this.panel2.Controls.Add(this.optNhap);
            this.panel2.Location = new System.Drawing.Point(1033, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 63);
            this.panel2.TabIndex = 19;
            // 
            // optXuat
            // 
            this.optXuat.AutoSize = true;
            this.optXuat.Location = new System.Drawing.Point(3, 38);
            this.optXuat.Name = "optXuat";
            this.optXuat.Size = new System.Drawing.Size(82, 22);
            this.optXuat.TabIndex = 1;
            this.optXuat.TabStop = true;
            this.optXuat.Text = "Chỉ xuất";
            this.optXuat.UseVisualStyleBackColor = true;
            this.optXuat.CheckedChanged += new System.EventHandler(this.optXuat_CheckedChanged);
            // 
            // optNhap
            // 
            this.optNhap.AutoSize = true;
            this.optNhap.Location = new System.Drawing.Point(3, 3);
            this.optNhap.Name = "optNhap";
            this.optNhap.Size = new System.Drawing.Size(87, 22);
            this.optNhap.TabIndex = 0;
            this.optNhap.TabStop = true;
            this.optNhap.Text = "Chỉ nhập";
            this.optNhap.UseVisualStyleBackColor = true;
            this.optNhap.CheckedChanged += new System.EventHandler(this.optNhap_CheckedChanged);
            // 
            // btnLamMoifrm1
            // 
            this.btnLamMoifrm1.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoifrm1.Image")));
            this.btnLamMoifrm1.Location = new System.Drawing.Point(641, 5);
            this.btnLamMoifrm1.Name = "btnLamMoifrm1";
            this.btnLamMoifrm1.Size = new System.Drawing.Size(109, 50);
            this.btnLamMoifrm1.TabIndex = 18;
            this.btnLamMoifrm1.Text = "Làm mới";
            this.btnLamMoifrm1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLamMoifrm1.UseVisualStyleBackColor = true;
            this.btnLamMoifrm1.Click += new System.EventHandler(this.btnLamMoifrm1_Click);
            // 
            // btnLocfrm1
            // 
            this.btnLocfrm1.Image = ((System.Drawing.Image)(resources.GetObject("btnLocfrm1.Image")));
            this.btnLocfrm1.Location = new System.Drawing.Point(526, 5);
            this.btnLocfrm1.Name = "btnLocfrm1";
            this.btnLocfrm1.Size = new System.Drawing.Size(109, 50);
            this.btnLocfrm1.TabIndex = 17;
            this.btnLocfrm1.Text = "Lọc";
            this.btnLocfrm1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLocfrm1.UseVisualStyleBackColor = true;
            this.btnLocfrm1.Click += new System.EventHandler(this.btnLocfrm1_Click);
            // 
            // btnXuatfrm1
            // 
            this.btnXuatfrm1.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatfrm1.Image")));
            this.btnXuatfrm1.Location = new System.Drawing.Point(1033, 12);
            this.btnXuatfrm1.Name = "btnXuatfrm1";
            this.btnXuatfrm1.Size = new System.Drawing.Size(121, 50);
            this.btnXuatfrm1.TabIndex = 16;
            this.btnXuatfrm1.Text = "Xuất Excel";
            this.btnXuatfrm1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnXuatfrm1.UseVisualStyleBackColor = true;
            this.btnXuatfrm1.Click += new System.EventHandler(this.btnXuatfrm1_Click);
            // 
            // lbTongXuat
            // 
            this.lbTongXuat.AutoSize = true;
            this.lbTongXuat.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongXuat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTongXuat.Location = new System.Drawing.Point(858, 128);
            this.lbTongXuat.Name = "lbTongXuat";
            this.lbTongXuat.Size = new System.Drawing.Size(19, 28);
            this.lbTongXuat.TabIndex = 15;
            this.lbTongXuat.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(858, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 18);
            this.label14.TabIndex = 14;
            this.label14.Text = "Tổng tiền xuất";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(849, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(3, 80);
            this.label9.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "-";
            // 
            // optNamfrm1
            // 
            this.optNamfrm1.AutoSize = true;
            this.optNamfrm1.Location = new System.Drawing.Point(387, 3);
            this.optNamfrm1.Name = "optNamfrm1";
            this.optNamfrm1.Size = new System.Drawing.Size(96, 22);
            this.optNamfrm1.TabIndex = 8;
            this.optNamfrm1.TabStop = true;
            this.optNamfrm1.Text = "Theo năm";
            this.optNamfrm1.UseVisualStyleBackColor = true;
            this.optNamfrm1.CheckedChanged += new System.EventHandler(this.optNamfrm1_CheckedChanged);
            // 
            // optQuyfrm1
            // 
            this.optQuyfrm1.AutoSize = true;
            this.optQuyfrm1.Location = new System.Drawing.Point(210, 3);
            this.optQuyfrm1.Name = "optQuyfrm1";
            this.optQuyfrm1.Size = new System.Drawing.Size(90, 22);
            this.optQuyfrm1.TabIndex = 7;
            this.optQuyfrm1.TabStop = true;
            this.optQuyfrm1.Text = "Theo quý";
            this.optQuyfrm1.UseVisualStyleBackColor = true;
            this.optQuyfrm1.CheckedChanged += new System.EventHandler(this.optQuyfrm1_CheckedChanged);
            // 
            // optThangfrm1
            // 
            this.optThangfrm1.AutoSize = true;
            this.optThangfrm1.Location = new System.Drawing.Point(42, 3);
            this.optThangfrm1.Name = "optThangfrm1";
            this.optThangfrm1.Size = new System.Drawing.Size(103, 22);
            this.optThangfrm1.TabIndex = 6;
            this.optThangfrm1.TabStop = true;
            this.optThangfrm1.Text = "Theo tháng";
            this.optThangfrm1.UseVisualStyleBackColor = true;
            this.optThangfrm1.CheckedChanged += new System.EventHandler(this.optThangfrm1_CheckedChanged);
            // 
            // datNgayKT1
            // 
            this.datNgayKT1.Location = new System.Drawing.Point(283, 31);
            this.datNgayKT1.Name = "datNgayKT1";
            this.datNgayKT1.Size = new System.Drawing.Size(200, 24);
            this.datNgayKT1.TabIndex = 5;
            this.datNgayKT1.ValueChanged += new System.EventHandler(this.datNgayKT1_ValueChanged);
            // 
            // datNgayBD1
            // 
            this.datNgayBD1.Location = new System.Drawing.Point(11, 31);
            this.datNgayBD1.Name = "datNgayBD1";
            this.datNgayBD1.Size = new System.Drawing.Size(200, 24);
            this.datNgayBD1.TabIndex = 4;
            this.datNgayBD1.ValueChanged += new System.EventHandler(this.datNgayBD1_ValueChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(421, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 80);
            this.label2.TabIndex = 3;
            // 
            // lbTongNhap
            // 
            this.lbTongNhap.AutoSize = true;
            this.lbTongNhap.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongNhap.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTongNhap.Location = new System.Drawing.Point(430, 128);
            this.lbTongNhap.Name = "lbTongNhap";
            this.lbTongNhap.Size = new System.Drawing.Size(19, 28);
            this.lbTongNhap.TabIndex = 2;
            this.lbTongNhap.Text = "-";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTongTien.Location = new System.Drawing.Point(8, 128);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(19, 28);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tổng tiền nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tổng tiền";
            // 
            // tabDungcu
            // 
            this.tabDungcu.Controls.Add(this.dgvDungcu);
            this.tabDungcu.Controls.Add(this.panel3);
            this.tabDungcu.Location = new System.Drawing.Point(4, 27);
            this.tabDungcu.Name = "tabDungcu";
            this.tabDungcu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDungcu.Size = new System.Drawing.Size(1194, 642);
            this.tabDungcu.TabIndex = 1;
            this.tabDungcu.Text = "Thống kê theo dụng cụ";
            this.tabDungcu.UseVisualStyleBackColor = true;
            // 
            // dgvDungcu
            // 
            this.dgvDungcu.AllowUserToAddRows = false;
            this.dgvDungcu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDungcu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column8});
            this.dgvDungcu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDungcu.Location = new System.Drawing.Point(3, 169);
            this.dgvDungcu.Name = "dgvDungcu";
            this.dgvDungcu.RowHeadersWidth = 51;
            this.dgvDungcu.RowTemplate.Height = 24;
            this.dgvDungcu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDungcu.Size = new System.Drawing.Size(1188, 470);
            this.dgvDungcu.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên vật liệu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Số lượng đã nhập";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Số lượng đã xuất";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Số lượng tồn";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lần update cuối";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btnLamMoifrm2);
            this.panel3.Controls.Add(this.btnLocfrm2);
            this.panel3.Controls.Add(this.btnXuatfrm2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.optNamfrm2);
            this.panel3.Controls.Add(this.optQuyfrm2);
            this.panel3.Controls.Add(this.optThangfrm2);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lbVatlieuxuat);
            this.panel3.Controls.Add(this.lbVatlieunhap);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1188, 166);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.optXuatfrm2);
            this.panel4.Controls.Add(this.optNhapfrm2);
            this.panel4.Location = new System.Drawing.Point(1033, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 63);
            this.panel4.TabIndex = 19;
            // 
            // optXuatfrm2
            // 
            this.optXuatfrm2.AutoSize = true;
            this.optXuatfrm2.Location = new System.Drawing.Point(3, 38);
            this.optXuatfrm2.Name = "optXuatfrm2";
            this.optXuatfrm2.Size = new System.Drawing.Size(82, 22);
            this.optXuatfrm2.TabIndex = 1;
            this.optXuatfrm2.TabStop = true;
            this.optXuatfrm2.Text = "Chỉ xuất";
            this.optXuatfrm2.UseVisualStyleBackColor = true;
            this.optXuatfrm2.CheckedChanged += new System.EventHandler(this.optXuatfrm2_CheckedChanged);
            // 
            // optNhapfrm2
            // 
            this.optNhapfrm2.AutoSize = true;
            this.optNhapfrm2.Location = new System.Drawing.Point(3, 3);
            this.optNhapfrm2.Name = "optNhapfrm2";
            this.optNhapfrm2.Size = new System.Drawing.Size(87, 22);
            this.optNhapfrm2.TabIndex = 0;
            this.optNhapfrm2.TabStop = true;
            this.optNhapfrm2.Text = "Chỉ nhập";
            this.optNhapfrm2.UseVisualStyleBackColor = true;
            this.optNhapfrm2.CheckedChanged += new System.EventHandler(this.optNhapfrm2_CheckedChanged);
            // 
            // btnLamMoifrm2
            // 
            this.btnLamMoifrm2.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoifrm2.Image")));
            this.btnLamMoifrm2.Location = new System.Drawing.Point(641, 5);
            this.btnLamMoifrm2.Name = "btnLamMoifrm2";
            this.btnLamMoifrm2.Size = new System.Drawing.Size(109, 50);
            this.btnLamMoifrm2.TabIndex = 18;
            this.btnLamMoifrm2.Text = "Làm mới";
            this.btnLamMoifrm2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLamMoifrm2.UseVisualStyleBackColor = true;
            this.btnLamMoifrm2.Click += new System.EventHandler(this.btnLamMoifrm2_Click);
            // 
            // btnLocfrm2
            // 
            this.btnLocfrm2.Image = ((System.Drawing.Image)(resources.GetObject("btnLocfrm2.Image")));
            this.btnLocfrm2.Location = new System.Drawing.Point(526, 5);
            this.btnLocfrm2.Name = "btnLocfrm2";
            this.btnLocfrm2.Size = new System.Drawing.Size(109, 50);
            this.btnLocfrm2.TabIndex = 17;
            this.btnLocfrm2.Text = "Lọc";
            this.btnLocfrm2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLocfrm2.UseVisualStyleBackColor = true;
            this.btnLocfrm2.Click += new System.EventHandler(this.btnLocfrm2_Click);
            // 
            // btnXuatfrm2
            // 
            this.btnXuatfrm2.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatfrm2.Image")));
            this.btnXuatfrm2.Location = new System.Drawing.Point(1033, 12);
            this.btnXuatfrm2.Name = "btnXuatfrm2";
            this.btnXuatfrm2.Size = new System.Drawing.Size(121, 50);
            this.btnXuatfrm2.TabIndex = 16;
            this.btnXuatfrm2.Text = "Xuất Excel";
            this.btnXuatfrm2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnXuatfrm2.UseVisualStyleBackColor = true;
            this.btnXuatfrm2.Click += new System.EventHandler(this.btnXuatfrm2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "-";
            // 
            // optNamfrm2
            // 
            this.optNamfrm2.AutoSize = true;
            this.optNamfrm2.Location = new System.Drawing.Point(387, 3);
            this.optNamfrm2.Name = "optNamfrm2";
            this.optNamfrm2.Size = new System.Drawing.Size(96, 22);
            this.optNamfrm2.TabIndex = 8;
            this.optNamfrm2.TabStop = true;
            this.optNamfrm2.Text = "Theo năm";
            this.optNamfrm2.UseVisualStyleBackColor = true;
            this.optNamfrm2.CheckedChanged += new System.EventHandler(this.optNamfrm2_CheckedChanged);
            // 
            // optQuyfrm2
            // 
            this.optQuyfrm2.AutoSize = true;
            this.optQuyfrm2.Location = new System.Drawing.Point(210, 3);
            this.optQuyfrm2.Name = "optQuyfrm2";
            this.optQuyfrm2.Size = new System.Drawing.Size(90, 22);
            this.optQuyfrm2.TabIndex = 7;
            this.optQuyfrm2.TabStop = true;
            this.optQuyfrm2.Text = "Theo quý";
            this.optQuyfrm2.UseVisualStyleBackColor = true;
            this.optQuyfrm2.CheckedChanged += new System.EventHandler(this.optQuyfrm2_CheckedChanged);
            // 
            // optThangfrm2
            // 
            this.optThangfrm2.AutoSize = true;
            this.optThangfrm2.Location = new System.Drawing.Point(42, 3);
            this.optThangfrm2.Name = "optThangfrm2";
            this.optThangfrm2.Size = new System.Drawing.Size(103, 22);
            this.optThangfrm2.TabIndex = 6;
            this.optThangfrm2.TabStop = true;
            this.optThangfrm2.Text = "Theo tháng";
            this.optThangfrm2.UseVisualStyleBackColor = true;
            this.optThangfrm2.CheckedChanged += new System.EventHandler(this.optThangfrm2_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(283, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(11, 31);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(421, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 80);
            this.label10.TabIndex = 3;
            // 
            // lbVatlieuxuat
            // 
            this.lbVatlieuxuat.AutoSize = true;
            this.lbVatlieuxuat.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVatlieuxuat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbVatlieuxuat.Location = new System.Drawing.Point(430, 128);
            this.lbVatlieuxuat.Name = "lbVatlieuxuat";
            this.lbVatlieuxuat.Size = new System.Drawing.Size(19, 28);
            this.lbVatlieuxuat.TabIndex = 2;
            this.lbVatlieuxuat.Text = "-";
            // 
            // lbVatlieunhap
            // 
            this.lbVatlieunhap.AutoSize = true;
            this.lbVatlieunhap.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVatlieunhap.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbVatlieunhap.Location = new System.Drawing.Point(8, 128);
            this.lbVatlieunhap.Name = "lbVatlieunhap";
            this.lbVatlieunhap.Size = new System.Drawing.Size(19, 28);
            this.lbVatlieunhap.TabIndex = 1;
            this.lbVatlieunhap.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Tổng vật liệu đã xuất";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 18);
            this.label15.TabIndex = 0;
            this.label15.Text = "Tổng vật liệu đã nhập";
            // 
            // frmInventoryStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 673);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmInventoryStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInventoryStatistic";
            this.tabControl1.ResumeLayout(false);
            this.tabNhapxuat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapXuat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabDungcu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDungcu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhapxuat;
        private System.Windows.Forms.TabPage tabDungcu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLamMoifrm1;
        private System.Windows.Forms.Button btnLocfrm1;
        private System.Windows.Forms.Button btnXuatfrm1;
        private System.Windows.Forms.Label lbTongXuat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optNamfrm1;
        private System.Windows.Forms.RadioButton optQuyfrm1;
        private System.Windows.Forms.RadioButton optThangfrm1;
        private System.Windows.Forms.DateTimePicker datNgayKT1;
        private System.Windows.Forms.DateTimePicker datNgayBD1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTongNhap;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvNhapXuat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton optXuat;
        private System.Windows.Forms.RadioButton optNhap;
        private System.Windows.Forms.DataGridView dgvDungcu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton optXuatfrm2;
        private System.Windows.Forms.RadioButton optNhapfrm2;
        private System.Windows.Forms.Button btnLamMoifrm2;
        private System.Windows.Forms.Button btnLocfrm2;
        private System.Windows.Forms.Button btnXuatfrm2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton optNamfrm2;
        private System.Windows.Forms.RadioButton optQuyfrm2;
        private System.Windows.Forms.RadioButton optThangfrm2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbVatlieuxuat;
        private System.Windows.Forms.Label lbVatlieunhap;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}