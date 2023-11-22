using ESHOPDomainModels.Models;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IFavoriteItemServiceBLL
    {
        void AddFavoriteItem(FavoriteItem favorite);

        void DeleteFavoriteItem(FavoriteItem favorite);

        public IEnumerable<FavoriteItem> GetFavoriteItemByUser(Guid id);
    }
}