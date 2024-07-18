using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSNV_KANAAN
{
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }

        public string tendangnhap, matkhau;

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            tbTenDN.Text = tendangnhap;
            tbMK.Text = matkhau;
        }


    }
}