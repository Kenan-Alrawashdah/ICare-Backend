using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResultDTO> ValidateAccressTokenAsync(string accressToken);
        Task<FacebookUserInfoResultDTO> GetUserInfoAsync(string accressToken);
    }
}
