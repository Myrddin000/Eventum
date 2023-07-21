using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public  interface IAuthService
    {
        TokenDTO Auth(LoginDTO login);

        string GenerateToken(string secretkey, List<Claim> claims);
    }
}
