using BLL.Interfaces;
using BLL.Models;
using BLL.Tools;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        //Constructeurs

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }






        public TokenDTO Auth(LoginDTO login)
        {
            UserDTO user = _authRepository.Auth(login.Login, login.User_password).ToBLL();

            if(user.User_password != login.User_password)
            {
                throw new Exception("Invalid Password!!");
            }


            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.User_email),
                new Claim(ClaimTypes.NameIdentifier, user.User_id.ToString()),
            };

            string Token = GenerateToken(_configuration["Jwt:Key"], Claims);
            RegisteredDTO Registered = user.RegisteredToBLL();
            return new TokenDTO(Token, Registered);

        }




        public string GenerateToken(string secretkey, List<Claim> claims)
        {
            //creer une sorte de clé de sécu unique
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            //reçoit les claims/parametres descriptifs
            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature),
            };

            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            SecurityToken Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
