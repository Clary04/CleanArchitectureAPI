using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<User> CreateUser(User user)
        {
           
            user.DateCreated = DateTime.Now;
           
            _appDBContext.Users.Add(user); 
            await _appDBContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int userID)
        {
            var user = await _appDBContext.Users.FirstOrDefaultAsync(u => u.ID == userID);

            if (user == null) return;

            _appDBContext.Users.Remove(user);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int userID)
        {
           return await _appDBContext.Users.FirstOrDefaultAsync(u => u.ID == userID);
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _appDBContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var userUpdated = await _appDBContext.Users.FirstOrDefaultAsync(u => u.ID == user.ID);

            if (userUpdated == null) { return new User(); }

            userUpdated.LastModified = DateTime.Now;

            return userUpdated;

        }
    }
}
