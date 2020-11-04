using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IUserAppService
    {
        Int64 Create(User user);
        void Remove(object id);
        User Get(Int64 use_id);
        void Update(User user);
        IEnumerable<User> All();
    }
}