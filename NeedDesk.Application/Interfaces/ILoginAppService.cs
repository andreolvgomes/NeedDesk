using NeedDesk.Application.Dtos.Users;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface ILoginAppService
    {
        object FindByLogin(LoginDto login);
    }
}
