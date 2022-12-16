using _06_Entity.Settings;
using _06_Entity.ViewModel;
using MailKit.Net.Smtp;
using MimeKit;
// - Rajouter le PACKAGE MAILKIT
namespace _06_Entity.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _mailSettings;

        public EmailService(EmailSettings mailSettings)
        {
            _mailSettings = mailSettings;

            //_mailSettings = new()
            //{
            //    Mail = "jackeline.conroy9@ethereal.email",
            //    DisplayName = "Jackeline Conroy",
            //    Password = "Gbsm6k42F3V7Qy9dPq",
            //    Host = "smtp.ethereal.email",
            //    Port = 587
            //};
        }

        public async Task SendEmailAsync(EmailViewModel vm)
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(vm.FromEmail, _mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(_mailSettings.Mail));

            email.Subject = vm.Subject;

            BodyBuilder body = new BodyBuilder(); 
            if(vm.Attachments is not null)
            {
                byte[] fileBytes;
                foreach(var file in vm.Attachments)
                {
                    if (file.Length>0)
                    {
                        using (MemoryStream ms = new())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        body.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            body.HtmlBody = vm.Body;

            email.Body = body.ToMessageBody();

            using(SmtpClient smtp = new())
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

                await smtp.SendAsync(email);
                /*smtp.Disconnect(true);
                smtp.Dispose();*/ // Inutile dans une clause 'using'
            }
        }
    }

}
