using System.Collections.Generic;

namespace ClientDataLayer.Interfaces
{
    public interface IOrderRepository<T, TResponse>
        where T : class,new() 
        where TResponse : class,new()
    {
        public bool StoreOrder(T item);
        public List<TResponse> GetAll();
    }
}