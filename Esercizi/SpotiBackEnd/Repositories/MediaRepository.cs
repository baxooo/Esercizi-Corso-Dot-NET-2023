using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiBackEnd.Repositories
{
    public class MediaRepository<T, Rs, Rq> : IRepository<T, Rs, Rq>
        where T  : class, new()   // TODO - better constraints
        where Rs : Media, new() 
        where Rq : Media, new()
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

        public bool Update(Rq media)
        {
            if (!_context.Data.Any(a => a.Id == media.Id))
                return false;

            _context.Data.Remove(GetById(media.Id));
            //_context.Data.Add(null);
            return true;
        }
    }
}
