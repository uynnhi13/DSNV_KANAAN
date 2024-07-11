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

        private void PanelControl_Load(object sender, EventArgs e)
        {
            QuanLyNhanSu ns=new QuanLyNhanSu();
            ns.TopLevel = false;
            ns.AutoScroll = true;
            ns.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(ns);
            ns.Show();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void nhanSuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem_Click(sender, e);
            this.pnlContent.Controls.Clear();
            QuanLyNhanSu ns = new QuanLyNhanSu();
            ns.TopLevel = false;
            ns.AutoScroll = true;
            ns.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(ns);
            ns.Show();
        }


        private void boPhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem_Click(sender, e);
            this.pnlContent.Controls.Clear();
            QuanLyBoPhan bp=new QuanLyBoPhan();
            bp.TopLevel = false;
            bp.AutoScroll = true;
            bp.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(bp);
            bp.Show();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            // Đặt lại màu nền cho tất cả các mục
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.Control;
            }

            // Đặt màu nền cho mục được chọn
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                clickedItem.BackColor = Color.LightBlue;
            }
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem_Click(sender, e);
            this.pnlContent.Controls.Clear();
            QuanLyChucVu cv=new QuanLyChucVu();
            cv.TopLevel = false;
            cv.AutoScroll = true;
            cv.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(cv);
            cv.Show();
        }
    }
}
