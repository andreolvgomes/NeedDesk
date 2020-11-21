using AutoMapper;
using NeedDesk.Application.DTO.User;
using NeedDesk.Application.DTO.Users;
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
        private readonly IMapper _mapper;

        public UserAppService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserResult> All()
        {
            return _mapper.Map<IEnumerable<UserResult>>(_userRepository.All(""));
        }

        public Guid Create(UserCreate user)
        {
            return (Guid)_userRepository.Insert(_mapper.Map<User>(user));
        }

        public UserResult Get(Guid use_id)
        {
            return _mapper.Map<UserResult>(_userRepository.FindById(use_id));
        }

        public void Remove(Guid id)
        {
            _userRepository.Delete(id);
        }

        public void Update(UserUpdate user)
        {
            _userRepository.Update(_mapper.Map<User>(user));
        }
    }
}