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

            sql = @"select Ten as 'Nhóm Người Phân Quyền', MoTa as 'Mô Tả' FROM PHANQUYEN";
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

            // Thiết lập chế độ xuống hàng cho cột "Mô Tả"
            dgvLstPhanQuyen.Columns["Mô Tả"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            

        }

        //Khi nhấp vào thì sẽ thay đổi giá trị trong dgvMenu
        private void dgvLstPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btEdit.Text == "Lưu")
            {
                KiemTraDuLieu();
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô được nhấp
                object cellValue = dgvLstPhanQuyen.Rows[e.RowIndex].Cells[0].Value;

                // Gán giá trị vào Label, kiểm tra nếu giá trị không null
                lbPhanQuyen.Text = cellValue != null ? cellValue.ToString() : string.Empty;
            }

            TaiPhanQuyen();
        }


        private void KiemTraDuLieu()
        {
            DialogResult dgl=MessageBox.Show("Bạn có muốn lưu thay đổi không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dgl==DialogResult.Yes)
            {
                LuuDuLieu();
            }

            btEdit.Text = "Chỉnh Sửa";
        }

        private void dgvMenuPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void TaiPhanQuyen()
        {
            DataTable dt = new DataTable();
            ketnoi.Open();
            thuchien = new SqlCommand("HienThiThongTinPhanQuyen", ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;

            thuchien.Parameters.AddWithValue("@role", lbPhanQuyen.Text);

            using (dp = new SqlDataAdapter(thuchien))
            {
                dp.Fill(dt);
            }

            ketnoi.Close();

            dgvMenuPhanQuyen.DataSource = dt;
            // Tự động điều chỉnh kích thước cột cho nội dung
            dgvMenuPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tự động điều chỉnh kích thước hàng cho nội dung
            dgvMenuPhanQuyen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Lấp đầy chiều rộng của DataGridView
            dgvMenuPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn column in dgvMenuPhanQuyen.Columns)
            {
                if (column.ValueType == typeof(bool))
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if(btEdit.Text=="Chỉnh Sửa")
            {
                btEdit.Text = "Lưu";
                foreach(DataGridViewColumn column in dgvMenuPhanQuyen.Columns)
                {
                    if (column.ValueType == typeof(bool))
                    {
                        column.ReadOnly = false;
                    }
                }
            }
            else
            {
                LuuDuLieu();
                btEdit.Text = "Chỉnh Sửa";
            }
        }

        private void LuuDuLieu()
        {
            try
            {
                ketnoi.Open();

                foreach (DataGridViewRow row in dgvMenuPhanQuyen.Rows)
                {
                    if (row.IsNewRow) continue;


                    thuchien = new SqlCommand("UpdatePhanQuyen", ketnoi);
                    thuchien.CommandType = CommandType.StoredProcedure;

                    thuchien.Parameters.AddWithValue("@role", lbPhanQuyen.Text);
                    thuchien.Parameters.AddWithValue("@PhanQuyen", row.Cells[0].Value);
                    thuchien.Parameters.AddWithValue("@canCreate", row.Cells[1].Value);
                    thuchien.Parameters.AddWithValue("@canDelete", row.Cells[2].Value);
                    thuchien.Parameters.AddWithValue("@canRead", row.Cells[3].Value);
                    thuchien.Parameters.AddWithValue("@canUpdate", row.Cells[4].Value);

                    thuchien.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                ketnoi.Close();
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            frmTaoMoiPhanQuyen frmTaoMoi=new frmTaoMoiPhanQuyen();
            frmTaoMoi.ShowDialog();
        }
    }
}