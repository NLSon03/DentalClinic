using System.Drawing;
using System.Windows.Forms;

namespace DentalClinic
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDentalMaterial = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnPatientManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(633, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(587, 257);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "THOÁT";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDentalMaterial
            // 
            this.btnDentalMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDentalMaterial.Font = new System.Drawing.Font("Arial", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDentalMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnDentalMaterial.Image")));
            this.btnDentalMaterial.Location = new System.Drawing.Point(633, 30);
            this.btnDentalMaterial.Name = "btnDentalMaterial";
            this.btnDentalMaterial.Size = new System.Drawing.Size(587, 257);
            this.btnDentalMaterial.TabIndex = 0;
            this.btnDentalMaterial.Text = "QUẢN LÝ VẬT LIỆU, DỤNG CỤ NHA KHOA";
            this.btnDentalMaterial.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDentalMaterial.UseVisualStyleBackColor = true;
            this.btnDentalMaterial.Click += new System.EventHandler(this.btnDentalMaterial_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStatistics.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistics.Image")));
            this.btnStatistics.Location = new System.Drawing.Point(30, 371);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(587, 257);
            this.btnStatistics.TabIndex = 0;
            this.btnStatistics.Text = "THỐNG KÊ";
            this.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStatistics.UseVisualStyleBackColor = true;
            /*this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);*/
            // 
            // btnPatientManager
            // 
            this.btnPatientManager.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientManager.Image = ((System.Drawing.Image)(resources.GetObject("btnPatientManager.Image")));
            this.btnPatientManager.Location = new System.Drawing.Point(30, 30);
            this.btnPatientManager.Name = "btnPatientManager";
            this.btnPatientManager.Size = new System.Drawing.Size(587, 257);
            this.btnPatientManager.TabIndex = 0;
            this.btnPatientManager.Text = "QUẢN LÝ BỆNH NHÂN";
            this.btnPatientManager.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPatientManager.UseVisualStyleBackColor = true;
            this.btnPatientManager.Click += new System.EventHandler(this.btnPatientManager_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDentalMaterial);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnPatientManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ PHÒNG KHÁM NHA KHOA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDentalMaterial;
        private System.Windows.Forms.Button btnPatientManager;
        private System.Windows.Forms.Button btnStatistics;
    }
}

