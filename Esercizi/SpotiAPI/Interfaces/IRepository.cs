using Microsoft.AspNetCore.Mvc;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Interfaces
{
    public interface IRepository<T> 
        where T : class, new()
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<ActionResult<T>> AddNewAsync(T entity);
        public Task<ActionResult<T>> UpdateAsync(int id,T entity);
        public Task<ActionResult<T>> DeleteAsync(int id);
    }
}
