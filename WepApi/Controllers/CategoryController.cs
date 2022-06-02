using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApi.DTO;
using WepApi.Repositories;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepositories categoryRepo;
        public CategoryController(ICategoryRepositories categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult getAllCategory()
        {
            return Ok(categoryRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult getOneCategory(int id)
        {
            return Ok(categoryRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid == true)
            {
                return Ok(categoryRepo.InsertNewCategory(categoryDTO));
            }
            return BadRequest("UnAdded");
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid==true)
            {
                return Ok(categoryRepo.editCategory(id, categoryDTO));
            }
            return BadRequest("UnUpdated");
        }
        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            return Ok(categoryRepo.Delete(id));
        }

    }
}
