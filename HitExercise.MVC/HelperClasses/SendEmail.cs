using FluentEmail.Core;
using FluentEmail.Smtp;
using HitExercise.MVC.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Configuration;
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
        private string url { get; set; }

        private int port { get; set; }
        private bool ssl { get; set; }

        private string userName { get;  set; }

        private string password { get;  set; }

        public SendEmail()
        {
            url = ConfigurationManager.AppSettings["url"];
            port = int.Parse(ConfigurationManager.AppSettings["port"]);
            ssl = bool.Parse(ConfigurationManager.AppSettings["ssl"]);
            userName = ConfigurationManager.AppSettings["userName"];
            password = ConfigurationManager.AppSettings["password"];

        }

        public async Task SendEmailToSupplier(SupplierDto supplierDto)
        {
            
            var sender = new SmtpSender(() => new SmtpClient(url)
            {
                UseDefaultCredentials = false,
                EnableSsl = ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = port,
                Credentials = new NetworkCredential(userName, password)
            });



            StringBuilder template =new StringBuilder();
            template.AppendLine($"Dear {supplierDto.Name},");
            template.AppendLine("We Welcome you to Hit Exercise.");
            template.AppendLine("Looking forward to doing Business with you.");
            template.AppendLine("Kind Regards");
            template.AppendLine("- Hit Exercise Team");




            Email.DefaultSender = sender;
            

            var email = await Email
                .From(userName)
                .To(supplierDto.Email, supplierDto.Name)
                .Subject("Welcome to Hit Exercise")
                .Body(template.ToString())
                .SendAsync();

            
        }
    }
}