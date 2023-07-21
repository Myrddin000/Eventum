using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True;"; 

        public void Create(UserEntities user)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"INSERT INTO [Users] ([user_pseudo][User_email][User_password]) VALUES (@User_pseudo, @Email, @Password)";
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_pseudo), user.User_pseudo);
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_email), user.User_email);
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_password), user.User_password);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public IEnumerable<UserEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM[Users]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new UserEntities()
                {
                    User_id = (Guid)reader[nameof(UserEntities.User_id)],
                    User_pseudo = (string)reader[nameof(UserEntities.User_pseudo)],
                    User_email = (string)reader[nameof(UserEntities.User_email)],
                    User_password = (string)reader[nameof(UserEntities.User_password)],

                };
            }
            sqlConnection.Close();
        }


        public void Update(UserEntities user)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"UPDATE [Users] SET [User_pseudo] = @Pseudo, [User_email] = @Email, [User_password] = @Password WHERE User_id = @Id";
            cmd.Parameters.AddWithValue("User_id", user.User_id);
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_pseudo), user.User_pseudo);
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_email), user.User_email);
            cmd.Parameters.AddWithValue(nameof(UserEntities.User_password), user.User_password);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void Delete(Guid User_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE [User_id] = @Id";
                    cmd.Parameters.AddWithValue("User_id", User_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public UserEntities GetById(Guid User_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using(SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Users] WHERE [User_id] = @Id";
                    cmd.Parameters.AddWithValue("User_id", User_id);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UserEntities
                        {
                            User_pseudo = (string)reader[nameof(UserEntities.User_pseudo)],
                            User_email = (string)reader[nameof(UserEntities.User_email)],
                            User_password = (string)reader[nameof(UserEntities.User_password)],
                        };
                    }
                    else
                    {
                        throw new Exception("User not found");
                    }
                }
            }
        }

    }
}


