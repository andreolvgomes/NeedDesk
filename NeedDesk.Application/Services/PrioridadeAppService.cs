using AutoMapper;
using NeedDesk.Application.DTO.Prioridade;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class PrioridadeAppService : IPrioridadeAppService
    {
        private readonly IPrioridadeRepository _prioridadeRepository;
        private readonly IMapper _mapper;

        public PrioridadeAppService(IMapper mapper, IPrioridadeRepository prioridadeRepository)
        {
            _prioridadeRepository = prioridadeRepository;
            _mapper = mapper;
        }

        public IEnumerable<PrioridadeResult> All()
        {
            return _mapper.Map<IEnumerable<PrioridadeResult>>(_prioridadeRepository.All(""));
        }

        public Guid Create(PrioridadeCreate prioridadeCreate)
        {
            return (Guid)_prioridadeRepository.Insert(_mapper.Map<Prioridade>(prioridadeCreate));
        }

        public PrioridadeResult Get(Guid cat_id)
        {
            return _mapper.Map<PrioridadeResult>(_prioridadeRepository.FindById(cat_id));
        }

        public void Remove(Guid cat_id)
        {
            _prioridadeRepository.Delete(cat_id);
        }

        public bool Status(PrioridadeStatus prioridadeStatus)
        {
            return _prioridadeRepository.Status(_mapper.Map<Prioridade>(prioridadeStatus));
        }

        public void Update(PrioridadeUpdate prioridadeUpdate)
        {
            _prioridadeRepository.Update(_mapper.Map(prioridadeUpdate, _prioridadeRepository
                .FindById(prioridadeUpdate.Pri_id)));
        }
    }
}