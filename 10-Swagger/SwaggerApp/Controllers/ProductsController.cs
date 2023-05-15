using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerApp.Models;

namespace SwaggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SwaggerDbContext _context;

        public ProductsController(SwaggerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri list olarak geri döner
        /// </summary>
        /// <remarks>
        /// örnek: https://localhost:7295/api/products
        /// </remarks>
        /// <returns></returns>
        [Produces("Application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Bu endpoint verilen id'ye sahip ürünü döner.
        /// </summary>
        /// <param name="id">ürünün id'si</param>
        /// <returns></returns>
        /// <response code="404">Verilen id sahip ürün bulunamadı</response>
        /// <response code="200">Verilen id sahip ürün var</response>
        [Produces("Application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Bu endpoint verilen ürün ekler
        /// </summary>
        /// <remarks>
        /// örnek: product json:{"name": "kalem","price" : 20, "category":"kırtasiye"}
        /// </remarks>
        /// <param name="product">json product nesnesi</param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'SwaggerDbContext.Products'  is null.");
            }
            product.Date = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
//{
//  "name": "string",
//  "price": 0,
//  "date": "2023-05-15T14:41:07.997Z",
//  "category": "string"
//}
