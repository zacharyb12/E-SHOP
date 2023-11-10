using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class UserServiceBLL : IUserServiceBLL
    {
        private IUserServiceDAL userService;

        public UserServiceBLL(IUserServiceDAL userService)
        {
            this.userService = userService;
        }

        public void CreateUser(CreateUser user)
        {
            userService.CreateUser(user);

        }

        public IEnumerable<User> GetUsers() 
        { 
           return  userService.GetUsers();
        }

        public User GetUserById(Guid id) 
        {
            return userService.GetUsersById(id);
        }

        private bool CheckPassword(string password, string email)
        {
            string hash = userService.CheckPassword(email);

            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public User Login(string email , string password) 
        {
            if (CheckPassword(email , password)) 
            {
                return userService.Login(email);
            }
            throw new InvalidOperationException("Wrong Password");
        }

    }
}
