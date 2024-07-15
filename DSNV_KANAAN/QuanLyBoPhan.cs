using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using _Excel=Microsoft.Office.Interop.Excel;

namespace DSNV_KANAAN
{
    public partial class QuanLyBoPhan : Form
    {
        SqlConnection ketnoi = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string sql;
        int i = 0;

        public QuanLyBoPhan()
        {
            InitializeComponent();
        }

        private void QuanLyBoPhan_Load(object sender, EventArgs e)
        {
            HienThiThongTinBoPhan();
            //Function.LoadComboBox(Department, cblstBP, "Department_tab");
            
        }

        private void HienThiThongTinBoPhan()
        {
            lstThongTinBP.Items.Clear();
            Function.GetDetailsBPorCV(lstThongTinBP,"BP");
            Function.Load(Function.data("BP"), cblstBP);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //SỬA BỘ PHẬN
        private void button4_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"Update Department_tab
                  Set Name=@Name
                  Where Department_id=@Department_id";
            
            using(thuchien=new SqlCommand(sql, ketnoi))
            {
                thuchien.Parameters.AddWithValue("@Department_id",lbBP.Text);
                thuchien.Parameters.AddWithValue("@Name",tbTenBoPhan.Text);

                thuchien.ExecuteNonQuery();
            }

            ketnoi.Close();
            Refresh();
            HienThiThongTinBoPhan();
        }

        //Khi Nhấn vào danh sách 1 thông tin sẽ hiện lên ở phần thông tin
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstThongTinBP.SelectedItems.Count > 0)
            {
                lbMaBP.Text = lstThongTinBP.SelectedItems[0].SubItems[0].Text;
                tbTenBoPhan.Text = lstThongTinBP.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {

                ketnoi.Open();
                using (thuchien = new SqlCommand("AddDepartment", ketnoi))
                {
                    thuchien.CommandType = CommandType.StoredProcedure;
                    thuchien.Parameters.AddWithValue("@Name", tbTenBoPhan.Text);
                    thuchien.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show("Tên Bộ Phận đã tồn tại");
            }
            finally
            {
                ketnoi.Close();
                Refresh();
                HienThiThongTinBoPhan();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbMaBP.Text))
            {
                try
                {
                    ketnoi.Open();
                    thuchien = new SqlCommand("DeleteDepartment", ketnoi);
                    thuchien.CommandType=CommandType.StoredProcedure;
                    using (thuchien)
                    {
                        thuchien.Parameters.AddWithValue("@Department_id", lbMaBP.Text);

                        thuchien.ExecuteNonQuery();
                    }
                    MessageBox.Show("Bạn đã xóa thành công bộ phận " + tbTenBoPhan.Text);
                    HienThiThongTinBoPhan();
                }
                catch (SqlException ex)
                {
                    DialogResult dlr = MessageBox.Show(ex.Message,
                                "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.Yes)
                    {
                        thuchien = new SqlCommand("DeleteEmpByDepartment", ketnoi);
                        thuchien.CommandType = CommandType.StoredProcedure;
                        using (thuchien)
                        {
                            thuchien.Parameters.AddWithValue("@Department_id", lbMaBP.Text);

                            thuchien.ExecuteNonQuery();
                        }
                        MessageBox.Show("Bạn đã xóa thành công bộ phận " + tbTenBoPhan.Text);
                        HienThiThongTinBoPhan();
                    }
                }
                finally
                {
                    ketnoi.Close();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bộ phận cần xóa");
            }
            Refresh();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            lstThongTinNV.Items.Clear();
            int id=Function.GetId("BP", cblstBP.Text);

            ketnoi.Open();
            thuchien = new SqlCommand("GetDetailsKHByDP", ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;
            thuchien.Parameters.AddWithValue("@id", id);

            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lstThongTinNV.Items.Add(docdulieu[0].ToString());
                lstThongTinNV.Items[i].SubItems.Add(docdulieu["Department_Name"].ToString());
                lstThongTinNV.Items[i].SubItems.Add(docdulieu["Emp_code"].ToString());
                lstThongTinNV.Items[i].SubItems.Add(docdulieu["Full_Name"].ToString());
                lstThongTinNV.Items[i].SubItems.Add(docdulieu["Jobtitle_Name"].ToString());

                i++;
            }

            ketnoi.Close();
        }

        private void cblstBP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Refresh()
        {
            lbMaBP.Text = "";
            tbTenBoPhan.Text = "";
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            Function.ExportExcel(lstThongTinBP, "Danh Sách Bộ Phận", "Danh Sách Bộ Phận");
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            Function.ImportExcelBPvaCV("AddDepartment");
            HienThiThongTinBoPhan();
        }
    }
}
