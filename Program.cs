using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendAppPassword
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email Send App Password : SMTP GMAIL");
            string res = SendMail("urvishzadafiya@gmail.com", "Test Subject", "This is test mail body", false);
            if (res == "success")
            {
                Console.WriteLine("Email Send SuccessFul....");
            }
            else
            {
                Console.WriteLine("Email sending fails. Opps! Soemthing wrong.");
            }

            Console.ReadLine();
        }


        public static string SendMail(string toMail, string mailSubject, string mailBody, bool IsBodyHtml)
        {
            string res = string.Empty;

            //<<YOUR EMAIL ADDRESS>>
            string FromMail = "Your@gmail.com";
            //<<APP PASSWORD : GENERATED FROM EMAIL>>
            string Password = "1234 5678 9123 456";

            string Host = "smtp.gmail.com";
            string Port = "587";
            

            try
            {
                using (MailMessage mail = new MailMessage(FromMail, toMail))
                {
                    mail.Body = mailBody;
                    mail.Subject = mailSubject;
                    mail.IsBodyHtml = IsBodyHtml;
                    SmtpClient smtp = new SmtpClient { Host = Host, EnableSsl = true };
                    NetworkCredential networkCredential = new NetworkCredential(FromMail, Password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = networkCredential;
                    smtp.Port = Convert.ToInt32(Port);
                    smtp.Send(mail);
                    res = "success";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return res;
        }
    }
}
