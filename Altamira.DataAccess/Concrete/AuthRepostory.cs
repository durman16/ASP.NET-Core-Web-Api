using Altamira.DataAccess.Abstract;
using Altamira.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.DataAccess.Concrete
{
    public class AuthRepostory : IAuthRepostory
    {
        public User AuthenticateUser(string email, string password)
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                return userDbContext.Users
                                    .Where(u => u.email == email && u.password == password)
                                    .Include(s => s.address).Include(s => s.company).Include(s => s.address.geo)
                                    .FirstOrDefault();
            }
        }
    }
}
