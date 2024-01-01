using Microsoft.AspNetCore.Mvc;
using SpotiAPI.Models.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Interfaces
{
    public interface IBasicRepository<T>
        where T : class,new()
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
