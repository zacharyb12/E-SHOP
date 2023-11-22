using ESHOPDomainModels.Models.User;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IUserServiceBLL
    {
        //void CreateUser(CreateUser user);

        IEnumerable<User> GetUsers();

        User GetUserById(Guid id);

        void UpdateUserInfo(User user, string info, Guid id);


        void Register(string email, string password, string lastName, string firstName, string status, string address);

        string Login(string email, string password);
    }
}