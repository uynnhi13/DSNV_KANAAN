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
    public partial class frmLstTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;
        string sql;
        SqlDataAdapter dp;
        public frmLstTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmLstTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            DataTable dt=new DataTable();

            thuchien = new SqlCommand("GetTaiKhoan", ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;

            using(dp=new SqlDataAdapter(thuchien))
            {
                dp.Fill(dt);
            }

            dgvTaiKhoan.DataSource = dt;

            // Tự động điều chỉnh kích thước cột cho nội dung
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tự động điều chỉnh kích thước hàng cho nội dung
            dgvTaiKhoan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Lấp đầy chiều rộng của DataGridView
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}