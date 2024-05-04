using ecoapp.DTOS;
using ecoapp.Models;
using ecoapp.Repositories;
using ecoapp.Response;
using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace ecoapp.Services
{
    public class UserService : IUserService
    {
        public class JwtSecrets
        {
            public required string Key { get; set; }
            public required string Issuer { get; set; }
            public required string Audience { get; set; }
        }
        private IAuthenticationRepository Repository;
        private IConfiguration Config;
        public UserService(IAuthenticationRepository repository, IConfiguration config) 
        { 
            Repository = repository;
            Config = config;
        }
        private string GetPassword(string text)
        {
            byte[] bytesText = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(bytesText);
            }
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        private string GenerateToken(UserDTO user, JwtSecrets secrets)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secrets.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                secrets.Issuer,
                secrets.Audience,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<ResponseObject<UserResponse>> Login(UserDTO user)
        {
            try
            { 
                var userModel = new UserModel()
                {
                    Id = 0,
                    Balance = 0,
                    Email = user.Email,
                    Name = user.Name,
                    PasswordUser = GetPassword(user.PasswordUser),
                    Logs = new List<LogModel>()
                };
                var result = await Repository.Login(userModel);
                var key = Config.GetSection("JWT:Key").Value;
                var issuer = Config.GetSection("JWT:Issuer").Value;
                var audience = Config.GetSection("JWT:Audience").Value;
                if (result == null || key == null || issuer == null || audience == null)
                {
                    return ResponseMaker<UserResponse>.GetResponse(
                        new UserResponse()
                        {
                            Id = -1,
                            Balance = -1,
                            Descripcion = "No se pudo ingresar"
                        }, 200, "Fallo.");
                }
                else
                {
                    var token = GenerateToken(user, new JwtSecrets
                    {
                        Key = key,
                        Audience = audience,
                        Issuer = issuer
                    });
                    return ResponseMaker<UserResponse>.GetResponse(
                        new UserResponse()
                        {
                            Id = result.Id,
                            Balance = result.Balance,
                            Descripcion = "Ingreso exitoso",
                            Token = token
                        }, 200, "logro.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
