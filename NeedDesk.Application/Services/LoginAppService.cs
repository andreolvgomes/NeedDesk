using AutoMapper;
using NeedDesk.Application.Dtos.Users;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Ubiety.Dns.Core.Records;

namespace NeedDesk.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserRepository _userRepository;

        public LoginAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindByLogin(LoginDto login)
        {
            if (login != null && !login.Email.NullOrEmpty())
                return _userRepository.FindByLogin(login.Email);
            return null;
        }
    }
}