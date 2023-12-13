

namespace ClientServiceLayer.Models.ResponseDTO
{
    internal class ProductResDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductResDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }
        public ProductResDTO()
        {
            
        }
    }
}
