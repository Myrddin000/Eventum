using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = EventumDB; Integrated Security = True";

        public void Create(ReminderEntities remind)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"INSERT INTO [Reminders] ([Reminder_title], [Reminder_time]) VALUES(@{nameof(ReminderEntities.Reminder_title)}, @{nameof(ReminderEntities.Reminder_time)})";
            cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_title), remind.Reminder_title);
            cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_time), remind.Reminder_time);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public IEnumerable<ReminderEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Reminders]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new ReminderEntities
                {
                    Reminder_id = (Guid)reader[nameof(ReminderEntities.Reminder_id)],
                    Reminder_title = (string)reader[nameof(ReminderEntities.Reminder_title)],
                    Reminder_time = (DateTime)reader[nameof(ReminderEntities.Reminder_time)],
                };
            }
            sqlConnection.Close();
        }

        public void Update(ReminderEntities remind)
        {
            using SqlConnection sqlConnetion = new SqlConnection(connectionstring);
            sqlConnetion.Open();
            using SqlCommand cmd = sqlConnetion.CreateCommand();
            cmd.CommandText = $"UPDATE [Reminders] SET [Reminder_title] = @{nameof(ReminderEntities.Reminder_title)}, [Reminder_time] = @{nameof(ReminderEntities.Reminder_time)} WHERE Reminder_id = @{nameof(ReminderEntities.Reminder_id)}";
            cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_id), remind.Reminder_id);
            cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_title), remind.Reminder_title);
            cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_time), remind.Reminder_time);
            cmd.ExecuteNonQuery();
            sqlConnetion.Close();
        }


        public void Delete(Guid Reminder_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using(SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM [Reminders] WHERE [Reminder_Id] = @{nameof(ReminderEntities.Reminder_id)}";
                    cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_id), Reminder_id);
                    cmd.ExecuteNonQuery ();
                }
            }
        }

        public ReminderEntities GetById(Guid Reminder_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [Reminders] WHERE [Reminder_id] = @{nameof(ReminderEntities.Reminder_id)}";
                    cmd.Parameters.AddWithValue(nameof(ReminderEntities.Reminder_id), Reminder_id);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new ReminderEntities
                        {
                            Reminder_title = (string)reader[nameof(ReminderEntities.Reminder_title)],
                            Reminder_time = (DateTime)reader[nameof(ReminderEntities.Reminder_time)],
                        };
                    }
                    else
                    {
                        throw new Exception("Reminder not found!");
                    }
                }
            }
        }

        
    }

}
