using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.DataAccess.Abstract
{
    public interface IUserRepostory
    {
        Task<List<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserById(int id);
    }
}
