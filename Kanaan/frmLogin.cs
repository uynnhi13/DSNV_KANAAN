using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using Kanaan_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaan
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        DBHelper DBHelper=new DBHelper();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            int role=Kiemtradangnhap();
            if ( role!= -1)
            {
                this.Hide();
                frmMain panel = new frmMain();
                panel.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản", "Lỗi");
                tbTaiKhoan.Focus();
            }
        }

        private int Kiemtradangnhap()
        {
            int roleIndex = -1;
            DBHelper.GetConnection();
            object result=DBHelper.ExcuteReader("KiemTraTaiKhoan",new string[] {"tendangnhap","matkhau"},new object[] {tbTaiKhoan.Text,tbMatKhau.Text});
            DBHelper.CloseConnection();
            roleIndex=Convert.ToInt32(result);
            return roleIndex;
        }

        private void hylinkForgot_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            this.Hide();
            frmSendMailFPW fpw=new frmSendMailFPW();
            fpw.ShowDialog();
            this.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}