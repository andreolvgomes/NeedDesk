using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.DTO.Categoria
{
    public class CategoriaResult
    {
        public Int64 Cat_id { get; set; }
        public string Cat_descricao { get; set; }
        public bool Cat_inativo { get; set; }
    }
}