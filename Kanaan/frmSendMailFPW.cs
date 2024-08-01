using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaan
{
    public partial class frmSendMailFPW : DevExpress.XtraEditors.XtraForm
    {
        public frmSendMailFPW()
        {
            InitializeComponent();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string from = "nle142103@gmail.com";
            string pass = "tlpkzluvjgyeqsbz";
            string to,content;

            to=tbTaiKhoan.Text;
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From=new MailAddress(from);
            mail.Subject = "Hello World";
            mail.Body = "Chào buổi sáng";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials=new NetworkCredential(from,pass);
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Gửi mail thành công", "Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email");
            }
        }
    }
}