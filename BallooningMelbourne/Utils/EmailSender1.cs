using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace BallooningMelbourne.Utils
{
    public class EmailSender1
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

 
        public void Send1(String toEmail1, String toEmail2, String subject, String contents, HttpPostedFileBase emailAttachment)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Email User");
            //var to = new EmailAddress(toEmail1, "");
            var to = new List<EmailAddress>
            {
                new EmailAddress(toEmail1, ""),
                new EmailAddress(toEmail2, ""),

            };
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            var showAllRecipients = false;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent, showAllRecipients);
            byte[] fileInBytes = new byte[emailAttachment.ContentLength];
            using (BinaryReader theReader = new BinaryReader(emailAttachment.InputStream))
            {
                fileInBytes = theReader.ReadBytes(emailAttachment.ContentLength);
            }

            string fileAsString = Convert.ToBase64String(fileInBytes);
            msg.AddAttachment(emailAttachment.FileName, fileAsString);
            var response = client.SendEmailAsync(msg);
        }


    }
}