using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models.CartItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private  ICartItemServiceBLL cartItemService;

        public CartItemController(ICartItemServiceBLL cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpPost]
        public IActionResult CreateCartItem(CreateCartItem cartItem)
        {
            if ( !ModelState.IsValid ) 
            { 
                return BadRequest(ModelState);
            }

            cartItemService.CreateCartItem(cartItem);
            
            return Ok();
        }

        [HttpGet]
        public IEnumerable<CartItem> GetCartItems(Guid id) 
        {
            return cartItemService.GetCartItems(id);
        }

        [HttpPost("Update")]
        public void UpdateCartItem(CartItem cartItem , string info , Guid Id)
        {
            cartItemService.UpdateCartItemInfo(cartItem, info, Id);
        }

        [HttpDelete]
        public void DeleteCartItem(Guid id) 
        {
            cartItemService.DeleteCartItem(id);
        }

    }
}
