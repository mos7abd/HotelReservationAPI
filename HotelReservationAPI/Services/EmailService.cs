using HotelReservationAPI.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

namespace HotelReservationAPI.Services
{
    public class EmailService 
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public bool SendEmail(MailData mailData)
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = mailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = mailData.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                var MailClient = new SmtpClient();
                MailClient.Connect(_mailSettings.Server, _mailSettings.Port);
                MailClient.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string sendNotification(string message)
        {
            return message;
        }
    }
}
