using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteItemController : ControllerBase
    {
        private readonly IFavoriteItemServiceBLL favoriteItemService;

        [HttpPost]
        public IActionResult AddFavoriteITem(FavoriteItem favorite)
        {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
            favoriteItemService.AddFavoriteItem(favorite);
            return Ok();
        }


        [HttpPost("DeleteFavoviteItem")]
        public IActionResult DeleteFavoviteItem(FavoriteItem favorite)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                favoriteItemService.DeleteFavoriteItem(favorite);
                return Ok();
        }

        [HttpGet]
        public IEnumerable<FavoriteItem> GetFavoriteItemsByUserId(Guid id) 
        {
            return favoriteItemService.GetFavoriteItemByUser(id);
        }

    }
}
