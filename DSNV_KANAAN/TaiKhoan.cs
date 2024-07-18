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
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;
        public TaiKhoan()
        {
            InitializeComponent();
        }

        public string tendangnhap, matkhau, manv;

        private void btSave_Click(object sender, EventArgs e)
        {
            string Thongbao="";
            if (KiemTraThayDoi(tbTenDN.Text, tbMK.Text)=="exist")
            {
                this.Close();
            }
            else if(KiemTraThayDoi(tbTenDN.Text, tbMK.Text) == "create")
            {
                thuchien = new SqlCommand("TaoMoiTaiKhoan", ketnoi);
                Thongbao = "Thêm tài khoản thành công";
            }
            else
            {
                thuchien = new SqlCommand("UpdateTaiKhoan", ketnoi);
                Thongbao = "Tài khoản được cập nhật thành công";
            }
            try
            {
                ketnoi.Open();
                thuchien.CommandType = CommandType.StoredProcedure;

                thuchien.Parameters.AddWithValue("manv", manv);
                thuchien.Parameters.AddWithValue("tendangnhap", tbTenDN.Text);
                thuchien.Parameters.AddWithValue("matkhau", tbMK.Text);

                thuchien.ExecuteNonQuery();

                MessageBox.Show(Thongbao);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK);
                tbTenDN.Focus();
            }
            finally { ketnoi.Close(); this.Close(); }
        }

        private void btExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string KiemTraThayDoi(string  tendangnhap, string matkhau) 
        {
            if(tendangnhap ==this.tendangnhap && matkhau ==this.matkhau)
            {
                return "exist";
            }
            else if(this.tendangnhap==null && this.matkhau==null)
            {
                return "create";
            }
            else
            {
                return "update";
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            tbTenDN.Text = tendangnhap;
            tbMK.Text = matkhau;
        }
    }
}