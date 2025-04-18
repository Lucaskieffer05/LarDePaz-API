﻿using LarDePaz_API.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LarDePaz_API.Services
{
    public class TokenService(IHttpContextAccessor httpContextAccessor, IConfiguration config)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IConfiguration _config = config;

        public Token GetToken()
        {
            if (_httpContextAccessor.HttpContext == null)
                throw new Exception("No se ha podido encontrar el token");

            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "userId").Value;

            return new Token
            {
                UserId = int.TryParse(userIdClaim, out var userId) ? userId : throw new Exception("Invalid or missing userId claim"),
                Email = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value,
                Name = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name).Value,
                LastName = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Surname).Value,
                Role = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value
            };
        }

        public string? GenerateToken(User user, string role, DateTime expiration)
        {
            var jwtKey = _config["Jwt:Key"];

            if (string.IsNullOrEmpty(jwtKey))
                return null;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
