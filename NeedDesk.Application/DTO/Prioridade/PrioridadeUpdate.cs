﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Prioridade
{
    public class PrioridadeUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Pri_id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Pri_descricao { get; set; }
    }
}