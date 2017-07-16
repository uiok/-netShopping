using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace shoppingCart.Manager
{
    public class EmailManager : IIdentityMessageService
    {
        private const string ACCOUNT = "";
        private const string PASSWORD = "";
        private const string SENTNAME = "";
        private SmtpClient _smtpServer;

        public EmailManager()
        {
            _smtpServer = new SmtpClient();
            _smtpServer.Credentials = new System.Net.NetworkCredential(ACCOUNT, PASSWORD);
            _smtpServer.Port = 587;
            _smtpServer.Host = "smtp.gmail.com";
            _smtpServer.EnableSsl = true;
        }

        public Task SendAsync(IdentityMessage message)
        {
            // 將您的電子郵件服務外掛到這裡以傳送電子郵件。
            return Task.FromResult(0);
        }

        public Task SendAsync(List<string> ReceivingMails, string SentName, string MailSubject, string MailBody)
        {
            return Task.Run(() => SendMail(ReceivingMails, MailSubject, MailBody));
        }


        public  void SendMail(List<string> ReceivingMails, string MailSubject, string MailBody)
        {
            try
            {
                MailMessage Mail = new MailMessage();  //信件本體宣告

                Mail.Priority = MailPriority.High;  //優先等級
                Mail.Subject = MailSubject; //主旨
                Mail.From = new MailAddress(ACCOUNT, SENTNAME);

                foreach (string ReceivingMail in ReceivingMails)
                { Mail.Bcc.Add(ReceivingMail); }//收件人

               

                //處理Mail的內容
                Mail.Body = MailBody;  //Email 內容
                Mail.IsBodyHtml = true;  // 設定Email 內容為HTML格式
                Mail.BodyEncoding = System.Text.Encoding.UTF8;

                _smtpServer.Send(Mail);


                Mail.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}