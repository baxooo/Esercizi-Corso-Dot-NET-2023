using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.Repositories
{
    public class MediaRepository<T, TResponse, TRequest> : IRepository<T, TResponse, TRequest>
        where T  : class, new()   // TODO - better constraints
        where TResponse : Media, new() 
        where TRequest : Media, new()
    {
        private readonly GenericDbContext<T, TResponse> _context;
        public MediaRepository(string path)
        {
            _context = new GenericDbContext<T, TResponse>(path);
        }

        /// <summary>
        /// Deletes item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true if item is found and deleted; otherwise, false 
        /// </returns>
        public bool DeleteById(int id)
        {
            if(!_context.Data.Any(a => a.Id == id))
                return false;

            _context.Data.Remove(GetById(id));
            return true;
        }

        /// <summary>
        /// Retrieves all items of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of items to operate on.</typeparam>
        /// <returns>A list of <typeparamref name="TResponse"/> objects.</returns>
        public List<TResponse> GetAll()
        {
            return _context.Data;
        }

        /// <summary>
        /// Retrieves an item of type <typeparamref name="TResponse"/> by its unique identifier.
        /// </summary>
        /// <typeparam name="TResponse">The type of item to retrieve.</typeparam>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The item of type <typeparamref name="TResponse"/> if found; otherwise, default.</returns>
        public TResponse GetById(int id)
        {
            return _context.Data.Where(o => o.Id == id ).FirstOrDefault();
        }

        public bool Update(TRequest media)
        {
            if (!_context.Data.Any(a => a.Id == media.Id))
                return false;

            var rsMedia = _context.Data.Where(m => m.Id == media.Id).FirstOrDefault();
            _context.Data[media.Id] = rsMedia;
            return true;
        }
    }
}
