using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryPattern.Services
{
    public class AuthenService
    {
        WebphimonlineContext db = new WebphimonlineContext();
        IAuthenRepository _auth;
        IConfiguration config;
        public AuthenService(IAuthenRepository auth, IConfiguration config) {
            this._auth = auth;
            this.config = config;
        }
       
        public (int Status, string? Token) Login(Taikhoan req)
        {
            try
            {
                var user = _auth.GetTaikhoan(req.Email, req.MatKhau);

                if (user != null)
                {
                    
                    var key = config["Jwt:Key"];
                    var signkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var sign = new SigningCredentials(signkey, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: config["Jwt:Iss"],
                        audience: config["Jwt:Aud"],
                        expires: DateTime.Now.AddMinutes(1),
                        claims: new[]
                        {
                    new Claim("userId", user.Id.ToString())
                        },
                        signingCredentials: sign);
                    var tokenlog = new JwtSecurityTokenHandler().WriteToken(token);
                    return (200, tokenlog);
                }
                else
                {
                    return (404, null); 
                }
            }
            catch (Exception ex)
            {
                return (500, null);
            }
        }







        public string GenerateAccessToken(Taikhoan req)
        {
            var user = _auth.GetTaikhoan(req.Email, req.MatKhau);
            if (user != null)
            {
                
                var key = config["Jwt:Key"];
                var signkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var sign = new SigningCredentials(signkey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Iss"],
                    audience: config["Jwt:Aud"],
                    //expires: DateTime.UtcNow.AddMinutes(1),
                    expires: DateTime.Now.AddSeconds(40),

                    claims: new[]
                    {
                    new Claim("userId", user.Id.ToString())
                    },
                    signingCredentials: sign);
                var tokenlog = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenlog;
            }
            else return "500";
            
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


        public string GenerateAccessTokenFromRefreshToken(string refreshToken)
        {
            var userdata = db.Taikhoans.FirstOrDefault(x => x.RefreshToken == refreshToken);
            var key = config["Jwt:Key"];
            var signkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var sign = new SigningCredentials(signkey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Iss"],
                audience: config["Jwt:Aud"],
                expires: DateTime.Now.AddMinutes(1),
                claims: new[]
                    {
                    new Claim("userId", userdata.Id.ToString())
                    },
                signingCredentials: sign);
            var tokenlog = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenlog;
        }






        public Taikhoan register(Taikhoan req)
        {
            var check = _auth.GetTKbyMail(req.Email);
            if (check != null)
            {
                throw new Exception("Accout already  exised");
            }
            else
            {
                _auth.Add(req);      
                return req;
            }
        }
    }
}
