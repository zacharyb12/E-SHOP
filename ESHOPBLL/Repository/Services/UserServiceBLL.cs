using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;

namespace ESHOPBLL.Repository.Services
{
    public class UserServiceBLL : IUserServiceBLL
    {
        private IUserServiceDAL userService;

        public UserServiceBLL(IUserServiceDAL userService)
        {
            this.userService = userService;
        }

        //public void CreateUser(CreateUser user)
        //{
        //    userService.CreateUser(user);

        //}


        public IEnumerable<User> GetUsers() 
        { 
           return  userService.GetUsers();
        }


        public User GetUserById(Guid id) 
        {
            return userService.GetUsersById(id);
        }


        public void UpdateUserInfo(User user, string info , Guid id)
        {
            switch (info)
            {
                case ("LastName"):
                    info = "LastName";
                    break;

                case ("FirstName"):
                    info = "FirstName";
                    break;

                case ("Email"):
                    info = "Email";
                    break;

                case ("Password"):
                    info = "Password";
                    break;

                case ("Address"):
                    info = "Adress";
                    break;
            }
             userService.UpdateUserInfo(user, info, id);
        }


        public void Register(string email, string password, string lastName, string firstName, Enum status, string address)
        {
            var user = new CreateUser
            {
                LastName = lastName,
                FirstName = firstName,
                Email = email,
                Status = (ESHOPDomainModels.Models._11.EnumStatus.UserStatus)status,
                Address = address,
                Password = password  
            };

            userService.Register(user);
        }


        private bool CheckPassword(string email, string Password)
        {
            return userService.CheckPassword(email, Password);
        }


        public string Login(string email, string password)
        {
            if (CheckPassword(email , password)) 
            {
                return userService.Login(email,password);
            }
            throw new InvalidOperationException("Wrong Password");
        }

    }
}
