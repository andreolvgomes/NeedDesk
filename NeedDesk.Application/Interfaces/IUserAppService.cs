using NeedDesk.Application.DTO.User;
using NeedDesk.Application.DTO.Users;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IUserAppService
    {
        Guid Create(UserCreate user);
        void Remove(Guid id);
        UserResult Get(Guid use_id);
        void Update(UserUpdate user);
        IEnumerable<UserResult> All();
    }
}