using SpotiAPI.Models.ModelsDTO;
using System.Threading.Tasks;

namespace SpotiAPI.Interfaces
{
    public interface IPlaylistsRepository<T, TDto> : IBasicRepository<TDto>
        where T : class, new()
        where TDto : class, new()
    {
        public Task<TDto> AddNewAsync(T entity);
        public Task<TDto> UpdateAsync(int id, T entity);

        public Task<TDto> DeleteAsync(int id);
    }
}
