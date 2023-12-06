using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.Repository
{
    public class MediaRepository<T, Rs, Rq> : IRepository<T, Rs>
        where T : class, new() 
        where Rs : IRating, new()
    {
        private readonly GenericDbContext<T, Rs> _context;
        public MediaRepository(string path)
        {
            _context = new GenericDbContext<T, Rs>(path);
        }
        public bool DeleteById(int id)
        {
            if(!_context.Data.Any(a => a.Id == id))
                return false;

            _context.Data.Remove(GetById(id));
            return true;
        }

        public List<Rs> GetAll()
        {
            return _context.Data;
        }

        public Rs GetById(int id)
        {
            return _context.Data.Where(o => o.Id == id ).FirstOrDefault();
        }

        public bool Update(T media)
        {
            throw new NotImplementedException();
        }
    }
}
