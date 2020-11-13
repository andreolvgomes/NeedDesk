using Dapper;
using System;
using System.Linq;
using System.Reflection;

namespace NeedDesk.Domain.Models
{
    [Table("Tenants")]
    public class Tenant : IEntity
    {
        [Key]
        public Guid Tenant_id { get; set; }

        //public Int64 Tenant_id { get; set; }
        //[IgnoreUpdate]
        //public Guid Identifier { get; set; }

        [IgnoreUpdate]
        public Int64 Sequencial { get; set; }

        [IgnoreUpdate]
        [CreateAt]
        public DateTime CreateAt { get; set; }

        [UpdateAt]
        public DateTime UpdateAt { get; set; }

        public Tenant()
        {
            // set value default property string
            foreach (PropertyInfo pro in this.GetType().GetProperties().Where(c => c.CanWrite))
            {
                if (pro.PropertyType == typeof(string))
                    pro.SetValue(this, string.Empty);
            }
        }
    }
}