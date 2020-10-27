using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class UserPerfil : EntityMaster
    {
        public Int64 UserId { get; set; }
        public string Per_nome { get; set; }
        public DateTime Per_dtnascimento { get; set; }
        public string Per_foto { get; set; }
        public int Per_sexo { get; set; }
        public string Per_endereco { get; set; }
        public string Per_numero { get; set; }
        public string Per_bairro { get; set; }
        public string Per_minicipio { get; set; }
        public string Per_estado { get; set; }
    }
}