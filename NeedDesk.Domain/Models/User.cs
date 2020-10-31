using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class User : EntityBase
    {
        public Int64 Use_id { get; set; }
        public string Use_email { get; set; }
        public string Use_senha { get; set; }
        public bool Use_inativo { get; set; }
    }
}
