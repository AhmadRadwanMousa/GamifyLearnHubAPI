using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class MailService : IMailService
    {
        private readonly MailDetails _mailDetails;
        public MailService(IOptions<MailDetails> mailDetails)
        {
            _mailDetails = mailDetails.Value;
            
        }
        public void SendEmail(MailData mailData)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mailDetails.SenderName, _mailDetails.SenderEmail));
            message.To.Add(new MailboxAddress(mailData.EmailToName, mailData.EmailTo));
            message.Subject = mailData.EmailSubject;
            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = mailData.EmailBody
            };

            message.Body = bodyBuilder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                client.Connect(_mailDetails.Server, _mailDetails.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_mailDetails.UserName, _mailDetails.Password);
                client.Send(message);
                client.Disconnect(true);
            }
           
        }
    }
}
