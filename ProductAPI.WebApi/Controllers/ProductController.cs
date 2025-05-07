using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.DTO;
using ProductAPI.Domain.Interfaces.Service;

namespace ProductAPI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById([FromRoute] int productId)
        {
            var product = _productService.GetById(productId);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest request)
        {
            var result = _productService.Create(request);
            if (result < 1)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct([FromRoute] int productId, [FromBody] ProductRequest request)
        {
            var result = _productService.Update(productId, request);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct([FromRoute] int productId)
        {
            var result = _productService.Delete(productId);
            return result ? NoContent() : BadRequest();
        }
    }
}
