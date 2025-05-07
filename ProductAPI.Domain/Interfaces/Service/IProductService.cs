using ProductAPI.Domain.DTO;

namespace ProductAPI.Domain.Interfaces.Service
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAll();
        ProductResponse? GetById(int productId);
        int Create(ProductRequest product);
        bool Update(int productId, ProductRequest product);
        bool Delete(int productId);
    }
}
