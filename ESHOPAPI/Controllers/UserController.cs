using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceBLL userService;

        public UserController(IUserServiceBLL userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult  CreateUser(CreateUser user) 
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            userService.CreateUser(user);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<User> GetUsers() 
        { 
            return userService.GetUsers();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id) 
        { 
            return Ok(userService.GetUserById(id));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin user)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            return Ok(userService.Login(user.Email , user.Password));
        }
    }
}
