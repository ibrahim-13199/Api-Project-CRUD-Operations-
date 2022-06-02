using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using WepApi.DTO;
using WepApi.Model;
using WepApi.Repositories;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository ProductRepo;
        public ProductController(IProductRepository ProductRepo)
        {
            this.ProductRepo = ProductRepo;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(ProductRepo.GetAllProduct());
        }

        [HttpGet("{id:int}", Name = "GetOneProductRoute")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            return Ok(ProductRepo.GetProductById(id));

        }

        [HttpPost]
        public IActionResult Create(ProductDTO pro1)
        {
            if (ModelState.IsValid == true)
            {
                return Ok(ProductRepo.AddProduct(pro1));
                //string url = Url.Link("GetOneEmployeeRoute", new { id = pro1.Id });
                //return Created(url, pro1);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductDTO NewProduct)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.editProduct(id, NewProduct);
                return StatusCode(204, "the data Updated");
            }
            return BadRequest("Id Not Valid");



        }

        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
         
               return Ok( ProductRepo.Delete(id));
            
        }

    }
}
