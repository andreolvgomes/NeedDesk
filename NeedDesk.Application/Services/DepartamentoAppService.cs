using AutoMapper;
using NeedDesk.Application.DTO.Departamento;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class DepartamentoAppService : IDepartamentoAppService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMapper _mapper;

        public DepartamentoAppService(IMapper mapper, IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
            _mapper = mapper;
        }

        public IEnumerable<DepartamentoResult> All()
        {
            return _mapper.Map<IEnumerable<DepartamentoResult>>(_departamentoRepository.All(""));
        }

        public Guid Create(DepartamentoCreate departamentoCreate)
        {
            return (Guid)_departamentoRepository.Insert(_mapper.Map<Departamento>(departamentoCreate));
        }

        public DepartamentoResult Get(Guid cat_id)
        {
            return _mapper.Map<DepartamentoResult>(_departamentoRepository.FindById(cat_id));
        }

        public bool Status(DepartamentoStatus departamentoStatus)
        {
            return _departamentoRepository.Status(_mapper.Map<Departamento>(departamentoStatus));
        }

        public void Remove(Guid cat_id)
        {
            _departamentoRepository.Delete(cat_id);
        }

        public void Update(DepartamentoUpdate departamentoUpdate)
        {
            _departamentoRepository.Update(_mapper.Map(departamentoUpdate, _departamentoRepository
                        .FindById(departamentoUpdate.Dep_id)));
        }
    }
}