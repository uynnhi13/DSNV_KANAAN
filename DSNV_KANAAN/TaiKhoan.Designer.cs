namespace DSNV_KANAAN
{
    partial class TaiKhoan
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.tbTenDN = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btExist = new System.Windows.Forms.Button();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.groupControl1.Controls.Add(this.tbMK);
            this.groupControl1.Controls.Add(this.tbTenDN);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(99, 91);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(670, 265);
            this.groupControl1.TabIndex = 0;
            // 
            // tbMK
            // 
            this.tbMK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK.Location = new System.Drawing.Point(298, 140);
            this.tbMK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(289, 34);
            this.tbMK.TabIndex = 3;
            // 
            // tbTenDN
            // 
            this.tbTenDN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDN.Location = new System.Drawing.Point(298, 69);
            this.tbTenDN.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbTenDN.Name = "tbTenDN";
            this.tbTenDN.Size = new System.Drawing.Size(289, 34);
            this.tbTenDN.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(51, 145);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(87, 28);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật Khẩu";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(51, 78);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(141, 28);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên Đăng Nhập";
            // 
            // btExist
            // 
            this.btExist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btExist.Location = new System.Drawing.Point(682, 390);
            this.btExist.Name = "btExist";
            this.btExist.Size = new System.Drawing.Size(87, 51);
            this.btExist.TabIndex = 1;
            this.btExist.Text = "Trở Về";
            this.btExist.UseVisualStyleBackColor = true;
            this.btExist.Click += new System.EventHandler(this.btExist_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSave.Location = new System.Drawing.Point(575, 390);
            this.btSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(87, 50);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Lưu";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Appearance.Options.UseFont = true;
            this.lbTitle.Location = new System.Drawing.Point(314, 34);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(193, 31);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "Tạo Tài Khoản Mới";
            // 
            // TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 482);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExist);
            this.Controls.Add(this.groupControl1);
            this.Name = "TaiKhoan";
            this.Text = "THÔNG TIN TÀI KHOẢN";
            this.Load += new System.EventHandler(this.TaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.TextBox tbTenDN;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btExist;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl lbTitle;
    }
}