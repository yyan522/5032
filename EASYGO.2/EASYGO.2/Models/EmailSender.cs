using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EASYGO._2.Models
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "EasyGo Car rental system");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}