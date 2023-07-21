using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class Eventrepository : IEventRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True;";

        public void Create(EventEntities even)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"INSERT INTO [Events]([Event_title],[Event_start_time],[Event_end_time],[Reminder_id]) VALUES(@{nameof(EventEntities.Event_title)}, @{nameof(EventEntities.Event_start_time)}, @{nameof(EventEntities.Event_end_time)}, @{nameof(EventEntities.Reminder_id)})";
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_title), even.Event_title);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_start_time), even.Event_start_time);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_end_time), even.Event_end_time);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Reminder_id), even.Reminder_id);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public IEnumerable<EventEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Events]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new EventEntities
                {
                    Event_id = (Guid)reader[nameof(EventEntities.Event_id)],
                    Event_title = (string)reader[nameof(EventEntities.Event_title)],
                    Event_start_time = (DateTime)reader[nameof(EventEntities.Event_start_time)],
                    Event_end_time = (DateTime)reader[nameof(EventEntities.Event_end_time)],
                    Reminder_id = (Guid)reader[nameof(EventEntities.Reminder_id)],
                };
            }
        }

        public void Update(EventEntities even)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"UPDATE [Events] SET [Event_title] = @{nameof(EventEntities.Event_title)}, [Event_start_time] = @{nameof(EventEntities.Event_start_time)}, [Event_end_time] = @{nameof(EventEntities.Event_end_time)}, [Reminder_id] = @{nameof(EventEntities.Reminder_id)}";
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_title), even.Event_title);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_start_time), even.Event_start_time);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Event_end_time), even.Event_end_time);
            cmd.Parameters.AddWithValue(nameof(EventEntities.Reminder_id), even.Reminder_id);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();


        }

        public void Delete(Guid Event_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM [Events] WHERE [Event_id] = @{nameof(EventEntities.Event_id)}";

                    cmd.Parameters.AddWithValue("Event_id", Event_id);

                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public EventEntities GetById(Guid Event_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring)) 
            {
                sqlConnection.Open();
                using(SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [Events] WHERE [Event_id] = @{nameof(EventEntities.Event_id)}";
                    cmd.Parameters.AddWithValue("Event_id", Event_id);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return new EventEntities
                        {
                            Event_title = (string)reader[nameof(EventEntities.Event_title)],
                            Event_start_time = (DateTime)reader[nameof(EventEntities.Event_start_time)],
                            Event_end_time = (DateTime)reader[nameof(EventEntities.Event_end_time)],
                            Event_note = (string)reader[nameof(EventEntities.Event_note)],
                            Reminder_id = (Guid)reader[nameof(EventEntities.Reminder_id)],

                        };
                    }
                    else
                    {
                        throw new Exception("Event not found!");
                    }
                }
            }
        }

    }
}
