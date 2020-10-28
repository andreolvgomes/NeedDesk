using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Categoria : EntityMaster
    {
        public string Cat_descricao { get; set; }
        public bool Cat_inativo { get; set; }
    }
}