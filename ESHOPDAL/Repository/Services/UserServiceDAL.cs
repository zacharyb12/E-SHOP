using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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



        // get all users - admin
        public IEnumerable<User> GetUsers() 
        {
            string sql = " SELECT * FROM Users";

            return connection.Query<User>(sql);
        }

        // get user by id - admin
        public User GetUsersById(Guid id)
        {
            return connection.QueryFirst<User>(" SELECT * FROM Users WHERE Id = @id ");
        }

        // update user only info  - user
        public void UpdateUserInfo(User user, string info, Guid id)
        {
            //list of properties
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

        // adaptation of sql request for update user 
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

        // create new user - user
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

        //connection verification of password
        public bool CheckPassword(string email, string password)
        {
            // Récupérer le mot de passe haché depuis la base de données
            var storedPassword = connection.QueryFirstOrDefault<string>("SELECT Password FROM Users WHERE Email = @email", new { email });

            // Vérifier si le mot de passe fourni correspond au mot de passe haché
            return BCrypt.Net.BCrypt.Verify(password, storedPassword);
        }

        //connection get info email password - user
        public string Login(string email , string password)
        {
            string sql = "SELECT * FROM Users WHERE Email = @email";

            var user = connection.QueryFirstOrDefault(sql, new { email });

            if (user != null)
            {
                if(CheckPassword(email, password)) 
                {
                    // Génération du token
                    /* var token = GenerateToken(user.Email,user.Status)
                    return token;;*/
                }
                return ("Error with password");
            }

            return null;
        }

        //  non used 

        //private string GenerateToken(string userEmail , string status)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e3bf8aa1-4c1e-475f-a538-8ed52fd21916"));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new List<Claim>
        //    { new Claim($"{userEmail}", status) };

        //    var token = new JwtSecurityToken
        //    (
        //        issuer.configuration["Jwt:Issuer"],
        //        audience: "https://localhost:7110",
        //        claims: claims,
        //        expires: DateTime.Now.AddHours(1), // Durée de validité du token
        //        signingCredentials: credentials
        //    );

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    return tokenHandler.WriteToken(token);
        //}

        //METHODES non used
        //public void CreateUser(CreateUser user)
        //{
        //    string sql = "INSERT INTO Users (LastName, FirstName, Email, Password, Status, Address) VALUES (@LastName, @FirstName, @Email, @Password, @Status, @Address)";

        //    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        //    byte[] passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@LastName", user.LastName);
        //    parameters.Add("@FirstName", user.FirstName);
        //    parameters.Add("@Email", user.Email);
        //    parameters.Add("@Password", passwordBytes);
        //    parameters.Add("@Status", user.Status);
        //    parameters.Add("@Address", user.Address);

        //    connection.Execute(sql, parameters);
        //} 
    }
}
