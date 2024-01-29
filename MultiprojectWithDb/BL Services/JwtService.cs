using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Services
{
    public interface IJwtService
    {
        string GetJwtToken(string username, string role);
    }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)//sitas nuskaito appsetings jwt
        {
            _configuration = configuration;
        }

        public string GetJwtToken(string username, string role)
        {
            var claims = new List<Claim>
            {//name gali buti belekoks stringas vietoj "ClaimTypes.Name"
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var secretKey = _configuration.GetSection("Jwt:Key").Value;
            var issuer = _configuration.GetSection("Jwt:Issuer").Value;
            var audience = _configuration.GetSection("Jwt:Audience").Value;

            //jwt pasirasymo mechanizmas
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));//is utf stringo sugeneruojam baitu masyva
            //reikia jwt hashavimo algoritmo - credentials
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            //generuojame token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);//sitas grazins string
        }
    }
}
