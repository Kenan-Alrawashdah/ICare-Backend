using ICare.Core.IServices;
using BC = BCrypt.Net.BCrypt;


namespace ICare.Infra.Services
{


    public class PasswordHashingService : IPasswordHashingService
    {


        public string GetHash(string Password)
        {
            // hash password
            var hashedPassword = BC.HashPassword(Password);
            return hashedPassword;
        }

        public bool Authenticate(string Password , string PasswordHashed)
        {
            return BC.Verify(Password, PasswordHashed);
        }

    }
}