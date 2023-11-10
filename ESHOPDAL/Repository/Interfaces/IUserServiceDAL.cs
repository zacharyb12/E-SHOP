using ESHOPDomainModels.Models.User;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IUserServiceDAL
    {
        void CreateUser(CreateUser user);

        IEnumerable<User> GetUsers();

        User GetUsersById(Guid id);


        string CheckPassword(string email);

        User Login(string email);
    }
}