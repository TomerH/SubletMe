using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Services
{
    public class Mailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        public Mailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587;
            GmailSSL = true;
            GmailUsername = "tomerhssn@gmail.com";
            GmailPassword = "Tomer123Gmail";
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }

        public void SendMatch(dynamic Context, dynamic MatchedItems, string Id, string itemKind)
        {
            string userName;
            string laseName;
            string userEmail;

            foreach (var item in MatchedItems)
            {
                userEmail = Context.Users.Find(item.UserId).Email;
                userName = Context.Users.Find(item.UserId).Name;
                laseName = Context.Users.Find(item.UserId).LastName;

                this.ToEmail = userEmail;
                this.Subject = "Sublet.me - התאמה אפשרית";
                this.Body =
                    "שלום " + userName + " " + laseName + "," +
                    "<br>" +
                    "ייתכן ומצאנו בישבילך התאמה אפשרית ל" + itemKind + " שפרסמת ב" + item.City + ", " + item.Street +
                    "<br>" +
                    Context.Users.Find(Id).Name + " " + Context.Users.Find(Id).LastName + " מחפש לסבלט דירה כזו באיזור שבו פרסמת." +
                    "<br>" +
                    "תוכל ליצור איתו קשר בפלאפון: " + Context.Users.Find(Id).Phone +
                    "<br>" +
                    "מקווים שהצלחנו לעזור," +
                    "<br>" +
                    "צוות Sublet.me";
                this.IsHtml = true;
                this.Send();
            }
        }
    }
}
