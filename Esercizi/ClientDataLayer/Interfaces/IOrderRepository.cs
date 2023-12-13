using System.Collections.Generic;

namespace ClientDataLayer.Interfaces
{
    public interface IOrderRepository<T, TResponse>
    {
        public bool StoreOrder(T item);
        public List<TResponse> GetAll();
        public TResponse GetById(int id);
    }
}