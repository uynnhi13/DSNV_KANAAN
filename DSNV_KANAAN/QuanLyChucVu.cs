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
    public partial class QuanLyChucVu : Form
    {
        public QuanLyChucVu()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string sql;
        int i = 0;
        DataTable dtCV=new DataTable();

        private void QuanLyChucVu_Load(object sender, EventArgs e)
        {
            HienThiThongTinChucVu();
            Function.Load(dtCV, cblstCV);
        }

        private void HienThiThongTinChucVu()
        {
            lstThongTinCV.Items.Clear();
            Function.GetDetailsBPorCV(lstThongTinCV,"CV");
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi.Open();

                //sql = @"Insert into Jobtitle_tab(Name)
                //           VALUES (@Name)";

                using (thuchien = new SqlCommand("AddJobtitle", ketnoi))
                {
                    thuchien.CommandType = CommandType.StoredProcedure;
                    thuchien.Parameters.AddWithValue("@Name", tbTenCV.Text);
                    thuchien.ExecuteNonQuery();
                }

                HienThiThongTinChucVu();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Refresh();
                ketnoi.Close();
            }
            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lbMaCV.Text))
                {
                    ketnoi.Open();
                    thuchien = new SqlCommand("DeleteJobtitle", ketnoi);
                    thuchien.CommandType=CommandType.StoredProcedure;
                    using (thuchien)
                    {
                        thuchien.Parameters.AddWithValue("@Jobtitle_id", lbMaCV.Text);

                        thuchien.ExecuteNonQuery();
                    }
                    MessageBox.Show("Bạn đã xóa thành công chức vụ " + tbTenCV.Text);
                }
                else
                {
                    MessageBox.Show("Không thể xóa chức vụ này");
                }
                
            }
            catch(SqlException ex)
            {
                DialogResult dgR=MessageBox.Show(ex.Message,"Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(dgR==DialogResult.Yes)
                {
                    thuchien = new SqlCommand("DeleteEmpByJobtitle", ketnoi);
                    thuchien.CommandType = CommandType.StoredProcedure;
                    using (thuchien)
                    {
                        thuchien.Parameters.AddWithValue("@Jobtitle_id", lbMaCV.Text);

                        thuchien.ExecuteNonQuery();
                    }
                    MessageBox.Show("Bạn đã xóa thành công chức vụ " + tbTenCV.Text);
                }
            }
            finally
            {
                HienThiThongTinChucVu();
                ketnoi.Close();
                Refresh();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"Update Jobtitle_tab
                  Set Name=@Name
                  Where Jobtitle_id=@Jobtitle_id";

            using (thuchien = new SqlCommand(sql, ketnoi))
            {
                thuchien.Parameters.AddWithValue("@Jobtitle_id", lbMaCV.Text);
                thuchien.Parameters.AddWithValue("@Name", tbTenCV.Text);

                thuchien.ExecuteNonQuery();
            }

            ketnoi.Close();
            
            HienThiThongTinChucVu();
            Refresh();
        }


        private void btSearch_Click(object sender, EventArgs e)
        {
            lstThongTinKH.Items.Clear();
            int id = Function.GetId(dtCV, cblstCV.Text);

            ketnoi.Open();
            thuchien = new SqlCommand("GetDetailsKHByCV", ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;
            thuchien.Parameters.AddWithValue("@id", id);

            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lstThongTinKH.Items.Add(docdulieu[0].ToString());
                lstThongTinKH.Items[i].SubItems.Add(docdulieu["Jobtitle_Name"].ToString());
                lstThongTinKH.Items[i].SubItems.Add(docdulieu["Emp_code"].ToString());
                lstThongTinKH.Items[i].SubItems.Add(docdulieu["Full_Name"].ToString());
                lstThongTinKH.Items[i].SubItems.Add(docdulieu["Department_Name"].ToString());

                i++;
            }

            ketnoi.Close();
        }


        private void Refresh()
        {
            lbMaCV.Text = "";
            tbTenCV.Text = "";
        }

        private void lstThongTinCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstThongTinCV.SelectedItems.Count > 0)
            {
                lbMaCV.Text = lstThongTinCV.SelectedItems[0].SubItems[0].Text;
                tbTenCV.Text = lstThongTinCV.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            Function.ExportExcel(lstThongTinCV, "Danh Sách Chức Vụ", "Danh Sách Chức Vụ");
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            Function.ImportExcelBPvaCV("AddJobtitle");
            HienThiThongTinChucVu();
        }
    }
}
