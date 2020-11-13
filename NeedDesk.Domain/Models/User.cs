using Dapper;
using System;

namespace NeedDesk.Domain.Models
{
    [Table("Users")]
    public class User : EntityBase, IEntity
    {
        [Key]
        public Guid Use_id { get; set; }
        public string Use_email { get; set; }
        public string Use_senha { get; set; }
        public bool Use_inativo { get; set; }
    }
}