using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Models.Entities;

namespace ShoppingCart.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {

        private readonly AppDbContext _appDbContext;
        public InventoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _appDbContext.products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto productDto)
        {
            if (productDto.Price <= 0)
                return BadRequest("Price must be greater than 0");

            Product product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            _appDbContext.products.Add(product);
            _appDbContext.SaveChanges();

            return Ok("Product Added Sucessfully");
        }

        [HttpPost]
        [Route("purchase/{id:int}")]
        public IActionResult BuyProduct(int id)
        {
            var product = _appDbContext.products.Find(id);

            if (product == null)
                return NotFound("The Entered Product is not available");

            if (product.Stock <= 0)
                return BadRequest("The Item is Out of Stock");

            product.Stock -= 1;

            _appDbContext.SaveChanges();
            
            return Ok("Purchase Complete");
        }
    }
}
