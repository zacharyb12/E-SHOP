using ESHOPDomainModels.Models.CartItem;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface ICartItemServiceDAL
    {
        void CreateCartItem(CreateCartItem cartItem);

        void DeleteCartItem(Guid id);

        IEnumerable<CartItem> GetCartItems(Guid id);

        void UpdateCartItemInfo(CartItem cartItem, string info, Guid id);

    }
}