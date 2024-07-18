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
    public partial class QLPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;
        SqlDataAdapter dp;
        string sql;
        public QLPhanQuyen()
        {
            InitializeComponent();
        }

        private void QLPhanQuyen_Load(object sender, EventArgs e)
        {
            HienThiRole();
        }

        private void HienThiRole()
        {
            DataTable dt= new DataTable();

            sql = @"select Ten as 'Nhóm Người Phân Quyền' FROM PHANQUYEN";
            thuchien = new SqlCommand(sql, ketnoi);
            using(dp=new SqlDataAdapter(thuchien))
            {
                dp.Fill(dt);
            }

            dgvLstPhanQuyen.DataSource = dt;

            // Tự động điều chỉnh kích thước cột cho nội dung
            dgvLstPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tự động điều chỉnh kích thước hàng cho nội dung
            dgvLstPhanQuyen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Lấp đầy chiều rộng của DataGridView
            dgvLstPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvLstPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô được nhấp
                object cellValue = dgvLstPhanQuyen.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Gán giá trị vào Label, kiểm tra nếu giá trị không null
                lbPhanQuyen.Text = cellValue != null ? cellValue.ToString() : string.Empty;
            }
        }
    }
}