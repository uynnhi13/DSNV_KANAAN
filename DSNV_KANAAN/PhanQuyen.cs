using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSNV_KANAAN
{
    internal class PhanQuyen
    {
        public static int userSession;
        public static SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static SqlCommand thuchien;

        public static bool CheckPhanQuyen(string ChucNang, int KhuVuc)
        {
            ketnoi.Open();
            thuchien= new SqlCommand("PhanQuyenChoTK",ketnoi);
            thuchien.CommandType = CommandType.StoredProcedure;

            thuchien.Parameters.AddWithValue("PhanQuyen", userSession);
            thuchien.Parameters.AddWithValue("KhuVuc", KhuVuc);

            // Kiểm tra quyền hạn
            bool hasPermission = false;

            using (SqlDataReader reader=thuchien.ExecuteReader())
            {
                if (reader.Read())
                {
                    bool canRead = reader.GetBoolean(reader.GetOrdinal("canRead"));
                    bool canEdit = reader.GetBoolean(reader.GetOrdinal("canCreate"));
                    bool canUpdate = reader.GetBoolean(reader.GetOrdinal("canUpdate"));

                    if (ChucNang.Equals("Read", StringComparison.OrdinalIgnoreCase))
                    {
                        hasPermission = canRead;
                    }
                    else if (ChucNang.Equals("Create", StringComparison.OrdinalIgnoreCase))
                    {
                        hasPermission = canEdit;
                    }
                    else if (ChucNang.Equals("Update", StringComparison.OrdinalIgnoreCase))
                    {
                        hasPermission = canUpdate;
                    }
                }
            }

            ketnoi.Close();

            return hasPermission;
        }
    }
}
