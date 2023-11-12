using ESHOPDomainModels.Models._01.User;
using ESHOPDomainModels.Models.User;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IUserServiceDAL
    {
        void CreateUser(CreateUser user);

        IEnumerable<User> GetUsers();

        User GetUsersById(Guid id);

        void UpdateUserInfo(User user, string info, Guid id);


        void Register(CreateUser user);

        bool CheckPassword(string email, string Password);

        User Login(string email);
    }
}