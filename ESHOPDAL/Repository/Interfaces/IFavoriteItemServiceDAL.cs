using ESHOPDomainModels.Models;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IFavoriteItemServiceDAL
    {

        void AddFavoriteItem(FavoriteItem favorite);

        void DeleteFavoriteItem(FavoriteItem favorite);

        IEnumerable<FavoriteItem> GetFavoriteItemByUser(Guid id);

    }
}