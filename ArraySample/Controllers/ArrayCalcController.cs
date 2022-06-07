using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArraySample.Service;

namespace ArraySample.Controllers
{
    [ApiController]
    [Route("api/arraycalc")]
    public class ArrayCalcController : Controller
    {
        private readonly IProductService _productService;
        public ArrayCalcController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("reverse")]
        public IActionResult Reverse([FromQuery] int[] productIds)
        {
            return Ok(_productService.ReverseArray(productIds));
        }

        [HttpGet("deletepart")]
        public IActionResult DeletePart(int position, [FromQuery] int[] productIds)
        {
            try
            {
                return Ok(_productService.DeleteFromArray(productIds, position));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("Position out of range");
            }
        }
    }
}
