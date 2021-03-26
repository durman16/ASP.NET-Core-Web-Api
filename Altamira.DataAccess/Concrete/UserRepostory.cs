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
        public AltamiraDbContext _userDbContext { get; set; }
        public UserRepostory(AltamiraDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            //TODO : FakeData metodunda da aynı yapıyı kullanmışsın. Bunu bir helper metod üzerinden kod çoklamadan kullanman daha iyi olur.
            string password = "abcdefghijklmnoprstuvwxyz0123456789";
            Random random = new Random();
            char[] newpass = new char[5];
            for (int i = 0; i < 5; i++)
            {
                newpass[i] = password[(int)(35 * random.NextDouble())];
            }
            user.password = new string(newpass);
            _userDbContext.Add(user);
            await _userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var deleteduser = await GetUserById(id);
            _userDbContext.geos.Remove(deleteduser.address.geo);
            _userDbContext.Addresses.Remove(deleteduser.address);
            _userDbContext.Companies.Remove(deleteduser.company);
            _userDbContext.Users.Remove(deleteduser);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userDbContext.Users
                                .Where(u => u.id == id)
                                .Include(s => s.address).Include(s => s.company).Include(s => s.address.geo)
                                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userDbContext.Users.Include(s => s.address).Include(s => s.company).Include(s => s.address.geo).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _userDbContext.Update(user);
            await _userDbContext.SaveChangesAsync();
            return user;
        }
    }
}
