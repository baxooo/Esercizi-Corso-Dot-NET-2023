using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.ModelsDTO;
using SpotiBackEnd.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.Repositories
{
    public class UserRepository<T, Rs, Rq> : IUserRepository<T, Rs, Rq>
        where T  : User, new()
        where Rs : User, new() // TODO - better constraints
        where Rq : User, new()
    {
        private readonly GenericDbContext<T, Rs> _context;
        public UserRepository(string path)
        {
            _context = new GenericDbContext<T, Rs>(path);
        }

        public Rs GetUser(string username, string password)
        {
            //fake login
            if(string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Invalid credentials");

            if (username == "user" && password == "user")
                return _context.Data.Where(u => u.Id == 1).FirstOrDefault();
            else 
                return null;
        }
    }
}
