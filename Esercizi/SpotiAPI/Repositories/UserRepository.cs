using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace SpotiAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly SpotifyContext _context;

        public UserRepository(ILogger<UserRepository> logger, SpotifyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<UserListener>> Login(string username, string password)
        {
            //Fake login
            if (username != "user" && password != "user")
            {
                _logger.LogInformation($"User {username} tried to login");
                return null;
            }

            try
            {
                var user = await _context.UserListeners.FirstOrDefaultAsync(u => u.Id == 1);
                if (user == null)
                {
                    _logger.LogInformation($"User 1 not found, populate the Db");
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while trying to retrieve from user table");
                throw;
            }
        }

        public async Task<ActionResult<UserListener>> UpdateAsync(UserListener entity)
        {
            try
            {
                _logger.LogInformation($"Updating user {entity.Id}");
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while trying to update user {entity.Id}");
                throw;
            }
        }
    }
}
