using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class UserTokensServices : IUserTokensServices
    {
        private readonly IUserTokensRepository _userRepository;

        public UserTokensServices(IUserTokensRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool Create(UserTokens userTokensModle)
        {
            return _userRepository.Create(userTokensModle);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<UserTokens> GetAll()
        {
            return _userRepository.GetAll();

        }

        public UserTokens GetById(int id)
        {
            return _userRepository.GetById(id);

        }

        public bool Update(UserTokens userTokensModle)
        {
            return _userRepository.Update(userTokensModle);

        }
    }
}
