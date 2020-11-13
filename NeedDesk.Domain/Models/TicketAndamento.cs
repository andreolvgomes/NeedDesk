using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Ticket_Andamentos")]
    public class TicketAndamento : EntityBase, IEntity
    {
        [Key]
        public Guid And_id { get; set; }
        public Guid Tic_id { get; set; }
        public string And_texto { get; set; }
    }
}