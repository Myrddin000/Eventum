using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EventFormDTO
    {
        public string Event_title { get; set; } = string.Empty;

        public DateTime Event_start_time { get; set; }

        public DateTime Event_end_time { get; set; }

        public string Event_note { get; set; } = string.Empty;

       
    }
}
