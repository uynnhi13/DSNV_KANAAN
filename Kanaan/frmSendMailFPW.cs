using DevExpress.XtraEditors;
using Kanaan_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Kanaan
{
    public partial class frmSendMailFPW : DevExpress.XtraEditors.XtraForm
    {
        DBHelper dBHelper = new DBHelper();
        private string OTP;
        public frmSendMailFPW()
        {
            InitializeComponent();
            SetTextBox(false);
        }

        private void SetTextBox(bool b)
        {
            tbOTP.Enabled = b;
            tbPass.Enabled = b;
            tbPass2.Enabled = b;
            btSave.Visible = b;
            btSend.Visible = !b;
        }

        private string CheckEmail(string email)
        {
            if(email == null || email.Length == 0) { return "Vui lòng nhập Gmail"; }

            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

            // Tạo đối tượng Regex và kiểm tra địa chỉ email
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(email))
            {
                dBHelper.GetConnection();
                object Check = dBHelper.ExcuteReader("CheckGmail", new string[] { "gmail" }, new object[] { tbGmail.Text });
                dBHelper.CloseConnection();
                if (Convert.ToBoolean(Check))
                    return "";
                else return "Gmail này chưa được đăng ký tài khoản, vui lòng kiểm tra lại";
            }
            else return "Định dạng Gmail không đúng, vui lòng kiểm tra lại";
            

        }

        private void GuiMail(string to)
        {
            string from = ConfigurationManager.AppSettings["Email"];
            string pass = ConfigurationManager.AppSettings["Password"];
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            OTP = GenerateOTP();
            mail.Subject = "Cài đặt lại mật khẩu";

            mail.IsBodyHtml = true;
            mail.Body = $@"
            <html>
            <body>
                <p>Đây là mã OTP của bạn, vui lòng không chia sẻ với bất kỳ ai:</p>
                <p><strong><span style='color: red;'>{OTP}</span></strong></p>
            </body>
            </html>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Vui lòng check mail để nhận mã OTP", "Email");
                SetTextBox(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email");
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string to;

            to=tbGmail.Text;
            string checkGmail = CheckEmail(to);
            if (!string.IsNullOrEmpty(checkGmail))
            {
                MessageBox.Show(checkGmail);
                return;
            }

            GuiMail(to);
        }

        


        public static string GenerateOTP()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                Random random = new Random();
                int randomNumber = random.Next(100000, 1000000);
                string formattedNumber = randomNumber.ToString("D6");
                return formattedNumber; 
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbOTP.Text == OTP)
            {
                dBHelper.ExcuteReader("UpdatePassword", new string[] { "gmail", "pass" }, new object[] { tbGmail.Text, tbPass.Text });
                this.Close();
            }
        }

        private void CheckPassword(string password, string password2)
        {
            if (password == password2)
            {
                MessageBox.Show("Vui lòng kiểm tra lại mật khẩu vừa nhập");
            }
            else
            {
               
            }
        }
    }
}
