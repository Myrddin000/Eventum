using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReminderEntities
    {
        public Guid Reminder_id { get; set; }

        public string Reminder_title { get; set; } = string.Empty;

        public DateTime Reminder_time { get; set; }
    }
}
