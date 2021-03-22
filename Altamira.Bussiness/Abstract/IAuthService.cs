using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.Bussiness.Abstract
{
    public interface IAuthService
    {
        User AuthenticateUser(string email, string password);
    }
}
