using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanaan_DataAccess
{
    public class DO_Employee
    {
        DataTable dt;
        DBHelper dbHelper;

        public DataTable GetAllEmployee()
        {
            dt = new DataTable();
            dbHelper = new DBHelper();
            dt = dbHelper.return_Table("GetEmployeeData", new string[] { "" }, new object[] { });
            return dt;
        }

        public DataTable GetEmployeeByID(string MaNV)
        {
            dt = new DataTable();
            dbHelper = new DBHelper();
            dt = dbHelper.return_Table("GetEmployeeDataById", new string[] { "Emp_code" }, new object[] { MaNV });
            return dt;
        }
    }
}
