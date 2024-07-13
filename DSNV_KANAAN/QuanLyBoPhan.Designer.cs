namespace DSNV_KANAAN
{
    partial class QuanLyBoPhan
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstThongTinNV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cblstBP = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbMaBP = new System.Windows.Forms.Label();
            this.lbBP = new System.Windows.Forms.Label();
            this.tbTenBoPhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btImport = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.lstThongTinBP = new System.Windows.Forms.ListView();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(677, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Bộ Phận";
            // 
            // lstThongTinNV
            // 
            this.lstThongTinNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstThongTinNV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstThongTinNV.FullRowSelect = true;
            this.lstThongTinNV.GridLines = true;
            this.lstThongTinNV.HideSelection = false;
            this.lstThongTinNV.Location = new System.Drawing.Point(840, 148);
            this.lstThongTinNV.Name = "lstThongTinNV";
            this.lstThongTinNV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstThongTinNV.Size = new System.Drawing.Size(778, 424);
            this.lstThongTinNV.TabIndex = 1;
            this.lstThongTinNV.UseCompatibleStateImageBehavior = false;
            this.lstThongTinNV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Bộ Phận";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã NV";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên NV";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Chức Vụ";
            this.columnHeader5.Width = 100;
            // 
            // cblstBP
            // 
            this.cblstBP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblstBP.FormattingEnabled = true;
            this.cblstBP.Location = new System.Drawing.Point(171, 26);
            this.cblstBP.Name = "cblstBP";
            this.cblstBP.Size = new System.Drawing.Size(304, 33);
            this.cblstBP.TabIndex = 3;
            this.cblstBP.SelectedIndexChanged += new System.EventHandler(this.cblstBP_SelectedIndexChanged);
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.Location = new System.Drawing.Point(46, 26);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(98, 33);
            this.btSearch.TabIndex = 4;
            this.btSearch.Text = "Tìm Kiếm";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Controls.Add(this.cblstBP);
            this.groupBox1.Location = new System.Drawing.Point(794, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 525);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.lbMaBP);
            this.groupBox2.Controls.Add(this.lbBP);
            this.groupBox2.Controls.Add(this.tbTenBoPhan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(152, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 158);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Bộ Phận";
            // 
            // lbMaBP
            // 
            this.lbMaBP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbMaBP.AutoSize = true;
            this.lbMaBP.Location = new System.Drawing.Point(222, 53);
            this.lbMaBP.Name = "lbMaBP";
            this.lbMaBP.Size = new System.Drawing.Size(23, 16);
            this.lbMaBP.TabIndex = 12;
            this.lbMaBP.Text = "__";
            // 
            // lbBP
            // 
            this.lbBP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbBP.AutoSize = true;
            this.lbBP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBP.Location = new System.Drawing.Point(50, 43);
            this.lbBP.Name = "lbBP";
            this.lbBP.Size = new System.Drawing.Size(126, 28);
            this.lbBP.TabIndex = 11;
            this.lbBP.Text = "Mã Bộ Phận";
            // 
            // tbTenBoPhan
            // 
            this.tbTenBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenBoPhan.Location = new System.Drawing.Point(225, 95);
            this.tbTenBoPhan.Name = "tbTenBoPhan";
            this.tbTenBoPhan.Size = new System.Drawing.Size(267, 30);
            this.tbTenBoPhan.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên Bộ Phận";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btImport);
            this.groupBox3.Controls.Add(this.btExport);
            this.groupBox3.Controls.Add(this.lstThongTinBP);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(152, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 293);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách các bộ phận";
            // 
            // btImport
            // 
            this.btImport.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.Location = new System.Drawing.Point(196, 250);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(151, 23);
            this.btImport.TabIndex = 14;
            this.btImport.Text = "Nhập File Excel";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btExport
            // 
            this.btExport.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExport.Location = new System.Drawing.Point(372, 250);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(151, 23);
            this.btExport.TabIndex = 13;
            this.btExport.Text = "Xuất File Excel";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // lstThongTinBP
            // 
            this.lstThongTinBP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstThongTinBP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lstThongTinBP.FullRowSelect = true;
            this.lstThongTinBP.GridLines = true;
            this.lstThongTinBP.HideSelection = false;
            this.lstThongTinBP.Location = new System.Drawing.Point(39, 36);
            this.lstThongTinBP.Name = "lstThongTinBP";
            this.lstThongTinBP.Size = new System.Drawing.Size(484, 190);
            this.lstThongTinBP.TabIndex = 12;
            this.lstThongTinBP.UseCompatibleStateImageBehavior = false;
            this.lstThongTinBP.View = System.Windows.Forms.View.Details;
            this.lstThongTinBP.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(152, 247);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(136, 46);
            this.btAdd.TabIndex = 12;
            this.btAdd.Text = "Thêm";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(363, 247);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(136, 46);
            this.btDelete.TabIndex = 13;
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.Location = new System.Drawing.Point(568, 248);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(136, 45);
            this.btUpdate.TabIndex = 14;
            this.btUpdate.Text = "Sửa";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.button4_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mã Bộ Phận";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tên Bộ Phận";
            // 
            // QuanLyBoPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 641);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lstThongTinNV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyBoPhan";
            this.Text = "QuanLyBoPhan";
            this.Load += new System.EventHandler(this.QuanLyBoPhan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstThongTinNV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cblstBP;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbTenBoPhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstThongTinBP;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Label lbMaBP;
        private System.Windows.Forms.Label lbBP;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}