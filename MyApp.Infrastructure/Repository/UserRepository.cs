using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> addUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> deleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user != null)
                return false;

            _context.Users.Remove(user);

            return true;
        }

        public async Task<User?> findUserByIDAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if(user == null)
                return null;

            return user;
        }

        public async Task<IEnumerable<User>> getAllUserAsync()
        {
            var user = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            return user;
        }

        public async Task<bool> isAlreadyVotedAsync(int id)
        {
            return await _context.Users
                .AnyAsync(u => u.UserId == id && u.isVoted);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
