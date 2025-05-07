using ProductAPI.Domain.Models;

namespace ProductAPI.Domain.Interfaces.Repository
{
    public interface IProductContext
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int productId);
        int Create(Product product);
        bool Update(int productId, Product product);
        bool Delete(int productId);
    }
}
