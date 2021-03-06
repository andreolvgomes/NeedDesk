﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Clientes")]
    public class Cliente : EntityBase, IEntity
    {
        [Key]
        public Guid Cli_id { get; set; }
        public string Cli_nome { get; set; }
        public bool Cli_inativo { get; set; }
    }
}