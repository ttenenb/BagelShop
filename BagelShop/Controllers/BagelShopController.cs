using Microsoft.AspNetCore.Mvc;

namespace BagelShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BagelShopController : ControllerBase
    {
        private static readonly List<Product> Products =
            new List<Product> {
               new Product{ Id = 1, Name = "Bagel" },new Product{ Id = 2, Name = "Cream Cheese"}
             , new Product{ Id =  3, Name = "Orange Juice" },  new Product{ Id =  4, Name = "Lox" }
             , new Product{ Id = 5, Name = "Vegetables" }, new Product{ Id = 6, Name = "Coffee"} };
              
   
        private readonly ILogger<BagelShopController> _logger;

        public BagelShopController(ILogger<BagelShopController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return Products
            .ToList();
        }

        [HttpGet(Name = "GetProductById")]
        public Product GetProduct(int Id)
        {
            var product = Products.First(p => p.Id == Id);
            if(product == null) throw new Exception("No such product exists. PLease choose another product.");
            else return product;
        }
    }
}