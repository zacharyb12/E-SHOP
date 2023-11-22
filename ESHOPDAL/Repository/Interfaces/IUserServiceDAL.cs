using ESHOPDomainModels.Models.User;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IUserServiceDAL
    {
        //void CreateUser(CreateUser user);

        IEnumerable<User> GetUsers();

        User GetUsersById(Guid id);

        void UpdateUserInfo(User user, string info, Guid id);

        //Connection
        void Register(CreateUser user);

        bool CheckPassword(string email, string Password);

        string Login(string email, string password);
    }
}