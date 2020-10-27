using System;
using System.Collections.Generic;
using System.Text;

namespace TodayTask.Domain.Models
{
    public abstract class EntityMaster
    {
        public Int64 Id { get; set; }
        public Guid Identifier { get; set; }
    }
}