using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsDbContext db;
        public ProductController(ProductsDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = await db.Products.ToListAsync();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> NewProduct(Product product) 
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Product product, int id)
        {
            var Update = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            Update.NameProduct = product.NameProduct;
            Update.DescriptionProduct = product.DescriptionProduct;
            Update.Price = product.Price;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            var product = db.Products.FirstOrDefaultAsync();
            db.Products.Remove(await product);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
