namespace Kanaan
{
    partial class frmSendMailFPW
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
            this.tbTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btSend = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.BorderRadius = 10;
            this.tbTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTaiKhoan.DefaultText = "";
            this.tbTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTaiKhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTaiKhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbTaiKhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTaiKhoan.Location = new System.Drawing.Point(123, 105);
            this.tbTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.PasswordChar = '\0';
            this.tbTaiKhoan.PlaceholderText = "";
            this.tbTaiKhoan.SelectedText = "";
            this.tbTaiKhoan.Size = new System.Drawing.Size(229, 48);
            this.tbTaiKhoan.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(171, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(134, 25);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Quên Mật Khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(129, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(217, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Vui lòng nhập tên người dùng của bạn";
            // 
            // btSend
            // 
            this.btSend.BorderRadius = 10;
            this.btSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSend.ForeColor = System.Drawing.Color.White;
            this.btSend.Location = new System.Drawing.Point(195, 165);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(80, 38);
            this.btSend.TabIndex = 3;
            this.btSend.Text = "Gửi";
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // frmSendMailFPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 257);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbTaiKhoan);
            this.Name = "frmSendMailFPW";
            this.Text = "Gửi Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbTaiKhoan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Guna.UI2.WinForms.Guna2Button btSend;
    }
}