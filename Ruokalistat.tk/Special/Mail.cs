using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Ruokalistat.tk.Special
{
    public class Mail : IEmailSender
    {
        private SmtpClient smtp = new SmtpClient();
        
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            await smtp.ConnectAsync(Digiruokalista.com.Properties.Resources.smtpHost, Convert.ToInt32(Digiruokalista.com.Properties.Resources.smtpPort), Convert.ToBoolean(Digiruokalista.com.Properties.Resources.useSSL));
            if(!string.IsNullOrEmpty(Digiruokalista.com.Properties.Resources.username) && !string.IsNullOrEmpty(Digiruokalista.com.Properties.Resources.password))
            {
                await smtp.AuthenticateAsync(Digiruokalista.com.Properties.Resources.username, Digiruokalista.com.Properties.Resources.password);
            }

            var viesti = new MimeKit.MimeMessage();

            viesti.To.Add(MimeKit.InternetAddress.Parse(email));
            viesti.From.Add(MimeKit.MailboxAddress.Parse(Digiruokalista.com.Properties.Resources.sender));
            viesti.Sender = MimeKit.MailboxAddress.Parse(Digiruokalista.com.Properties.Resources.sender);
            viesti.Subject = subject;

            var viestinbody = new MimeKit.BodyBuilder();

            viestinbody.HtmlBody = body;

            viesti.Body = viestinbody.ToMessageBody();

            await smtp.SendAsync(viesti);
        }
    }
}
