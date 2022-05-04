using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<bool> ValidateExistence(User user);
        Task<bool> ValidateEmail(string email);
        Task<User> SearchUser(int userID);
        Task DeleteUser(User user);
    }
}
