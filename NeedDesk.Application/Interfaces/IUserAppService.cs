using NeedDesk.Application.Dtos.User;
using NeedDesk.Application.Dtos.Users;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IUserAppService
    {
        Int64 Create(UserCreateDto user);
        void Remove(object id);
        UserDto Get(Int64 use_id);
        void Update(UserUpdateDto user);
        IEnumerable<UserDto> All();
    }
}