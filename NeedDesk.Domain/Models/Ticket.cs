using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Tickets")]
    public class Ticket : EntityBase, IEntity
    {
        [Key]
        public Guid Tic_id { get; set; }
        public Guid Dep_id { get; set; }
        public Guid Cli_id { get; set; }
        public Guid Col_id_soli { get; set; }
        public Guid Col_id_pend { get; set; }
        public Guid Pri_id { get; set; }
        public Guid Cat_id { get; set; }
        public Guid Cla_id { get; set; }
        public Guid Sta_id { get; set; }
        public string Tick_assunto { get; set; }
        public Int16 Tick_tipo { get; set; }//0-externo;1-interno
    }
}