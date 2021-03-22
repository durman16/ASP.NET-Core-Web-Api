using Altamira.Bussiness.Abstract;
using Altamira.DataAccess.Abstract;
using Altamira.Entities;
using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepostory _userRepo;
        public UserManager(IUserRepostory userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepo.CreateUser(user);
            
        }

        public async Task DeleteUser(int id)
        {
            await _userRepo.DeleteUser(id);
        }

        public async Task<User> GetUserById(int id)
        {
            if (id > 0)
            {
                return await _userRepo.GetUserById(id);
            }
            throw new Exception("id can not be less than zero");
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepo.UpdateUser(user);
        }
    }
}
