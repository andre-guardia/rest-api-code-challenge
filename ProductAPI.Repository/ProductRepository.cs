using ProductAPI.Domain.Interfaces.Repository;
using ProductAPI.Domain.Models;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.GetAll();
        }

        public Product? GetById(int productId)
        {
            return _context.GetById(productId);
        }

        public int Create(Product product)
        {
            return _context.Create(product);
        }

        public bool Update(int productId, Product product)
        {
            return _context.Update(productId, product);
        }

        public bool Delete(int productId)
        {
            return _context.Delete(productId);
        }
    }
}
