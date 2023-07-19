using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EventEntities
    {
        public Guid Event_id { get; set; }

        public string Event_title { get; set;} = string.Empty;

        public DateTime Event_start_time { get; set; } 
        public DateTime Event_end_time { get; set; } 

        public string Event_note { get; set;} = string.Empty;

        public Guid Reminder_id { get; set;}

    }
}
