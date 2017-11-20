﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MemoTime.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;
        
        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
            Console.WriteLine(_settings.Key);
        }
        public JwtDto CreateToken(string username, string role)
        {
            var now = DateTime.UtcNow;
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString()) 
            };

            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            Console.WriteLine("Key" + _settings.ValidIssuer);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                ExpirationTime = expires.ToTimestamp()
            };
        }
    }
}