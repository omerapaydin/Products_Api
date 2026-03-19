using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok();
        }

        
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok();
        }
    }
}