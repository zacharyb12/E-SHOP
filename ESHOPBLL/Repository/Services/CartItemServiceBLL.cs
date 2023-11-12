using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class CartItemServiceBLL : ICartItemServiceBLL
    {
        private  ICartItemServiceDAL cartItemService;

        public CartItemServiceBLL(ICartItemServiceDAL cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        public void CreateCartItem(CreateCartItem cartItem)
        {
            if (cartItem is null)
            {
                throw new ArgumentNullException(nameof(cartItem));
            }

            cartItem.ItemPrice = cartItem.Quantity * cartItem.ItemPrice;

            cartItemService.CreateCartItem(cartItem);
        }

        public void DeleteCartItem(Guid id)
        {
            cartItemService.DeleteCartItem(id);
        }

        public IEnumerable<CartItem> GetCartItems(Guid id)
        {
            return cartItemService.GetCartItems(id);
        }

        public void UpdateCartItemInfo(CartItem cartItem, string info, Guid id)
        {
            cartItemService.UpdateCartItemInfo(cartItem, info, id);
        }
    }
}
