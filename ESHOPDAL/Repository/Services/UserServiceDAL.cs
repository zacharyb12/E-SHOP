using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ESHOPDAL.Repository.Services
{
    public class UserServiceDAL : IUserServiceDAL
    {
        private SqlConnection connection;

        public UserServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //METHODES
        public void CreateUser(CreateUser user)
        {
            string sql = "INSERT INTO Users (LastName, FirstName, Email, Password, Status, Address) VALUES (@LastName, @FirstName, @Email, @Password, @Status, @Address)";

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);

            var parameters = new DynamicParameters();
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", passwordBytes);
            parameters.Add("@Status", user.Status);
            parameters.Add("@Address", user.Address);

            connection.Execute(sql, parameters);
        }


        public IEnumerable<User> GetUsers() 
        {
            string sql = " SELECT * FROM Users";

            return connection.Query<User>(sql);
        }


        public User GetUsersById(Guid id)
        {

            return connection.QueryFirst<User>(" SELECT * FROM Users WHERE Id = @id " ,  new {id});
        }


        ////////////////Connection
       

        public string CheckPassword(string email)
        {
            string sql = " SELECT Password FROM Users WHERE Email = @email";
            return connection.QueryFirst<string>(sql, new { email });
        }


        public User Login(string email)
        {
            string sql = " SELECT * FROM Users WHERE  Email = @email";

            var param = new {email};

            return connection.QueryFirst<User> (sql , param);
        }
    }
}
