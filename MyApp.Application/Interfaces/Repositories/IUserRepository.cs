using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> getAllUserAsync();
        public Task<User?> findUserByIDAsync(int id);
        public Task<User> addUserAsync(User user);
        public Task<bool> deleteUserAsync(int id);
        public Task SaveChangesAsync();
    }
}
