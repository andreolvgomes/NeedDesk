using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Solhistorico
    {
        public Int64 PerfilId { get; set; }
        public Int64 SolicitacaoId { get; set; }
        public int And_nrandamento { get; set; }
        public DateTime And_dtandamento { get; set; }
        public string And_texto { get; set; }
    }
}