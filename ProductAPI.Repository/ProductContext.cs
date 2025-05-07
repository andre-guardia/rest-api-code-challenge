using ProductAPI.Domain.Interfaces.Repository;
using ProductAPI.Domain.Models;

namespace ProductAPI.Repository
{
    public class ProductContext : IProductContext
    {
        private List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public int Create(Product product)
        {
            var last = _products.LastOrDefault();
            if (last is null)
                product.Id = 1;
            else product.Id = last.Id + 1;

            _products.Add(product);
            return product.Id;
        }

        public bool Update(int productId, Product product)
        {
            var query = GetById(productId);
            if (query is null)
            {
                return false;
            }

            query.Name = product.Name;
            query.Price = product.Price;

            return true;
        }

        public bool Delete(int productId)
        {
            var query = GetById(productId);
            if (query is null) return false;

            _products.Remove(query);
            return true;
        }
    }
}
