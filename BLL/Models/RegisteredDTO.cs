using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RegisteredDTO
    {
        public Guid User_id { get; set; }

        public string User_pseudo { get; set; } = String.Empty;

        public string User_email { get; set; } = String.Empty;
    }
}
