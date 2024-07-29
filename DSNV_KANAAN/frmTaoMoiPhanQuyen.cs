using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSNV_KANAAN
{
    public partial class frmTaoMoiPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoMoiPhanQuyen()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.Open();
                thuchien = new SqlCommand("CreatePhanQuyen", ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;

                thuchien.Parameters.AddWithValue("@Ten", txVaiTro.Text);
                thuchien.Parameters.AddWithValue("@MoTa", txMoTa.Text);

                thuchien.ExecuteNonQuery();
                MessageBox.Show("Đã tạo vai trò người dùng mới thành công");
                this.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ketnoi.Close();
            }
        }

        
    }
}