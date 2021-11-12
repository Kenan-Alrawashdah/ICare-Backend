using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IPasswordHashingService
    {
        bool Authenticate(string Password, string PasswordHashed);
        string GetHash(string Password);
    }
}
