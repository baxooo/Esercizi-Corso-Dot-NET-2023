using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ClientDataLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientDataLayer.Repositories
{
    public class OrderRepository<T, TResponse> : IOrderRepository<T, TResponse>
        where T : class, new()
        where TResponse : class, new()
    {
        private IDbContext<T, TResponse> _context;
        public OrderRepository(IServiceProvider service)
        {
            _context = service.GetRequiredService<IDbContext<T, TResponse>>();
        }

        
        public List<TResponse> GetAll()
        {
            return _context.Data.ToList();
        }

        public bool StoreOrder(T item)
        {
            if (item == null)
                return false;
            List<T> list  = new List<T> { item };
            _context.WriteData<T>(list);
            return true;
        }
    }
}
