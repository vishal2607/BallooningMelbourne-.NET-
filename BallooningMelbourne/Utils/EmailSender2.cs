using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace BallooningMelbourne.Utils
{
    public class EmailSender2
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        
        public void Send2(String toEmail, String subject, String contents, HttpPostedFileBase emailAttachment)
        {
            SendGridMessage obj1 = new SendGridMessage();
            List<EmailAddress> firstlist = new List<EmailAddress>();
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Email User");
            //var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            List<String> secondlist = toEmail.Split(',').ToList();

            for(int i=0; i<secondlist.Count(); i++)
            {
                firstlist.Add(new EmailAddress(secondlist.ElementAt<string>(i)));
            }
            obj1.AddTos(firstlist);
            obj1.From = from;
            obj1.Subject = subject;
            obj1.HtmlContent = "<p>" + contents + "</p>";
            obj1.PlainTextContent = plainTextContent;

            var response = client.SendEmailAsync(obj1);
        }

      
    }
}   