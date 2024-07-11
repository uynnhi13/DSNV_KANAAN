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
        Dictionary<int, string> Jobtitle = new Dictionary<int, string>();

        private void QuanLyChucVu_Load(object sender, EventArgs e)
        {
            HienThiThongTinChucVu();
            Function.LoadComboBox(Jobtitle, cblstCV, "Jobtitle_tab");
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
            if (!string.IsNullOrEmpty(lbMaCV.Text))
            {
                ketnoi.Open();
                sql = @"DELETE FROM Jobtitle_tab 
                WHERE Jobtitle_id=@Jobtitle_id";
                using (thuchien = new SqlCommand(sql, ketnoi))
                {
                    thuchien.Parameters.AddWithValue("@Jobtitle_id", lbMaCV.Text);

                    thuchien.ExecuteNonQuery();
                }

                ketnoi.Close();
                MessageBox.Show("Bạn đã xóa thành công chức vụ " + tbTenCV.Text);
                HienThiThongTinChucVu();
            }
            else
            {
                MessageBox.Show("Không thể xóa chức vụ này");
            }
            Refresh();
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
            int id = Function.GetId(Jobtitle, cblstCV.Text);

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
                lstThongTinKH.Items[i].SubItems.Add(docdulieu["Employee_id"].ToString());
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
    }
}
