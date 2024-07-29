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
    public partial class PanelControl : Form
    {
        public PanelControl()
        {
            InitializeComponent();
        }

        private void boPhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 3))
            {
                this.pnlContent.Controls.Clear();
                QuanLyBoPhan bp = new QuanLyBoPhan();
                bp.TopLevel = false;
                bp.AutoScroll = true;
                bp.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(bp);
                bp.Show();
            }
            else
            {
                HienThiNoPer();
            }
        }

        private void HienThiNoPer()
        {
            this.pnlContent.Controls.Clear();
            NoPermission np=new NoPermission();
            np.TopLevel = false;
            np.AutoScroll = true;
            np.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(np);
            np.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 4))
            {
                this.pnlContent.Controls.Clear();
                QuanLyChucVu cv = new QuanLyChucVu();
                cv.TopLevel = false;
                cv.AutoScroll = true;
                cv.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(cv);
                cv.Show();
            }
            else
            {
                HienThiNoPer();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 2))
            {
                this.pnlContent.Controls.Clear();
                QuanLyNhanSu ns = new QuanLyNhanSu();
                ns.TopLevel = false;
                ns.AutoScroll = true;
                ns.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(ns);
                ns.Show();
            }
            else
            {
                HienThiNoPer();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 1))
            {
                this.pnlContent.Controls.Clear();
                frmLstTaiKhoan taiKhoan = new frmLstTaiKhoan();
                taiKhoan.TopLevel = false;
                taiKhoan.AutoScroll = true;
                taiKhoan.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(taiKhoan);
                taiKhoan.Show();
            }
            else
            {
                HienThiNoPer();
            }
        }

        private void quyềnTruyCậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.CheckPhanQuyen("Read", 5))
            {
                pnlContent.Controls.Clear();
                QLPhanQuyen qLPhanQuyen = new QLPhanQuyen();
                qLPhanQuyen.TopLevel = false;
                qLPhanQuyen.AutoScroll = true;
                qLPhanQuyen.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(qLPhanQuyen);
                qLPhanQuyen.Show();
            }
            else
            {
                HienThiNoPer();
            }
        }

    }
}
