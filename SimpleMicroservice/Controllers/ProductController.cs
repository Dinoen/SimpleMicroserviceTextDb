using Microsoft.AspNetCore.Mvc;
using SimpleMicroservice.Services;

namespace SimpleMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            // Have several guard-clauses to check for invalid input
            // Check if the product parameter is null
            if (product == null)
            {
                return BadRequest(new { message = "Invalid product data. Product object cannot be null." });
            }

            // check if the ID is an positive integer
            if (product.Id <= 0)
            {
                return BadRequest(new { message = "Invalid product data. Product ID must be greater than zero." });
            }

            // check if the id is already in use
            var existingProduct = _productService.GetProduct(product.Id);
            if (existingProduct != null)
            {
                return BadRequest(new { message = "Product ID is already in use." });
            }

            // Perform additional input validation checks on the product properties
            if (string.IsNullOrEmpty(product.Name))
            {
                return BadRequest(new { message = "Invalid product data. Product name is required." });
            }
            // Check if the price is greater than zero
            if (product.Price <= 0)
            {
                return BadRequest(new { message = "Invalid product data. Product price must be greater than zero." });
            }

            // If all input validation checks pass, proceed with adding the product
            try
            {
                var result = _productService.AddProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the product. " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products. " + ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found" });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, new { message = "An error occurred while retrieving the product. " + ex.Message });
            }
        }
    }
}