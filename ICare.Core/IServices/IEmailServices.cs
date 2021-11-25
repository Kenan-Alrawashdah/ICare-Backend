using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IEmailServices
    {
        void SendEmail(string To, string Subject, string Body);
    }
}
