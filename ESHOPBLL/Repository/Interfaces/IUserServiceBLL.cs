using ESHOPDomainModels.Models.User;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IUserServiceBLL
    {
        void CreateUser(CreateUser user);

        IEnumerable<User> GetUsers();

        User GetUserById(Guid id);


        User Login(string email, string password);
    }
}