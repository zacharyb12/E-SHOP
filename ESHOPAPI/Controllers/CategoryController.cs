using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;
using ESHOPDomainModels.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceBLL categoryService;

        public CategoryController(ICategoryServiceBLL categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategory category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoryService.CreateCategory(category);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return categoryService.GetCategory();
        }

        [HttpGet("id")]
        public Category GetCategoryById(Guid id)
        {
            return categoryService.GetCategoryById(id);

        }

        [HttpGet("name")]
        public Category GetCategoryByName(string name)
        {
            return categoryService.GetCategoryByName(name);
            
        }

        [HttpPost("{id}")]
        public IActionResult UpdateCategory(Category category , Guid id) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            categoryService.UpdateCategory(category, id );

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(Guid id) 
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            categoryService.DeleteCategory(id);
            return Ok();
        }

    }
}
