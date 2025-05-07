using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductAPI.Domain.DTO;
using ProductAPI.Domain.Interfaces.Repository;
using ProductAPI.Domain.Interfaces.Service;
using ProductAPI.Domain.Models;

namespace ProductAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            var products = _productRepository.GetAll();
            if (products is null || products.Count() == 0)
            {
                _logger.LogWarning("no products available");
                return new List<ProductResponse>();
            }

            return products.Select(_mapper.Map<ProductResponse>);
        }

        public ProductResponse? GetById(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product is null)
            {
                _logger.LogWarning($"Product {productId} not found");
                return null;
            }

            return _mapper.Map<ProductResponse>(product);
        }

        public int Create(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            return _productRepository.Create(product);
        }

        public bool Update(int productId, ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            return _productRepository.Update(productId, product);
        }

        public bool Delete(int productId)
        {
            return _productRepository.Delete(productId);
        }
    }
}
