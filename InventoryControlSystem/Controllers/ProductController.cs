using InventoryControlSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductCategoryContext _context;

        public ProductController(ProductCategoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: /api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductDetails(int id)
        {
            var productDetail = await _context.Product.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }

        // PUT: /api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetails(int id, Product productDetail)
        {
            if (id != productDetail.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryDetailExists(id))
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

        // POST: /api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProductDetail(Product productDetail)
        {
            _context.Product.Add(productDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetail", new { id = productDetail.ProductId }, productDetail);
        }

        // DELETE: /api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            var productDetail = await _context.Product.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            _context.Product.Remove(productDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryDetailExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }



    }


}
