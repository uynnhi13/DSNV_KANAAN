using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DSNV_KANAAN
{
    public partial class QLNS_ThemThongTin : Form
    {
        
        public QLNS_ThemThongTin()
        {
            InitializeComponent();
        }

        public string MaNV;
        public bool status = true;

        SqlConnection ketnoi = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string sql;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        Dictionary<int, string> Department = new Dictionary<int, string>();
        Dictionary<int, string> Jobtitle = new Dictionary<int, string>();
        Dictionary<int, string> DanToc = new Dictionary<int, string>();
        Dictionary<int, string> TonGiao = new Dictionary<int, string>();
        Dictionary<int, string> TrinhDo = new Dictionary<int, string>();

        private void QLNS_ThemThongTin_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
            LoadThongTin();
        }

        private void HienThiThongTin()
        {
            if (!string.IsNullOrEmpty(MaNV))
            {
                status = false;
                Title.Text = "Chỉnh sửa thông tin nhân viên";
                thuchien = new SqlCommand("GetEmployeeDataById", ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;
                thuchien.Parameters.AddWithValue("@Emp_code", MaNV);

                ketnoi.Open();

                using (SqlDataReader docdulieu = thuchien.ExecuteReader())
                {
                    if (docdulieu.Read())
                    {
                        lbMaNV.Text = docdulieu["Emp_code"].ToString();
                        dtNgaySinh.Value = DateTime.Parse(docdulieu["Birthday"].ToString());
                        cbLoaiHD.Text = docdulieu["LoaiHD"].ToString();
                        tbHoTen.Text = docdulieu["Full_name"].ToString();
                        cbBoPhan.Text = docdulieu["Department_Name"].ToString();
                        cbChucVu.Text = docdulieu["Jobtitle_Name"].ToString();
                        tbCMND.Text = docdulieu["CMND"].ToString();
                        dtNgayCap.Value = DateTime.Parse(docdulieu["NgayCap"].ToString());
                        dtNgayKyHD.Value = DateTime.Parse(docdulieu["NgayKyHopDong"].ToString());
                        dtNgayHetHan.Value = DateTime.Parse(docdulieu["NgayHetHan"].ToString());
                        dtNhanViec.Value = DateTime.Parse(docdulieu["NgayNhanViec"].ToString());
                        cbNoiCap.Text = docdulieu["NoiCap"].ToString();
                        cbNoiSinh.Text = docdulieu["NoiSinh"].ToString();
                        cbNguyenQuan.Text = docdulieu["NguyenQuan"].ToString();
                        cbTrinhDo.Text = docdulieu["TenTrinhDo"].ToString();
                        tbDiaChi.Text = docdulieu["DiaChi"].ToString();
                        cbGioiTinh.Text = docdulieu["GioiTinh"].ToString();
                        cbDanToc.Text = docdulieu["TenDanToc"].ToString();
                        cbTonGiao.Text = docdulieu["TenTonGiao"].ToString();
                        tbMaSoThue.Text = docdulieu["MaSoThue"].ToString();
                        tbSoSoBHXH.Text = docdulieu["SoSoBHXH"].ToString();
                        tbDienThoai.Text = docdulieu["DienThoai"].ToString();
                        tbSoTaiKhoan.Text = docdulieu["SoTaiKhoan"].ToString();
                        dtThangThamGia.Value = DateTime.Parse(docdulieu["ThangThamGiaBHXH"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên có mã " + MaNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Title.Text = "Thêm mới nhân viên";
                    }
                }

                ketnoi.Close();
            }
            else Title.Text = "Thêm mới nhân viên";
        }

        private void LoadThongTin()
        {
            Function.LoadComboBox(Jobtitle, cbChucVu, "Jobtitle_tab");
            Function.LoadComboBox(Department, cbBoPhan, "Department_tab");
            Function.LoadComboBox(TonGiao, cbTonGiao, "TonGiao");
            Function.LoadComboBox(DanToc, cbDanToc, "DanToc");
            Function.LoadComboBox(TrinhDo, cbTrinhDo, "TrinhDoDaiHoc");
            Function.LoadComboBoxButNoAdd(cbNguyenQuan, "DiaDiem");
            Function.LoadComboBoxButNoAdd(cbNoiCap, "DiaDiem");
            Function.LoadComboBoxButNoAdd(cbNoiSinh, "DiaDiem");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            int Department_Id = Function.GetId(Department, cbBoPhan.Text);
            int Jobtitle_Id = Function.GetId(Jobtitle, cbChucVu.Text);
            int TonGiao_Id = Function.GetId(TonGiao, cbTonGiao.Text);
            int DanToc_Id = Function.GetId(DanToc, cbDanToc.Text);
            int TrinhDo_Id = Function.GetId(TrinhDo, cbTrinhDo.Text);
            String MaNV;

            if (status == true)
            {
                thuchien = new SqlCommand("AddEmployeeData", ketnoi);
            }
            else
            {
                thuchien=new SqlCommand("UpdateEmployeeData", ketnoi);
            }
            thuchien.CommandType = CommandType.StoredProcedure;
            using (thuchien)
            {
                thuchien.Parameters.AddWithValue("@LoaiHD", cbLoaiHD.Text);
                thuchien.Parameters.AddWithValue("@Emp_code", lbMaNV.Text);
                thuchien.Parameters.AddWithValue("@Full_name", tbHoTen.Text);
                thuchien.Parameters.AddWithValue("@Birthday",dtNgaySinh.Value);
                thuchien.Parameters.AddWithValue("@Department_id", Department_Id);
                thuchien.Parameters.AddWithValue("@Jobtitle_id", Jobtitle_Id);
                thuchien.Parameters.AddWithValue("@NgayNhanViec", dtNhanViec.Value);
                thuchien.Parameters.AddWithValue("@NgayKyHopDong", dtNgayKyHD.Value);
                thuchien.Parameters.AddWithValue("@NgayHetHan", dtNgayHetHan.Value);
                thuchien.Parameters.AddWithValue("@NgayCap", dtNgayCap.Value);
                thuchien.Parameters.AddWithValue("@ThangThamGiaBHXH", dtThangThamGia.Value);
                thuchien.Parameters.AddWithValue("@NoiCap", cbNoiCap.Text);
                thuchien.Parameters.AddWithValue("@NoiSinh", cbNoiSinh.Text);
                thuchien.Parameters.AddWithValue("@DiaChi", tbDiaChi.Text);
                thuchien.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                thuchien.Parameters.AddWithValue("@DanToc", DanToc_Id);
                thuchien.Parameters.AddWithValue("@TonGiao", TonGiao_Id);
                thuchien.Parameters.AddWithValue("@MaSoThue", tbMaSoThue.Text);
                thuchien.Parameters.AddWithValue("@SoTaiKhoan", tbSoTaiKhoan.Text);
                thuchien.Parameters.AddWithValue("@SoSoBHXH", tbSoSoBHXH.Text);
                thuchien.Parameters.AddWithValue("@NguyenQuan", cbNguyenQuan.Text);
                thuchien.Parameters.AddWithValue("@CMND", tbCMND.Text);
                thuchien.Parameters.AddWithValue("@DienThoai", tbDienThoai.Text);
                thuchien.Parameters.AddWithValue("@TrinhDo", TrinhDo_Id);

                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                this.Close();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbLoaiHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbSoSoBHXH_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
