using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;
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

        //[HttpPost]
        //public IActionResult  CreateUser(CreateUser user) 
        //{
        //    if (!ModelState.IsValid) 
        //    { 
        //        return BadRequest(ModelState);
        //    }
        //    userService.CreateUser(user);

        //    return Ok();
        //}

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
        public string Login(UserLogin user)
        {
            return userService.Login(user.Email , user.Password);
        }

        [HttpPost("register")]
        public IActionResult Register(CreateUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            userService.Register(user.Email, user.Password, user.LastName, user.FirstName, user.Status, user.Address);
            return Ok();
        }

        [HttpPost("UpdateInfo")]
        public IActionResult UpdateUserInfo(User user, string info, Guid id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            userService.UpdateUserInfo(user, info , id);
            return Ok();
        }

    }
}
