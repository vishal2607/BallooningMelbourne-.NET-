using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace BallooningMelbourne.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";


        public void Send(String toEmail, String subject, String contents, HttpPostedFileBase emailAttachment)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            byte[] fileInBytes = new byte[emailAttachment.ContentLength];
            using (BinaryReader theReader = new BinaryReader(emailAttachment.InputStream))
            {
                fileInBytes = theReader.ReadBytes(emailAttachment.ContentLength);
            }
        }
    }
}