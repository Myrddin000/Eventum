using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ReminderFormDTO
    {
        public string Reminder_title { get; set; } = string.Empty;

        public DateTime Reminder_time { get; set; } // = DateTime.Now;     ?

    }
}
