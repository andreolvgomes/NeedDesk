using System;
using System.Collections.Generic;
using System.Text;

namespace TodayTask.Domain.Models
{
    public class Solicitacao : EntityMaster
    {
        public Int64 DepartamentoId { get; set; }
        public Int64 CategoriaId { get; set; }
        public Int64 ClassificacaoId { get; set; }
        public Int64 StatusId { get; set; }
        public Int64 ClienteId { get; set; }
        public Int64 PerfilId { get; set; }

        public int Sol_preioridade { get; set; }
        public string Sol_assunto { get; set; }
        public DateTime Sol_dtprevisao { get; set; }
        public DateTime Sol_hrprevisao { get; set; }
        public string Sol_texto { get; set; }
    }
}