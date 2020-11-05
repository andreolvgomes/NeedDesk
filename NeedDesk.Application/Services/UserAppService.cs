using AutoMapper;
using NeedDesk.Application.Dtos.User;
using NeedDesk.Application.Dtos.Users;
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

        public IEnumerable<UserDto> All()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_userRepository.All(""));
        }

        public Int64 Create(UserCreateDto user)
        {
            return (Int64)_userRepository.Insert(_mapper.Map<User>(user));
        }

        public UserDto Get(long use_id)
        {
            return _mapper.Map<UserDto>(_userRepository.FindById(use_id));
        }

        public void Remove(object id)
        {
            _userRepository.Delete(id);
        }

        public void Update(UserUpdateDto user)
        {
            _userRepository.Update(_mapper.Map<User>(user));
        }
    }
}