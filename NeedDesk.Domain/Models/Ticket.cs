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
        public Int64 Tic_id { get; set; }
        public Int64 Dep_id { get; set; }
        public Int64 Cli_id { get; set; }
        public Int64 Col_id_soli { get; set; }
        public Int64 Col_id_pend { get; set; }
        public Int64 Pri_id { get; set; }
        public Int64 Cat_id { get; set; }
        public Int64 Cla_id { get; set; }
        public Int64 Sta_id { get; set; }
        public string Tick_assunto { get; set; }
        public Int16 Tick_tipo { get; set; }//0-externo;1-interno
    }
}