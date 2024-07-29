namespace DSNV_KANAAN
{
    partial class QLPhanQuyen
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
            this.dgvLstPhanQuyen = new System.Windows.Forms.DataGridView();
            this.dgvMenuPhanQuyen = new System.Windows.Forms.DataGridView();
            this.lbPhanQuyen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btCreate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLstPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuPhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLstPhanQuyen
            // 
            this.dgvLstPhanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvLstPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLstPhanQuyen.Location = new System.Drawing.Point(81, 92);
            this.dgvLstPhanQuyen.Name = "dgvLstPhanQuyen";
            this.dgvLstPhanQuyen.RowHeadersWidth = 51;
            this.dgvLstPhanQuyen.RowTemplate.Height = 24;
            this.dgvLstPhanQuyen.Size = new System.Drawing.Size(399, 286);
            this.dgvLstPhanQuyen.TabIndex = 0;
            this.dgvLstPhanQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLstPhanQuyen_CellContentClick);
            // 
            // dgvMenuPhanQuyen
            // 
            this.dgvMenuPhanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvMenuPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuPhanQuyen.Location = new System.Drawing.Point(486, 128);
            this.dgvMenuPhanQuyen.Name = "dgvMenuPhanQuyen";
            this.dgvMenuPhanQuyen.RowHeadersWidth = 51;
            this.dgvMenuPhanQuyen.RowTemplate.Height = 24;
            this.dgvMenuPhanQuyen.Size = new System.Drawing.Size(608, 250);
            this.dgvMenuPhanQuyen.TabIndex = 1;
            this.dgvMenuPhanQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuPhanQuyen_CellContentClick);
            // 
            // lbPhanQuyen
            // 
            this.lbPhanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPhanQuyen.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhanQuyen.Appearance.Options.UseFont = true;
            this.lbPhanQuyen.Location = new System.Drawing.Point(486, 92);
            this.lbPhanQuyen.Margin = new System.Windows.Forms.Padding(5);
            this.lbPhanQuyen.Name = "lbPhanQuyen";
            this.lbPhanQuyen.Size = new System.Drawing.Size(0, 28);
            this.lbPhanQuyen.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(458, 14);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(323, 45);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Quản Lý Phân Quyền";
            // 
            // btEdit
            // 
            this.btEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btEdit.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Appearance.Options.UseFont = true;
            this.btEdit.Location = new System.Drawing.Point(972, 396);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(122, 34);
            this.btEdit.TabIndex = 4;
            this.btEdit.Text = "Chỉnh Sửa";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btCreate
            // 
            this.btCreate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCreate.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreate.Appearance.Options.UseFont = true;
            this.btCreate.Location = new System.Drawing.Point(81, 396);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(91, 33);
            this.btCreate.TabIndex = 5;
            this.btCreate.Text = "Tạo Mới";
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // QLPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 499);
            this.ControlBox = false;
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbPhanQuyen);
            this.Controls.Add(this.dgvMenuPhanQuyen);
            this.Controls.Add(this.dgvLstPhanQuyen);
            this.Name = "QLPhanQuyen";
            this.Load += new System.EventHandler(this.QLPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLstPhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuPhanQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLstPhanQuyen;
        private System.Windows.Forms.DataGridView dgvMenuPhanQuyen;
        private DevExpress.XtraEditors.LabelControl lbPhanQuyen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btEdit;
        private DevExpress.XtraEditors.SimpleButton btCreate;
    }
}