using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> All()
        {
            return _userRepository.All("");
        }

        public Int64 Create(User user)
        {
            return (Int64)_userRepository.Insert(user);
        }

        public User Get(long use_id)
        {
            return _userRepository.FindById(use_id);
        }

        public void Remove(User user)
        {
            _userRepository.Delete(user);
        }
    }
}
