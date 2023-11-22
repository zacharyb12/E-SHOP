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

        [HttpGet("{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            categoryService.GetCategoryByName(name);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult UpdateCategory(Category category) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            categoryService.UpdateCategory(category);

            return Ok();
        }
    }
}
