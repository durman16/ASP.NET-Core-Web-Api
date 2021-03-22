using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.DataAccess.Abstract
{
    public interface IAuthRepostory
    {
        User AuthenticateUser(string email, string password);
    }
}
