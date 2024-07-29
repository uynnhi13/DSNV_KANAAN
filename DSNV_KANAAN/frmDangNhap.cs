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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private int KiemTraDangNhap(string tenDangNhap, string pass)
        {
            ketnoi.Open();

            thuchien = new SqlCommand("KiemTraTaiKhoan", ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;

            thuchien.Parameters.AddWithValue("@tendangnhap", txTenDangNhap.Text);
            thuchien.Parameters.AddWithValue("@matkhau", txPass.Text);

            object role = thuchien.ExecuteScalar();
            return Convert.ToInt32(role);

            ketnoi.Close();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            PhanQuyen.userSession = KiemTraDangNhap(txTenDangNhap.Text, txPass.Text);
            if (PhanQuyen.userSession != -1)
            {
                this.Hide();
                PanelControl panel= new PanelControl();
                panel.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản", "Lỗi");
                txTenDangNhap.Focus();
            }
            
        }
    }
}