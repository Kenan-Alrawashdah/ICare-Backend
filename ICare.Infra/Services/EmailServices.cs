using ICare.Core.Constants;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;


namespace ICare.Infra.Services
{
    public class EmailServices : IEmailServices
    {


        public void SendEmail(string To , string Subject, string Body)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.From = new MailAddress(ApplicationConstants.WebsiteEmail);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(ApplicationConstants.WebsiteEmail, ApplicationConstants.WebSiteEmailPassword);
            smtp.Send(mm);
        }



    }
}
