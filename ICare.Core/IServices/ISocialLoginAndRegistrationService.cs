using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface ISocialLoginAndRegistrationService
    {
        public  Task<RegistrationApiDTO.Response> LoginAndRegistrationUsingSocial(RegistrationApiDTO.Request request);
    }
}
