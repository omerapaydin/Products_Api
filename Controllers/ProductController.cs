using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController:ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var p = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

             if(p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct),new {id = entity.ProductId},entity);

        
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> UpdateProduct(int id,Product entity)
        {
            if(id != entity.ProductId)
            {
                return BadRequest();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = entity.ProductName;
            product.Price = entity.Price;
            product.IsActive = entity.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

             _context.Products.Remove(product);

             try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }

            return NoContent();


        }



    }

}