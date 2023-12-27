using Microsoft.AspNetCore.Mvc;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<ActionResult<UserListener>> Login(string username,string password);
        public Task<ActionResult<UserListener>> UpdateAsync( UserListener entity);
    }
}
