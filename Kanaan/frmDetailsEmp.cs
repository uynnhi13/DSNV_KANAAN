using DevExpress.XtraEditors;
using Kanaan_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaan
{
    public partial class frmDetailsEmp : DevExpress.XtraEditors.XtraForm
    {
        public static Function function=new Function();
        public string status;
        public string MaNV;
        public frmDetailsEmp(string status, string MaNV)
        {
            InitializeComponent();
            CheckChucNang(status,MaNV);
        }

        private void CheckChucNang(string status, string MaNV)
        {
            frmEmployee employee = new frmEmployee();
            if(status=="EDIT" && MaNV != "")
            {
                DataTable dt=new DataTable();
                DO_Employee emp = new DO_Employee();
                title.Text = "Chỉnh sửa thông tin nhân viên";
                dt = emp.GetEmployeeByID(MaNV);
                if(dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    tbMaNV.Text = row[0].ToString();
                    tbTen.Text = row[1].ToString();
                    dtNgaySinh.Value = DateTime.Parse(row[2].ToString());
                    cbLoaiHD.Text = row[3].ToString();
                    cbBP.Text = row[4].ToString();
                    cbCV.Text = row[5].ToString();
                    tbCMND.Text = row[12].ToString();
                    dtNgayCap.Value = DateTime.Parse(row[13].ToString());
                    dtNgayKy.Value = DateTime.Parse(row[7].ToString());
                    dtNgayHetHan.Value = DateTime.Parse(row[8].ToString());
                    dtNgayNhan.Value = DateTime.Parse(row[6].ToString());
                    cbNoiCap.Text = row[14].ToString();
                    cbNoiSinh.Text = row[10].ToString();
                    cbNguyenQuan.Text = row[11].ToString();
                    cbTrinhDo.Text = row[24].ToString();
                    tbDiaChi.Text = row[16].ToString();
                    cbGioiTinh.Text = row[17].ToString();
                    cbDanToc.Text = row[22].ToString();
                    cbTonGiao.Text = row[23].ToString();
                    tbMaSoThue.Text = row[19].ToString();
                    tbSoSoBHXH.Text = row[21].ToString();
                    tbSDT.Text = row[15].ToString();
                    tbSoTaiKhoan.Text = row[20].ToString();
                    dtThangBHXH.Value = DateTime.Parse(row[9].ToString());
                    UploadImg.ImageLocation = row[25].ToString();
                    if (UploadImg.ImageLocation == "")
                    {
                        if (cbGioiTinh.Text == "Nữ")
                        {
                            UploadImg.ImageLocation = "D:\\Thực Tập Conect\\Winform\\DSNV_KANAAN\\Kanaan\\Image\\Avatar\\27470336_7294793.jpg";
                        }
                        else
                        {
                            UploadImg.ImageLocation = "D:\\Thực Tập Conect\\Winform\\DSNV_KANAAN\\Kanaan\\Image\\Avatar\\7309683.jpg";
                        }
                    }
                    
                }
            }
        }
    }
}