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
    public class CategoriesController : ControllerBase
    {
        private readonly ProductCategoryContext _context;

        public CategoriesController(ProductCategoryContext context)
        {
            _context = context;
        }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
    {
            return await _context.ProductCategories.ToListAsync();
    }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetCategoryDetails(int id)
        {
            var categoryDetail = await _context.ProductCategories.FindAsync(id);

            if (categoryDetail == null)
            {
                return NotFound();
            }

            return categoryDetail;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryDetails(int id, ProductCategory categoryDetail)
        {
            if (id != categoryDetail.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryDetail).State = EntityState.Modified;

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

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> AddCategoryDetail(ProductCategory categoryDetail)
        {
            _context.ProductCategories.Add(categoryDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetail", new { id = categoryDetail.CategoryId }, categoryDetail);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryDetail(int id)
        {
            var categoryDetail = await _context.ProductCategories.FindAsync(id);
            if (categoryDetail == null)
            {
                return NotFound();
            }

            _context.ProductCategories.Remove(categoryDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryDetailExists(int id)
        {
            return _context.ProductCategories.Any(e => e.CategoryId == id);
        }

    }
}
