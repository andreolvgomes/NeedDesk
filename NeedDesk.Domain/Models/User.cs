using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class User : EntityMaster
    {
        public string Use_email { get; set; }
        public string Use_name { get; set; }
        public string Use_senha { get; set; }
    }
}