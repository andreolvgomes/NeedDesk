using AutoMapper;
using NeedDesk.Application.DTO.Cliente;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClienteResult> All()
        {
            return _mapper.Map<IEnumerable<ClienteResult>>(_clienteRepository.All(""));
        }

        public Guid Create(ClienteCreate clienteCreate)
        {
            return (Guid)_clienteRepository.Insert(_mapper.Map<Cliente>(clienteCreate));
        }

        public ClienteResult Get(Guid cat_id)
        {
            return _mapper.Map<ClienteResult>(_clienteRepository.FindById(cat_id));
        }

        public bool Status(ClienteStatus clienteStatus)
        {
            return _clienteRepository.Status(_mapper.Map<Cliente>(clienteStatus));
        }

        public void Remove(Guid cat_id)
        {
            _clienteRepository.Delete(cat_id);
        }

        public void Update(ClienteUpdate clienteUpdate)
        {
            _clienteRepository.Update(_mapper.Map(clienteUpdate, _clienteRepository
                        .FindById(clienteUpdate.Cli_id)));
        }
    }
}