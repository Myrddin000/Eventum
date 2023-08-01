using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{

    // User Mappers

    public static class Mappers
    {
        public static UserEntities ToDAL(this UserDTO user)       // pour UPDATE
        {
            return new UserEntities
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }
      

        public static UserEntities ToDAL(this UserFormDTO user)     // pour CREATE
        {
            return new UserEntities
            {
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }

        public static UserDTO ToBLL(this UserEntities user)    // pour GETBYID
        {
            return new UserDTO
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
            
        }

        public static UserFormDTO ToFormBLL(this UserEntities user)    // ???
        {
            return new UserFormDTO
            {
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }

        public static IEnumerable<UserDTO> ToBLL(this IEnumerable<UserEntities> user)    // pour GETALL
        {
            foreach (UserEntities item in user)
            {
                yield return new UserDTO
                {
                    User_id = item.User_id,
                    User_pseudo = item.User_pseudo,
                    User_email = item.User_email,
                    User_password = item.User_password,

                };
            }
        }

        public static RegisteredDTO RegisteredToBLL(this UserDTO user)     // pour GENERATETOKEN (AuthService)
        {
            return new RegisteredDTO
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
            };
        }

        // Event Mappers

        public static EventEntities ToDAL(this EventDTO even)      // pour UPDATE
        {
            return new EventEntities
            {
                Event_id = even.Event_id,
                Event_title = even.Event_title,
                Event_start_time = even.Event_start_time,
                Event_end_time = even.Event_end_time,
                Event_note = even.Event_note,
                //Reminder_id = even.Reminder_id,
              
            };
        }

        public static EventEntities ToDAL(this EventFormDTO eventForm)     // pour CREATE
        {
            return new EventEntities
            {

                Event_title = eventForm.Event_title,
                Event_start_time = eventForm.Event_start_time,
                Event_end_time = eventForm.Event_end_time,
                Event_note = eventForm.Event_note,
                //Reminder_id = eventForm.Reminder_id,
            };
        }




        public static IEnumerable<EventDTO> ToBLL(this IEnumerable<EventEntities> even)    // pour GETALL
        {
            foreach(EventEntities item in even)
            {
                yield return new EventDTO
                {
                    Event_id = item.Event_id,
                    Event_title = item.Event_title,
                    Event_start_time = item.Event_start_time,
                    Event_end_time = item.Event_end_time,
                    Event_note = item.Event_note,
                    Reminder_id = item.Reminder_id,
                };
            }
        }

        public static EventDTO ToBLL(this EventEntities even)     // pour GETBYID
        {
            return new EventDTO
            {
                Event_id = even.Event_id,
                Event_title = even.Event_title,
                Event_start_time = even.Event_start_time,
                Event_end_time = even.Event_end_time,
                Event_note = even.Event_note,
                Reminder_id = even.Reminder_id,
            };
        }



      
    }
}
