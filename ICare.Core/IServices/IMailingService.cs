using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
   public interface IMailingService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
