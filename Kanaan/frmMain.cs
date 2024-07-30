using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Kanaan
{
    public partial class frmMain : Form
    {
        frmEmployee employee = new frmEmployee();
        public frmMain()
        {
            InitializeComponent();
            guna2GradientPanel2.Visible = false;
        }


        private void frmEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (employee.status == "CREATE")
            {
                ShowFormDetail("CREATE","");
            }
            else if (employee.status == "EDIT" && employee.MaNV!="")
            {
                ShowFormDetail("EDIT", employee.MaNV);
            }
        }

        private void frmDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            employee=new frmEmployee();
            employee.TopLevel = false;
            flowLayoutPanel1.Controls.Add(employee);
            employee.Show();
            employee.FormClosed += frmEmployee_FormClosed;
        }

        private void ShowFormDetail(string status, string MaNV)
        {
            frmDetailsEmp details = new frmDetailsEmp(status,MaNV);
            details.FormClosed += frmDetails_FormClosed;
            details.status = status;
            details.MaNV = MaNV;
            flowLayoutPanel1.Controls.Clear();
            details.TopLevel = false;
            flowLayoutPanel1.Controls.Add(details);
            details.Show();
        }

        private void btNhanSu_MouseMove(object sender, MouseEventArgs e)
        {
            guna2GradientPanel2.Visible = true;
        }

        private void btNhanSu_MouseLeave(object sender, EventArgs e)
        {
            ButtonHover(guna2GradientPanel2, btNhanSu);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(guna2GradientPanel2.Visible)
            {
                guna2GradientPanel2.Visible = true;
            }
        }

        private void guna2GradientPanel2_MouseLeave(object sender, EventArgs e)
        {
            ButtonHover(guna2GradientPanel2, btNhanSu);
        }

        private void ButtonHover(Guna2GradientPanel pnl, Guna2GradientButton bt)
        {
            if (!bt.Bounds.Contains(PointToClient(Cursor.Position)) &&
            !pnl.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                pnl.Visible = false; // Ẩn panel nếu chuột không nằm trên cả hai
            }
        }

        private void btlstEmp_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            employee=new frmEmployee();
            //if (employee.IsDisposed)
            //    employee = new frmEmployee();

            employee.FormClosed += frmEmployee_FormClosed;
            employee.TopLevel = false;
            flowLayoutPanel1.Controls.Add(employee);
            employee.Show();
        }

        private void btDetailsNV_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            frmDetailsEmp detaill = new frmDetailsEmp("","");
            detaill.TopLevel = false;
            flowLayoutPanel1.Controls.Add(detaill);
            detaill.Show();
        }
    }
}
