using System;
using System.Collections.Generic;
using System.Text;

namespace TodayTask.Domain.Models
{
    public class Ticket : EntityMaster
    {
        public Int64 DepartamentoId { get; set; }
        public Int64 CategoriaId { get; set; }
        public Int64 ClassificacaoId { get; set; }
        public Int64 StatusId { get; set; }
        public Int64 ClienteId { get; set; }
        public Int64 PerfilId { get; set; }

        public string Tic_assunto { get; set; }
        public string Tic_texto { get; set; }
        public int Tic_preioridade { get; set; }
        public DateTime Tic_dtprevisao { get; set; }
        public DateTime Tic_hrprevisao { get; set; }        
    }
}