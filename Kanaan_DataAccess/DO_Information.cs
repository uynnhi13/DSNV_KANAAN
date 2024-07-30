using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaan_DataAccess
{
    public class DO_Information
    {
        DBHelper dbHelper=new DBHelper();

        public ComboBox Load_cbb(ComboBox comboBox, string dataName)
        {
            try
            {
                dbHelper.GetConnection(); // Đảm bảo phương thức này mở kết nối
                SqlDataReader reader = dbHelper.ExcuteReaderSQL(dataName);

                if (reader == null)
                {
                    throw new InvalidOperationException("SqlDataReader không được khởi tạo.");
                }
                List<KeyValuePair<int, string>> items = new List<KeyValuePair<int, string>>();

                comboBox.Items.Clear(); // Xóa các mục hiện tại
                while (reader.Read())
                {
                    int id = reader.GetInt32(0); // Lấy giá trị ID
                    string name = reader.GetString(1); // Lấy giá trị Name

                    items.Add(new KeyValuePair<int, string>(id, name));
                }

                comboBox.DataSource= items;
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";

                reader.Close(); // Đóng SqlDataReader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message);
            }
            return comboBox;
        }
    }
}
