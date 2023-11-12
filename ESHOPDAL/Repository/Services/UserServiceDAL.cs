using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models._01.User;
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

            return connection.QueryFirst<User>(" SELECT * FROM Users WHERE Id = @id ");
        }


        public void UpdateUserInfo(User user, string info, Guid id)
        {
            var validColumnNames = new List<string> { "LastName", "FirstName", "Email", "Password", "Address" };

            if (!validColumnNames.Contains(info))
            {
                throw new ArgumentException("Nom de colonne non valide.", nameof(info));
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            string sql = $"UPDATE Users SET {info} = @Value WHERE Id = @Id";

            // Utilisez la réflexion pour obtenir la valeur de la propriété
            object propertyValue = typeof(User).GetProperty(info)?.GetValue(user);

            parameters.Add("@Value", propertyValue);

            connection.ExecuteScalar(sql, parameters);
        }


        public string GetUserInfoValue( string info)
        {
            switch (info)
            {
                case "LastName":
                    return "user.LastName";
                case "FirstName":
                    return "user.FirstName";
                case "Email":
                    return "user.Email";
                case "Password":
                    return "user.Password";
                case "Address":
                    return "user.Address";
                default:
                    throw new ArgumentException("Nom de colonne non géré.", nameof(info));
            }
        }


        ////////////////Connection


        public void Register(CreateUser user)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            string sql = "INSERT INTO Users (LastName, FirstName, Email, Status, Address, Password) " +
                         "VALUES (@LastName, @FirstName, @Email, @Status, @Address, @Password)";

            var param = new
            {
                user.LastName,
                user.FirstName,
                user.Email,
                user.Status,
                user.Address,
                Password = hashedPassword 
            };

            connection.Execute(sql, param);
        }


        public bool CheckPassword(string email, string password)
        {
            // Récupérer le mot de passe haché depuis la base de données
            var storedPassword = connection.QueryFirst<string>("SELECT Password FROM Users WHERE Email = @email", new { email });

            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            return BCrypt.Net.BCrypt.Verify(password, storedPassword);
        }


        public User Login(string email)
        {
            string sql = " SELECT * FROM Users WHERE  Email = @email";

            var param = new { email };

            return connection.QueryFirst<User> (sql , param);
        }
    }
}
