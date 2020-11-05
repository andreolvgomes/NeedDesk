using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NeedDesk.Application.Dtos.Users;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Domain.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Ubiety.Dns.Core.Records;

namespace NeedDesk.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserRepository _userRepository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        //private IConfiguration _configuration;

        public LoginAppService(IUserRepository userRepository,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        //IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            //_configuration = configuration;
        }

        public object FindByLogin(LoginDto login)
        {
            if (login != null && !login.Use_email.NullOrEmpty())
            {
                User user = _userRepository.FindByLogin(login.Use_email);
                if (user != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(user.Use_email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Use_email),
                         });

                    DateTime create_date = DateTime.Now;
                    DateTime expiration = create_date + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    string token = CreateToken(identity, create_date, expiration);
                    return SuccessObject(create_date, expiration, token, user);
                }
            }

            return new
            {
                Authenticated = false,
                Message = "Falha na autenticação"
            };

            //if (login != null && !login.Email.NullOrEmpty())
            //    return _userRepository.FindByLogin(login.Email);
            //return null;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expiration)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expiration
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(DateTime createDate, DateTime expiration, string token, User user)
        {
            return new
            {
                Authenticated = true,
                Created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expiration.ToString("yyyy-MM-dd HH:mm:ss"),
                AcessToken = token,
                UserName = user.Use_email,
                Message = "Usuário logado com sucesso"
            };
        }
    }
}