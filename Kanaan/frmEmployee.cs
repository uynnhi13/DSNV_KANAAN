using DevExpress.Data.Browsing;
using Kanaan_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaan
{
    public partial class frmEmployee : Form
    {
        DBHelper dBHelper;
        DO_Information information;
        public string status = "";
        public string MaNV = "";
        bool b=false;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void SetButton(bool b)
        {
            btEdit.Enabled = b;
            btDel.Enabled = b;
            btCreate.Enabled = !b;
        }

        private void Reset()
        {
            tbMaNV.Text = "";
            tbTen.Text = "";
            cbBP.Text = "";
            cbCV.Text = "";
        }

        public async void LoadThongTin()
        {
            dBHelper = new DBHelper();
            DataTable dt= new DataTable();

            dt = dBHelper.return_Table("GetEmployeeData", new string[] { "" }, new object[] { });

            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
                await Task.Delay(100);
                gridView1.BestFitColumns();
            }
            else
            {
                gridControl1.DataSource = null;
            }

            Reset();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow selectRow = gridView1.GetDataRow(e.FocusedRowHandle);

            if(selectRow != null)
            {
                tbTen.Text = selectRow[1].ToString();
                tbMaNV.Text = selectRow[0].ToString();
                cbBP.Text = selectRow[4].ToString();
                cbCV.Text = selectRow[5].ToString();
            }

            SetButton(true);
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            DBHelper dbHelper = new DBHelper();
            information = new DO_Information();
            LoadThongTin();
            gridView1.FocusedRowChanged += gridView_FocusedRowChanged;
            cbBP = information.Load_cbb(cbBP, "Department_tab");
            cbCV = information.Load_cbb(cbCV, "Jobtitle_tab");
            SetButton(b);
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            status = "CREATE";
            this.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            status = "EDIT";
            MaNV=tbMaNV.Text;
            this.Close();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            DialogResult dgl = MessageBox.Show("Xác nhận xóa nhân viên có mã " + tbMaNV.Text,"Cảnh báo",MessageBoxButtons.YesNo);
            if(dgl == DialogResult.Yes)
            {
                dBHelper.execStoreProcedure("XoaNhanVienVaTaiKhoan", new string[] { "@Emp_code" }, new object[] { tbMaNV.Text });
                MessageBox.Show("Xóa thành công nhân viên có mã " + tbMaNV.Text);
            }
            LoadThongTin();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            SetButton(false);
        }
    }
}
