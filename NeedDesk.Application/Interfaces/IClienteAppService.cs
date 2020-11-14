using NeedDesk.Application.DTO.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteResult> All();
        Guid Create(ClienteCreate clienteCreate);
        void Update(ClienteUpdate clienteUpdate);
        void Remove(Guid cat_id);
        ClienteResult Get(Guid cat_id);
        bool Status(ClienteStatus clienteStatus);
    }
}