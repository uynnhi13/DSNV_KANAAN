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
        Dictionary<int, string> Department = new Dictionary<int, string>();
        Dictionary<int,string> Jobtitle=new Dictionary<int, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
            LoadThongTin();
        }

        public void ExportExcel(ListView lstView, string sheetName, string title)
        {
            //TẠO CÁC ĐỐI TƯỢNG EXCEL
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Workbook oBook;

            //TẠO MỚI MỘT EXCEL WORKBOOK
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            //TẠO PHẦN TIÊU ĐỀ
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //TẠO TIÊU ĐỀ CỘT
            //Microsoft.Office.Interop.Excel.Range c11 = oSheet.get_Range("A3", "A3");
            //c11.Value2 = "Mã Nhân Viên";
            //c11.ColumnWidth = 12;

            //Microsoft.Office.Interop.Excel.Range c12 = oSheet.get_Range("B3", "B3");
            //c12.Value2 = "Họ tên";
            //c12.ColumnWidth = 25.0;

            //Microsoft.Office.Interop.Excel.Range c13 = oSheet.get_Range("C3", "C3");
            //c13.Value2 = "Ngày Sinh";
            //c13.ColumnWidth = 25;

            for(int i = 0; i < lstThongTin.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range col = oSheet.get_Range((char)('A' + i) + "3", Type.Missing);
                col.Value2 = lstView.Columns[i].Text;
                col.ColumnWidth = lstView.Columns[i].Width / 10;
                col.Font.Bold = true;
                col.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            //TẠO MẢNG THEO DATABASE
            object[,] arr = new object[lstView.Items.Count,lstView.Columns.Count]; 

            //CHUYỂN DỮ LIỆU TỪ DB VÀO MẢNG ĐỐI TƯỢNG
            for(int item=0; item < lstView.Items.Count; item++)
            {
                ListViewItem listViewItem = lstView.Items[item];

                for(int col=0;col<lstView.Columns.Count;col++)
                {
                    arr[item, col] = "'"+listViewItem.SubItems[col].Text;
                }
            }

            //THIẾT LẬP VÙNG ĐIỀN DỮ LIỆU
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + lstView.Items.Count - 1;
            int columnEnd = lstView.Columns.Count;

            //Ô BẮT ĐẦU ĐIỀN DỮ LIỆU
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            //Ô KẾT THÚC ĐIỀN DỮ LIỆU
            Microsoft.Office.Interop.Excel.Range c2=(Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            //LẤY VỀ VÙNG DỮ LIỆU
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //ĐIỀN DỮ LIỆU VÀO VÙNG ĐÃ THIẾT LẬP
            range.Value2 = arr;
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }


        public void HienThi()
        {
            lstThongTin.Items.Clear();
            ketnoi.Open();
            thuchien = new SqlCommand("GetEmployeeData",ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while(docdulieu.Read())
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
            ketnoi.Close();
        }

        private void LoadThongTin()
        {
            Function.LoadComboBox(Jobtitle, cbChucVu, "Jobtitle_tab");
            Function.LoadComboBox(Department, cbBoPhan, "Department_tab");
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Thêm Nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            QLNS_ThemThongTin qLNS_ThemThongTin = new QLNS_ThemThongTin();
            qLNS_ThemThongTin.MaNV = "";
            qLNS_ThemThongTin.ShowDialog();
            qLNS_ThemThongTin = null;
            this.HienThi();
            this.Refresh();
        }

        
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaiHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {

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

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            lstThongTin.Items.Clear();
            ketnoi.Open();
            int departmentID = Function.GetId(Department, cbBoPhan.Text);
            int jobtitleID=Function.GetId(Jobtitle,cbChucVu.Text);
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

        private void label7_Click(object sender, EventArgs e)
        {

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
            dtNgaySinh.Value = DateTime.Now;
            lbMaNV.Text = "";
            tbHoTen.Text = "";
            cbBoPhan.Text = "";
            cbLoaiHD.Text = "";
            cbChucVu.Text = "";
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
            ExportExcel(lstThongTin, "Danh Sách", "Danh Sách Nhân Viên");
        }
    }
}
