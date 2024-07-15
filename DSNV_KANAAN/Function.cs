using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Excel = Microsoft.Office.Interop.Excel;

namespace DSNV_KANAAN
{
    internal class Function
    {
        public static SqlConnection ketnoi=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static SqlCommand thuchien;
        public static SqlDataReader docdulieu;
        public static string sql;

        public static DataTable dtBP = new DataTable();
        public static DataTable dtCV = new DataTable();
        public static DataTable dtDT = new DataTable();
        public static DataTable dtTG = new DataTable();
        public static DataTable dtTD = new DataTable();
        public static DataTable dtDD = new DataTable();

        static Function()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            LoadDataTable();
        }

        public static void LoadDataTable()
        {
            Function.LoadTable(dtBP, "Department_tab");
            Function.LoadTable(dtCV, "Jobtitle_tab");
            Function.LoadTable(dtTG, "TonGiao");
            Function.LoadTable(dtDT, "DanToc");
            Function.LoadTable(dtTD, "TrinhDoDaiHoc");
            Function.LoadTable(dtDD, "DiaDiem");
            Function.LoadTable(dtDD, "DiaDiem");
            Function.LoadTable(dtDD, "DiaDiem");
        }

        public static void LoadTable(DataTable dt, string nameData)
        {
            try
            {
                dt.Clear();
                ketnoi.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from " + nameData, ketnoi);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ketnoi.Close();
            }
        }

        public static DataTable data(string key)
        {
            DataTable db=new DataTable();
            switch(key) 
            {
                case "BP":
                    db = dtBP;
                    break;
                case "CV":
                    db = dtCV;
                    break;
                case "TG":
                    db = dtTG;
                    break;
                case "DT":
                    db = dtDT;
                    break;
                case "TD":
                    db = dtTD;
                    break;
                case "DD":
                    db = dtDD;
                    break;
                default: break;
            }

            return db;

        }


