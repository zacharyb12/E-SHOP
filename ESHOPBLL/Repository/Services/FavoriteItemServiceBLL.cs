using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class FavoriteItemServiceBLL : IFavoriteItemServiceBLL
    {
        private IFavoriteItemServiceDAL favoriteItemService;

        public FavoriteItemServiceBLL(IFavoriteItemServiceDAL favoriteItemService)
        {
            this.favoriteItemService = favoriteItemService;
        }

        public void AddFavoriteItem(FavoriteItem favorite)
        {
            favoriteItemService.AddFavoriteItem(favorite);
        }

        public void DeleteFavoriteItem(FavoriteItem favorite)
        {
            favoriteItemService.DeleteFavoriteItem(favorite);
        }

        public IEnumerable<FavoriteItem> GetFavoriteItemByUser(Guid id)
        {
            return favoriteItemService.GetFavoriteItemByUser(id);
        }
    }
}
