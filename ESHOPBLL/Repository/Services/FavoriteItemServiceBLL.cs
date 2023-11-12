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
        private IFavoriteItemServiceDAL FavoriteItemService;

        public FavoriteItemServiceBLL(IFavoriteItemServiceDAL favoriteItemService)
        {
            FavoriteItemService = favoriteItemService;
        }

        public void AddFavoriteItem(FavoriteItem favorite)
        {
            FavoriteItemService.AddFavoriteItem(favorite);
        }

        public void DeleteFavoriteItem(FavoriteItem favorite)
        {
            FavoriteItemService.DeleteFavoriteItem(favorite);
        }
    }
}
