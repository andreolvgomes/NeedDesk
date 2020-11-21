using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Api.Tests.Config
{
    public class UserAuthentication
    {
        public static string Email { get; set; }
        public static string Password { get; set; }

        public static bool IsAuthentication()
        {
            return !Email.NullOrEmpty();
        }
    }
}
