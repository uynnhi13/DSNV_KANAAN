using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Media.Animation;

namespace DSNV_KANAAN
{
    public partial class QuanLyNhanSu : Form
    {
        public QuanLyNhanSu()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        string sql;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        int idKhuVuc = 2;


        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
            LoadThongTin();
        }

        public void HienThi()
        {
            if (PhanQuyen.CheckPhanQuyen("Read", idKhuVuc))
            {
                lstThongTin.Items.Clear();
                ketnoi.Open();
                thuchien = new SqlCommand("GetEmployeeData", ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;
                docdulieu = thuchien.ExecuteReader();
                i = 0;
                while (docdulieu.Read())
                {
                    lstThongTin.Items.Add(docdulieu[0].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[1].ToString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[2].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[3].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[4].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[5].ToString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[6].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[7].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[8].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[9].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[10].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[11].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[12].ToString());
                    lstThongTin.Items[i].SubItems.Add(DateTime.Parse(docdulieu[13].ToString()).ToShortDateString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[14].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[15].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[16].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[17].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[18].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[19].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[20].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[21].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[22].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[23].ToString());

                    i++;
                }
                lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                ketnoi.Close();
            }
        }

        private void LoadThongTin()
        {
            Function.Load(Function.data("CV"), cbChucVu);
            Function.Load(Function.data("BP"), cbBoPhan);
        }



        //Thêm Nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 2))
            {
                QLNS_ThemThongTin qLNS_ThemThongTin = new QLNS_ThemThongTin();
                qLNS_ThemThongTin.MaNV = "";
                qLNS_ThemThongTin.ShowDialog();
                qLNS_ThemThongTin = null;
                this.HienThi();
                this.Refresh();
            }
            else
            {
                button1.Visible = false;
            }
        }

