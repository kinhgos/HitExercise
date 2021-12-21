using FluentEmail.Core;
using FluentEmail.Smtp;
using HitExercise.MVC.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.IO;

using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HitExercise.MVC.HelperClasses
{
    [Serializable]
    public class SendEmail
    {
        public string url { get; set; }

        public int port { get; set; }
        public bool ssl { get; set; }

        public string userName { get;  set; }

        public string password { get;  set; }

        public SendEmail GetSettings()
        {           

            var filename = @"D:\PeopleCert Education\DEV\HitExercise\HitExercise.MVC\HelperClasses\EmailSettings.json";

            if (File.Exists(filename))
            {
                SendEmail sendEmail = JsonConvert.DeserializeObject<SendEmail>(File.ReadAllText(filename));


                return sendEmail;
            }
            throw new ArgumentNullException("File does not exist");
            
        }

        public async Task SendEmailToSupplier(SupplierDto supplierDto)
        {
            var emailSettings = GetSettings();
            var sender = new SmtpSender(() => new SmtpClient(emailSettings.url)
            {
                UseDefaultCredentials = false,
                EnableSsl = emailSettings.ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = emailSettings.port,
                Credentials = new NetworkCredential(emailSettings.userName, emailSettings.password)
            });



            StringBuilder template =new StringBuilder();
            template.AppendLine($"Dear {supplierDto.Name},");
            template.AppendLine("We Welcome you to Hit Exercise.");
            template.AppendLine("Looking forward to doing Business with you.");
            template.AppendLine("Kind Regards");
            template.AppendLine("- Hit Exercise Team");




            Email.DefaultSender = sender;
            

            var email = await Email
                .From(emailSettings.userName)
                .To(supplierDto.Email, supplierDto.Name)
                .Subject("Welcome to Hit Exercise")
                .Body(template.ToString())
                .SendAsync();

            
        }
    }
}