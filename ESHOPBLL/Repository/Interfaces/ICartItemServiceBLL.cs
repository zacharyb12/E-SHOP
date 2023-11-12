using ESHOPDomainModels.Models.CartItem;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface ICartItemServiceBLL
    {
        void CreateCartItem(CreateCartItem cartItem);

        void DeleteCartItem(Guid id);

        IEnumerable<CartItem> GetCartItems(Guid id);

        void UpdateCartItemInfo(CartItem cartItem, string info, Guid id);
    }
}