        public static void Load(DataTable dt, ComboBox cb)
        {
            cb.Items.Clear();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cb.Items.Add(dr[1]);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ketnoi.Close();
            }
        }

        private static string khoiTao(string dt, string name)
        {
            switch (dt)
            {
                case "BP":
                    sql = $"Insert into Department_tab(Name) Values (N'{name}')";
                    break;
                case "CV":
                    sql = $"Insert into JobTitle_tab(Name) Values (N'{name}')";
                    break;
                case "DT":
                    sql = $"Insert into DanToc(TenDanToc) Values (N'{name}')";
                    break;
                case "TG":
                    sql = $"Insert into TonGiao(TenTonGiao) Values (N'{name}')";
                    break;
                case "TD":
                    sql = $"Insert into TrinhDo(TenTrinhDo) Values (N'{name}')";
                    break;
                case "DD":
                    sql = $"Insert into DiaDiem(TenDiaDiem) Values (N'{name}')";
                    break;
                default:
                    throw new ArgumentException("Invalid DataTable name");
            }
            return sql;
        }

        public static int GetId(string key,string Name)
        {
            LoadDataTable();
            DataTable dt = data(key);
            if (dt == null)
            {
                throw new InvalidOperationException("DataTable dt chưa được khởi tạo.");
            }

            int id = -1;

            while (id == -1)
            {
                foreach (DataRow d in dt.Rows)
                {
                    if (d[1].ToString() == Name)
                    {
                        id= Convert.ToInt32(d[0]);
                    }
                }

                if(id == -1)
                {
                    DialogResult dialog = MessageBox.Show(Name + " Chưa được khởi tạo, Bạn có muốn khởi tạo không? ", "Nhắc Nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        ketnoi.Open();
                        sql = khoiTao(key, Name);
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        ketnoi.Close();
                    }
                    else { break; }

                    LoadDataTable();
                }

            }

            return id;
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
            ketnoi.Open();
            //using(ketnoi)
            //{

            //}
            int i = 0;
            lstThongTin.Controls.Clear();

            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();

            while (docdulieu.Read())
            {
                lstThongTin.Items.Add(docdulieu[0].ToString());
                lstThongTin.Items[i].SubItems.Add(docdulieu[1].ToString());
                i++;
            }
            lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstThongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ketnoi.Close();
        }

        public static void ExportExcel(ListView lstView, string sheetName, string title)
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
            string endColumn = Convert.ToChar('A' + lstView.Columns.Count - 1).ToString() + "1";
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1",endColumn);
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            List<int> dateColumns = new List<int>();

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

            for (int i = 0; i < lstView.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range col = oSheet.get_Range((char)('A' + i) + "3", Type.Missing);
                col.Value2 = lstView.Columns[i].Text;
                col.ColumnWidth = lstView.Columns[i].Width / 10;
                col.Font.Bold = true;
                col.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            //TẠO MẢNG THEO DATABASE
            object[,] arr = new object[lstView.Items.Count, lstView.Columns.Count];

            //CHUYỂN DỮ LIỆU TỪ DB VÀO MẢNG ĐỐI TƯỢNG
            //for (int item = 0; item < lstView.Items.Count; item++)
            //{
            //    ListViewItem listViewItem = lstView.Items[item];

            //    for (int col = 0; col < lstView.Columns.Count; col++)
            //    {
            //        arr[item, col] = "'" + listViewItem.SubItems[col].Text;
            //    }
            //}

            //CHUYỂN DỮ LIỆU TỪ DB VÀO MẢNG ĐỐI TƯỢNG
            for (int item = 0; item < lstView.Items.Count; item++)
            {
                ListViewItem listViewItem = lstView.Items[item];

                for (int col = 0; col < lstView.Columns.Count; col++)
                {
                    var value = listViewItem.SubItems[col].Text;

                    // Kiểm tra nếu giá trị là chuỗi
                    if (value is string)
                    {
                        arr[item, col] = "'"+value; // Nếu là chuỗi, giữ nguyên
                    }
                    else
                    {
                        arr[item, col] = Convert.ToDateTime(value); // Nếu không, chuyển đổi sang DateTime
                    }
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
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            //LẤY VỀ VÙNG DỮ LIỆU
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //ĐIỀN DỮ LIỆU VÀO VÙNG ĐÃ THIẾT LẬP
            range.Value2 = arr;
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        public static DataTable ImportExcel(string filePath)
        {
            DataTable dt = new DataTable();
            _Excel.Application excel = new _Excel.Application();
            _Excel.Workbook wb = excel.Workbooks.Open(filePath);
            _Excel.Worksheet ws = wb.Worksheets[1];
            _Excel.Range range = ws.UsedRange;

            // Đọc header
            for (int col = 1; col <= range.Columns.Count; col++)
            {
                dt.Columns.Add(range.Cells[3, col].Value2.ToString());
            }

            // Đọc dữ liệu
            for (int row = 4; row <= range.Rows.Count; row++)
            {
                DataRow dr = dt.NewRow();
                bool isEmptyRow = true; 
                for (int col = 2; col <= range.Columns.Count; col++)
                {
                    object cellValue = range.Cells[row, col].Value2;
                    if (cellValue != null)
                    {
                        dr[col - 1] = cellValue.ToString();
                        isEmptyRow = false; // Đánh dấu là dòng này có dữ liệu
                    }
                }

                // Nếu dòng không có dữ liệu (tất cả các cell đều là null)
                // Thì dừng vòng lặp
                if (isEmptyRow)
                {
                    break;
                }

                dt.Rows.Add(dr);
            }

            // Đóng workbook và quit Excel
            wb.Close(false);
            excel.Quit();

            return dt;
        }

        public static void ImportExcelBPvaCV(string nameProc)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel Sheet (*.xlsx)|*.xlsx|All Files (*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                string filePath = op.FileName;

                
                DataTable importedDataTable = Function.ImportExcel(filePath);
                ketnoi.Open();

                // Duyệt qua từng hàng trong DataTable
                foreach (DataRow row in importedDataTable.Rows)
                {
                    SqlCommand thuchien = new SqlCommand(nameProc, ketnoi);
                    thuchien.CommandType = CommandType.StoredProcedure;
                    using (thuchien)
                    {
                        try
                        {
                            thuchien.Parameters.AddWithValue("@Name", row[1]);
                            // Thực thi câu lệnh chèn
                            thuchien.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                ketnoi.Close();
            }
        }

        public static void LoadExcelData(string filePath, DataGridView dataGridView1)
        {
            using (var package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                //Lấy sheet đầu tiên trong excel
                var worksheet = package.Workbook.Worksheets[0];

                DataTable dataTable = new DataTable();
                bool hasHeader = true; // Sử dụng dòng đầu tiên làm tiêu đề cột

                foreach (var firstRowCell in worksheet.Cells[3, 1, 3, worksheet.Dimension.End.Column])
                {
                    dataTable.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }

                var startRow = hasHeader ? 4 : 1;

                for (int rowNum = startRow; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                {
                    var wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                    DataRow row = dataTable.NewRow();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    dataTable.Rows.Add(row);
                }

                dataGridView1.DataSource = dataTable;
            }
        }

    }
}
