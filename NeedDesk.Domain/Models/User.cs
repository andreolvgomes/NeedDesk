using Dapper;
using System;

namespace NeedDesk.Domain.Models
{
    [Table("Users")]
    public class User : EntityBase
    {
        [Key]
        public Int64 Use_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Use_email { get; set; }
        public string Use_senha { get; set; }
        public bool Use_inativo { get; set; }
    }
}