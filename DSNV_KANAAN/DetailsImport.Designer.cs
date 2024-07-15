namespace DSNV_KANAAN
{
    partial class DetailsImport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveDB = new System.Windows.Forms.Button();
            this.btExist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(499, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "DỮ LIỆU IMPORT TỪ FILE EXCEL";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(111, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1252, 364);
            this.dataGridView1.TabIndex = 2;
            // 
            // saveDB
            // 
            this.saveDB.Location = new System.Drawing.Point(1206, 465);
            this.saveDB.Name = "saveDB";
            this.saveDB.Size = new System.Drawing.Size(157, 43);
            this.saveDB.TabIndex = 3;
            this.saveDB.Text = "Lưu Dữ Liệu Vào Database";
            this.saveDB.UseVisualStyleBackColor = true;
            this.saveDB.Click += new System.EventHandler(this.saveDB_Click);
            // 
            // btExist
            // 
            this.btExist.Location = new System.Drawing.Point(1034, 465);
            this.btExist.Name = "btExist";
            this.btExist.Size = new System.Drawing.Size(157, 43);
            this.btExist.TabIndex = 4;
            this.btExist.Text = "Thoát";
            this.btExist.UseVisualStyleBackColor = true;
            // 
            // DetailsImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 589);
            this.Controls.Add(this.btExist);
            this.Controls.Add(this.saveDB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "DetailsImport";
            this.Text = "DetailsImport";
            this.Load += new System.EventHandler(this.DetailsImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button saveDB;
        private System.Windows.Forms.Button btExist;
    }
}