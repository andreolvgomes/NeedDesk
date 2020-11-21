using NeedDesk.Application.DTO.User;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface ILoginAppService
    {
        User FinByEmail(string email);
        AuthenticationResult SigIn(User user);
    }
}
