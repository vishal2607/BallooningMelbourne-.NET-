using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace BallooningMelbourne.Utils
{
    public class EmailSender3
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, HttpPostedFileBase emailAttachment)
        {
            var client = new SendGridClient(API_KEY);

            var from = new EmailAddress("noreply@localhost.com", "Ballooning Melbourne");
            String[] pushList = toEmail.Split(',');
            List<EmailAddress> toList = new List<EmailAddress>();
            for (int j = 0; j < pushList.Length; j++)
            {
                toList.Add(new EmailAddress(pushList[j], ""));
            }

            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, toList, subject, plainTextContent, htmlContent);
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