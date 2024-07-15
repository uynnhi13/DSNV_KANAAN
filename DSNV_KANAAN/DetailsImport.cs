using DevExpress.Data.Filtering;
using DevExpress.Utils.Behaviors.Common;
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
    public partial class DetailsImport : Form
    {
        public DetailsImport()
        {
            InitializeComponent();
        }

        public string filePath;
        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        private void DetailsImport_Load(object sender, EventArgs e)
        {
            Function.LoadExcelData(filePath, dataGridView1);
        }

        private void saveDB_Click(object sender, EventArgs e)
        {

            ketnoi.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    break; // Ngừng vòng lặp nếu hàng trống
                }

                SqlCommand thuchien = new SqlCommand("AddEmployeeData", ketnoi);
                thuchien.CommandType = CommandType.StoredProcedure;
                using (thuchien)
                {
                    int departmentID = Function.GetId("BP", row.Cells[4].Value.ToString());
                    int jobtitleID = Function.GetId("CV", row.Cells[5].Value.ToString());
                    int DanToc = Function.GetId("DT", row.Cells[21].Value.ToString());
                    int TonGiao = Function.GetId("TG", row.Cells[22].Value.ToString());
                    int TrinhDo = Function.GetId("TD", row.Cells[23].Value.ToString());
                    int DiaDiem = Function.GetId("DD", row.Cells[10].Value.ToString());
                    DiaDiem = Function.GetId("DD", row.Cells[11].Value.ToString());
                    DiaDiem = Function.GetId("DD", row.Cells[14].Value.ToString());

                    try
                    {
                        thuchien.Parameters.AddWithValue("@Emp_code", "");
                        thuchien.Parameters.AddWithValue("@Full_name", row.Cells[1].Value);
                        thuchien.Parameters.AddWithValue("@Birthday", row.Cells[2].Value);
                        thuchien.Parameters.AddWithValue("@LoaiHD", row.Cells[3].Value);
                        thuchien.Parameters.AddWithValue("@Department_id", departmentID);
                        thuchien.Parameters.AddWithValue("@Jobtitle_id", jobtitleID);
                        thuchien.Parameters.AddWithValue("@NgayNhanViec", row.Cells[6].Value);
                        thuchien.Parameters.AddWithValue("@NgayKyHopDong", row.Cells[7].Value);
                        thuchien.Parameters.AddWithValue("@NgayHetHan", row.Cells[8].Value);
                        thuchien.Parameters.AddWithValue("@ThangThamGiaBHXH", row.Cells[9].Value);
                        thuchien.Parameters.AddWithValue("@NoiSinh", row.Cells[10].Value);
                        thuchien.Parameters.AddWithValue("@NguyenQuan", row.Cells[11].Value);
                        thuchien.Parameters.AddWithValue("@CMND", row.Cells[12].Value);
                        thuchien.Parameters.AddWithValue("@NgayCap", row.Cells[13].Value);
                        thuchien.Parameters.AddWithValue("@NoiCap", row.Cells[14].Value);
                        thuchien.Parameters.AddWithValue("@DienThoai", row.Cells[15].Value);
                        thuchien.Parameters.AddWithValue("@DiaChi", row.Cells[16].Value);
                        thuchien.Parameters.AddWithValue("@GioiTinh", row.Cells[17].Value);
                        thuchien.Parameters.AddWithValue("@MaSoThue", row.Cells[18].Value);
                        thuchien.Parameters.AddWithValue("@SoTaiKhoan", row.Cells[19].Value);
                        thuchien.Parameters.AddWithValue("@SoSoBHXH", row.Cells[20].Value);
                        thuchien.Parameters.AddWithValue("@DanToc", DanToc);
                        thuchien.Parameters.AddWithValue("@TonGiao", TonGiao);
                        thuchien.Parameters.AddWithValue("@TrinhDo", TrinhDo);

                        thuchien.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thông tin Nhập không đúng, vui lòng xem lại");
                        this.Close();
                    }
                }
            }

            ketnoi.Close();
            MessageBox.Show("Đã thêm dữ liệu thành công");
            this.Close();
        }

        private static void AddMoreIn4()
        {

        }
    }
}
