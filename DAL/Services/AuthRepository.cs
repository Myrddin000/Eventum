using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = EventumDB; Integrated Security = True";

        // récup les infos dans appsettingssjon
        private readonly IConfiguration _Configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public UserEntities Auth(string login, string password)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Users] WHERE [User_pseudo] = @login OR [User_email] = @login";
            cmd.Parameters.AddWithValue("Login", login);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                UserEntities user = new UserEntities();
                if (reader.Read())
                {
                    user.User_id = (Guid)reader[nameof(UserEntities.User_id)];
                    user.User_pseudo = (string)reader[nameof(UserEntities.User_pseudo)];
                    user.User_email = (string)reader[nameof(UserEntities.User_email)];
                    user.User_password = (string)reader[nameof(UserEntities.User_password)];

                }
                else throw new Exception("incorrect identifier");
                return user;
            }
        }

        public string GenerateToken(string SecretKey, List<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
