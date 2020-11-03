using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IUserAppService
    {
        Int64 Create(User user);
        void Remove(User user);
        User Get(Int64 use_id);
        IEnumerable<User> All();
    }
}