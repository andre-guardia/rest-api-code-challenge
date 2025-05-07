using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using ProductAPI.Application.Mappings;
using ProductAPI.Application.Services;
using ProductAPI.Domain.Interfaces.Repository;
using ProductAPI.Domain.Models;

namespace ProductAPI.UnitTests.Services
{
    public class ProductServiceTests
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Notebook", Price = 2999.99M },
            new Product { Id = 3, Name = "Mobile", Price = 999.99M },
        };

        private Mock<IProductRepository> _repository;

        public ProductServiceTests()
        {
            _repository = new Mock<IProductRepository>();
        }

        [Fact]
        public void ShoulReturnAllProducts_Success()
        {
            //arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapping>();
            });

            var mapper = config.CreateMapper();
            _repository.Setup(x => x.GetAll()).Returns(_products);
            var service = new ProductService(_repository.Object, mapper, new Mock<ILogger<ProductService>>().Object);

            //act
            var result = service.GetAll();


            //assert
            Assert.NotNull(result);
            Assert.Equal(result.Count(), _products.Count);
            Assert.Contains(result, p => p.Name == "Notebook");
        }
    }
}