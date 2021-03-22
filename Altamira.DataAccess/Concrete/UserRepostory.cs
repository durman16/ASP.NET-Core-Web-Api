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
    public class UserRepostory : IUserRepostory
    {
        public async Task<User> CreateUser(User user)
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                string password = "abcdefghijklmnoprstuvwxyz0123456789";
                Random random = new Random();
                char[] newpass = new char[5];
                for(int i = 0; i < 5; i++)
                {
                    newpass[i] = password[(int)(35 * random.NextDouble())];
                }
                user.password = new string(newpass);
                userDbContext.Add<User>(user);
                await userDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                var deleteduser = await GetUserById(id);
                userDbContext.geos.Remove(deleteduser.address.geo);
                userDbContext.Addresses.Remove(deleteduser.address);
                userDbContext.Companies.Remove(deleteduser.company);
                userDbContext.Users.Remove(deleteduser);
                await userDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                return await userDbContext.Users
                                    .Where(u => u.id == id)
                                    .Include(s => s.address).Include(s => s.company).Include(s => s.address.geo)
                                    .FirstOrDefaultAsync();
            }
        }

        public async Task<List<User>> GetUsers()
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                return await userDbContext.Users.Include(s => s.address).Include(s => s.company).Include(s => s.address.geo).ToListAsync();
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var userDbContext = new AltamiraDbContext())
            {
                userDbContext.Update(user);
                await userDbContext.SaveChangesAsync();
                return user;

            }
        }
    }
}
