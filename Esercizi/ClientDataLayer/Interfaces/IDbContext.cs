using System.Collections.Generic;

namespace ClientDataLayer.Interfaces
{
    public interface IDbContext<T,TResponse>
    {
        public List<TResponse> Data { get; set; }
        public void WriteData<T>(IEnumerable<T> data) where T : class, new();
    }
}