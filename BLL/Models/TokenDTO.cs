using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TokenDTO
    {
        public TokenDTO(string token, RegisteredDTO register)
        {
            Token = token;
            Registered = register;

        } 
        public string Token { get; set; } = String.Empty;

        public RegisteredDTO Registered { get; set; }
    }
}
