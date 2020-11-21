using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NeedDesk.Application.DTO.User;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Domain.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using Ubiety.Dns.Core.Records;

namespace NeedDesk.Application.Services
{
    public class LoginValid
    {
        public bool Success
        {
            get
            {
                return Message.NullOrEmpty();
            }
        }

        public string Message { get; set; }

        public LoginValid(string message = "")
        {
            Message = message;
        }
    }

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

        public User FinByEmail(string email)
        {
            return _userRepository.FindByLogin(email);
        }

        public SigInAuthorization SigIn(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Use_email),
                new[]
                {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Use_email),
                 });

            DateTime current = DateTime.Now;
            DateTime expiration = current + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            return Successful(user.Tenant_id, current, expiration, CreateToken(identity, current, expiration), user);
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

        private SigInAuthorization Successful(Guid tenant, DateTime createDate, DateTime expiration, string token, User user)
        {
            return new SigInAuthorization()
            {
                Authenticated = true,
                Tenant = tenant,
                Created = createDate,
                Expiration = expiration,
                Token = token,
                UserName = user.Use_email,
                Message = "Usuário logado com sucesso"
            };
        }
    }
}