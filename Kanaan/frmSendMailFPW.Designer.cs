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
            this.tbGmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btSend = new Guna.UI2.WinForms.Guna2Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txpass = new DevExpress.XtraEditors.LabelControl();
            this.tbPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbPass2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbGmail
            // 
            this.tbGmail.BorderRadius = 10;
            this.tbGmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbGmail.DefaultText = "";
            this.tbGmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbGmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbGmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbGmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbGmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbGmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbGmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbGmail.Location = new System.Drawing.Point(117, 100);
            this.tbGmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbGmail.Name = "tbGmail";
            this.tbGmail.PasswordChar = '\0';
            this.tbGmail.PlaceholderText = "";
            this.tbGmail.SelectedText = "";
            this.tbGmail.Size = new System.Drawing.Size(584, 48);
            this.tbGmail.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(314, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(206, 38);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Quên Mật Khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(122, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(182, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Vui lòng nhập gmail của bạn";
            // 
            // btSend
            // 
            this.btSend.BorderRadius = 10;
            this.btSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSend.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.White;
            this.btSend.Location = new System.Drawing.Point(325, 423);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(180, 45);
            this.btSend.TabIndex = 3;
            this.btSend.Text = "Gửi";
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(122, 162);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Nhập OTP";
            // 
            // tbOTP
            // 
            this.tbOTP.BorderRadius = 10;
            this.tbOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOTP.DefaultText = "";
            this.tbOTP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOTP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOTP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbOTP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOTP.Location = new System.Drawing.Point(117, 187);
            this.tbOTP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.PasswordChar = '\0';
            this.tbOTP.PlaceholderText = "";
            this.tbOTP.SelectedText = "";
            this.tbOTP.Size = new System.Drawing.Size(584, 48);
            this.tbOTP.TabIndex = 4;
            // 
            // txpass
            // 
            this.txpass.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txpass.Appearance.Options.UseFont = true;
            this.txpass.Location = new System.Drawing.Point(122, 245);
            this.txpass.Name = "txpass";
            this.txpass.Size = new System.Drawing.Size(90, 18);
            this.txpass.TabIndex = 7;
            this.txpass.Text = "Mật Khẩu Mới";
            // 
            // tbPass
            // 
            this.tbPass.BorderRadius = 10;
            this.tbPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPass.DefaultText = "";
            this.tbPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass.Location = new System.Drawing.Point(117, 270);
            this.tbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '\0';
            this.tbPass.PlaceholderText = "";
            this.tbPass.SelectedText = "";
            this.tbPass.Size = new System.Drawing.Size(584, 48);
            this.tbPass.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(122, 326);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(145, 18);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Xác nhận lại mật khẩu";
            // 
            // tbPass2
            // 
            this.tbPass2.BorderRadius = 10;
            this.tbPass2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPass2.DefaultText = "";
            this.tbPass2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPass2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPass2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPass2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass2.Location = new System.Drawing.Point(117, 351);
            this.tbPass2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '\0';
            this.tbPass2.PlaceholderText = "";
            this.tbPass2.SelectedText = "";
            this.tbPass2.Size = new System.Drawing.Size(584, 48);
            this.tbPass2.TabIndex = 8;
            // 
            // btSave
            // 
            this.btSave.BorderRadius = 10;
            this.btSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.White;
            this.btSave.Location = new System.Drawing.Point(325, 423);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(180, 45);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "Xác nhận";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmSendMailFPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 501);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.tbPass2);
            this.Controls.Add(this.txpass);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.tbOTP);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbGmail);
            this.Name = "frmSendMailFPW";
            this.Text = "Quên mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbGmail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Guna.UI2.WinForms.Guna2Button btSend;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Guna.UI2.WinForms.Guna2TextBox tbOTP;
        private DevExpress.XtraEditors.LabelControl txpass;
        private Guna.UI2.WinForms.Guna2TextBox tbPass;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private Guna.UI2.WinForms.Guna2TextBox tbPass2;
        private Guna.UI2.WinForms.Guna2Button btSave;
    }
}