using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
            _context.Entry(user).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }



        public async Task<User> SearchUser(int userID)
        {
            var user = await _context.Users
                .Where(x => x.ID == userID)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> ValidateExistence(User user)
        {
            var validateExistence = await _context.Users
                .AnyAsync(x => x.Username == user.Username);
            return validateExistence;
        }

        public async Task<bool> ValidateEmail(string email)
        {
            var validateEmail = await _context.Users
                .AnyAsync(x => x.Email == email);
            return validateEmail;
        }
    }
}
