using Altamira.Bussiness.Abstract;
using Altamira.DataAccess.Abstract;
using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.Bussiness.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAuthRepostory _authRepostory;
        public AuthManager(IAuthRepostory authRepo)
        {
            _authRepostory = authRepo;
        }
        public User AuthenticateUser(string email, string password)
        {
            return _authRepostory.AuthenticateUser(email, password);
        }
    }
}
