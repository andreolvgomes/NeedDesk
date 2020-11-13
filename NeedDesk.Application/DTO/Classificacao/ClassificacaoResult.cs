using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Classificacao
{
    public class ClassificacaoResult
    {
        public Guid Cla_id { get; set; }
        public string Cla_descricao { get; set; }
        public bool Cla_inativo { get; set; }
    }
}