﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Ticket_Andamentos")]
    public class TicketAndamento : EntityBase
    {
        public Int64 Tenant_id { get; set; }
        [Key]
        public Int64 And_id { get; set; }
        public Int64 Tic_id { get; set; }
        public string And_texto { get; set; }
    }
}