        //Khi bấm vào sẽ hiện thông tin nhân viên lên.
        private void lstThongTin_Click(object sender, EventArgs e)
        {
            string birthdayString = lstThongTin.SelectedItems[0].SubItems[2].Text;
            dtNgaySinh.Value = DateTime.Parse(birthdayString);
            lbMaNV.Text = lstThongTin.SelectedItems[0].SubItems[0].Text;
            tbHoTen.Text = lstThongTin.SelectedItems[0].SubItems[1].Text;
            cbBoPhan.Text = lstThongTin.SelectedItems[0].SubItems[4].Text;
            cbLoaiHD.Text = lstThongTin.SelectedItems[0].SubItems[3].Text;
            cbChucVu.Text = lstThongTin.SelectedItems[0].SubItems[5].Text;
            lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            lstThongTin.Items.Clear();
            ketnoi.Open();
            int departmentID = Function.GetId("BP", cbBoPhan.Text);
            int jobtitleID=Function.GetId("BP",cbChucVu.Text);
            DateTime birthdayString = dtNgaySinh.Value.Date;
            sql = @"update Employee_tab
                set Full_name=@Fullname, 
                    Department_id=@DepartmentId, 
                    Jobtitle_id=@JobtitleId,
                    Birthday=@Birthday, 
                    LoaiHD=@LoaiHD
                where Emp_code=@Emp_code";
            using(thuchien=new SqlCommand(sql, ketnoi))
            {
                // Thêm các tham số vào câu lệnh SQL để tránh các vấn đề bảo mật và xử lý chuỗi an toàn hơn
                thuchien.Parameters.AddWithValue("@Emp_code", lbMaNV.Text);
                thuchien.Parameters.AddWithValue("@FullName", tbHoTen.Text);
                thuchien.Parameters.AddWithValue("@LoaiHD", cbLoaiHD.Text);
                thuchien.Parameters.AddWithValue("@DepartmentId", departmentID);
                thuchien.Parameters.AddWithValue("@JobtitleId", jobtitleID);
                thuchien.Parameters.AddWithValue("@Birthday", birthdayString.ToString("yyyy-MM-dd HH:mm:ss"));

                // Thực thi câu lệnh SQL INSERT
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
            }
            
            Refresh();
            HienThi();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            lstThongTin.Items.Clear();
            ketnoi.Open();
            sql = @"DELETE FROM Employee_tab WHERE Emp_code = @Emp_code";
            using (thuchien = new SqlCommand(sql, ketnoi))
            {
                thuchien.Parameters.AddWithValue("@Emp_code", lbMaNV.Text);
                thuchien.ExecuteNonQuery();
            }

            MessageBox.Show("Bạn đã xóa thành công nhân viên có id " + lbMaNV.Text);
            ketnoi.Close();
            Refresh();
            
            HienThi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            lstThongTin.Items.Clear();
            ketnoi.Open();
            using (thuchien=new SqlCommand("TimKiemNhanVien", ketnoi))
            {
                thuchien.CommandType = CommandType.StoredProcedure;
                thuchien.Parameters.AddWithValue("@MaNV", string.IsNullOrEmpty(lbMaNV.Text) ? "" : lbMaNV.Text);
                thuchien.Parameters.AddWithValue("@TenNV", string.IsNullOrEmpty(tbHoTen.Text) ? "" : tbHoTen.Text);

            }
            i = 0;
            docdulieu = thuchien.ExecuteReader();
            while (docdulieu.Read())
            {
                lstThongTin.Items.Add(docdulieu[0].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[1].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[2].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[3].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[4].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[5].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[6].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[7].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[8].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[9].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[10].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[11].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[12].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[13].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[14].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[15].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[16].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[17].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[18].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[19].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[20].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[21].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[22].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[23].ToString());
                i++;
            }
            ketnoi.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult thongbao = MessageBox.Show("Bạn muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(thongbao== DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                HienThi();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            foreach(var item in groupBox1.Controls)
            {
                TextBox text= item as TextBox;
                ComboBox comboBox= item as ComboBox;
                if(text!= null)
                {
                    text.Clear();
                }
                if (comboBox != null)
                {
                    comboBox.Text = "";
                }
            }
            dtNgaySinh.Value = DateTime.Now;
            HienThi();
        }


        private void addMore_Click(object sender, EventArgs e)
        {
            QLNS_ThemThongTin qLNS_ThemThongTin = new QLNS_ThemThongTin();
            qLNS_ThemThongTin.MaNV = lbMaNV.Text;
            qLNS_ThemThongTin.ShowDialog();
            qLNS_ThemThongTin = null;
            this.HienThi();
            this.Refresh(); 
        }

        private void btexportE_Click(object sender, EventArgs e)
        {
            // Xuất dữ liệu ra Excel
            Function.ExportExcel(lstThongTin, "Danh Sách Nhân Viên", "Danh Sách Nhân Viên");
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel Sheet (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            
            if (op.ShowDialog() == DialogResult.OK)
            {
                string filePath = op.FileName;
                DetailsImport detail=new DetailsImport();
                detail.filePath=filePath;
                detail.ShowDialog();
                detail = null;
                this.HienThi();
            }
        }

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {

            TaiKhoan tk = new TaiKhoan();
            if (lbMaNV.Text == "")
            {
                MessageBox.Show("Không lấy được thông tin nhân viên");
            }
            else
            {
                ketnoi.Open();

                using (thuchien)
                {
                    try
                    {
                        thuchien = new SqlCommand("CAPQUYEN", ketnoi);
                        thuchien.CommandType = CommandType.StoredProcedure;
                        thuchien.Parameters.AddWithValue("@MaNV", lbMaNV.Text);
                        thuchien.ExecuteNonQuery();

                        using (docdulieu = thuchien.ExecuteReader())
                        {
                            if (docdulieu.HasRows)
                            {
                                while (docdulieu.Read())
                                {
                                    tk.tendangnhap = docdulieu["TenDangNhap"].ToString();
                                    tk.matkhau = docdulieu["MatKhau"].ToString();
                                    tk.manv = lbMaNV.Text;
                                    tk.ShowDialog();
                                }
                            }
                        }

                    }
                    catch (SqlException ex)
                    {
                        DialogResult dlg = MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dlg == DialogResult.Yes)
                        {
                            tk.manv = lbMaNV.Text;
                            tk.ShowDialog();
                        }
                    }
                }
                ketnoi.Close();
            }
        }
    }
}
