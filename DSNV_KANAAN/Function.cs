using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSNV_KANAAN
{
    internal class Function
    {
        public static string chuoiketnoi = @"Data Source=LEUYENNHI;Initial Catalog=DanhSachNVKanaan;Integrated Security=True";
        public static SqlCommand thuchien;
        public static SqlConnection ketnoi;
        public static SqlDataReader docdulieu;
        public static string sql;
        public static void LoadComboBox(Dictionary<int, string> dictionary, ComboBox comboBox,string tenBang)
        {
            
            using (ketnoi = new SqlConnection(chuoiketnoi))
            {
                ketnoi.Open();
                string sql = @"SELECT * FROM "+tenBang;
                using (SqlCommand thuchien = new SqlCommand(sql, ketnoi))
                {
                    using (SqlDataReader docdulieu = thuchien.ExecuteReader())
                    {
                        while (docdulieu.Read())
                        {
                            int jobTitle_id = docdulieu.GetInt32(0);
                            string jobtitleName = docdulieu.GetString(1);
                            dictionary.Add(jobTitle_id, jobtitleName);
                            comboBox.Items.Add(jobtitleName);
                        }
                    }
                }
            }
        }

        public static void LoadComboBoxButNoAdd(ComboBox comboBox, string tenBang)
        {
            string chuoiketnoi = @"Data Source=LEUYENNHI;Initial Catalog=DanhSachNVKanaan;Integrated Security=True";
            using (SqlConnection ketnoi = new SqlConnection(chuoiketnoi))
            {
                ketnoi.Open();
                string sql = @"SELECT * FROM " + tenBang;
                using (SqlCommand thuchien = new SqlCommand(sql, ketnoi))
                {
                    using (SqlDataReader docdulieu = thuchien.ExecuteReader())
                    {
                        while (docdulieu.Read())
                        {
                            int jobTitle_id = docdulieu.GetInt32(0);
                            string jobtitleName = docdulieu.GetString(1);
                            comboBox.Items.Add(jobtitleName);
                        }
                    }
                }
            }
        }

        public static int GetId(Dictionary<int, string> Dic, string Name)
        {
            foreach (var i in Dic)
            {
                if (i.Value == Name)
                {
                    return i.Key;
                }
            }
            return -1;
        }

        //TỰ ĐỘNG TẠO EMP_CODE
        public string GenerateEmpCode(int employeeCount)
        {
            return employeeCount.ToString("D4"); // D4 để đảm bảo chuỗi có độ dài 4 ký tự, bắt đầu từ 0001
        }

        //FUNCTION DÙNG CHUNG CHO BỘ PHẬN HOẶC CHỨC VỤ
        public static void GetDetailsBPorCV(ListView lstThongTin, string Name)
        {
            if (Name == "BP")
            {
                sql = @"Select * FROM " +"Department_tab";
            }
            else
            {
                sql = @"Select * FROM " + "Jobtitle_tab";
            }
            using(ketnoi=new SqlConnection(chuoiketnoi))
            {
                int i = 0;
                lstThongTin.Controls.Clear();
                ketnoi.Open();

                
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();

                while (docdulieu.Read())
                {
                    lstThongTin.Items.Add(docdulieu[0].ToString());
                    lstThongTin.Items[i].SubItems.Add(docdulieu[1].ToString());
                    i++;
                }

                ketnoi.Close();
            }
        }
    }
}
