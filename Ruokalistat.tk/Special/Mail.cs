using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruokalistat.tk.Special
{
    public static class Mail
    {
        private static SmtpClient smtp = new SmtpClient();
        
        public static async Task Laheta(string email, string subject, string body)
        {
            await smtp.ConnectAsync(Properties.Resources.smtpHost, Convert.ToInt32(Properties.Resources.smtpPort), Convert.ToBoolean(Properties.Resources.useSSL));
            if(!string.IsNullOrEmpty(Properties.Resources.username) && !string.IsNullOrEmpty(Properties.Resources.password))
            {
                await smtp.AuthenticateAsync(Properties.Resources.username, Properties.Resources.password);
            }

            var viesti = new MimeKit.MimeMessage();

            viesti.To.Add(MimeKit.InternetAddress.Parse(email));
            viesti.From.Add(MimeKit.MailboxAddress.Parse(Properties.Resources.sender));
            viesti.Sender = MimeKit.MailboxAddress.Parse(Properties.Resources.sender);
            viesti.Subject = subject;

            var viestinbody = new MimeKit.BodyBuilder();

            viestinbody.HtmlBody = body;

            viesti.Body = viestinbody.ToMessageBody();

            await smtp.SendAsync(viesti);
        }
    }
}
