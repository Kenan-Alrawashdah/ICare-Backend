using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IFacebookService
    {
        Task<LoginApiDTO.Response> LoginWithFacebookAsync(string accessToken);
    }
}
