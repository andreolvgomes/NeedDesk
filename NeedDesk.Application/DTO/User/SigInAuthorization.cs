using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.DTO.User
{
    public class SigInAuthorization
    {
        public bool Authenticated { get; set; }
        public Guid Tenant { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
