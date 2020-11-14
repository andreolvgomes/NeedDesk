using AutoMapper;
using NeedDesk.Application.DTO.Colaborador;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class ColaboradorAppService : IColaboradorAppService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public ColaboradorAppService(IMapper mapper, IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }

        public IEnumerable<ColaboradorResult> All()
        {
            return _mapper.Map<IEnumerable<ColaboradorResult>>(_colaboradorRepository.All(""));
        }

        public Guid Create(ColaboradorCreate colaboradorCreate)
        {
            return (Guid)_colaboradorRepository.Insert(_mapper.Map<Colaborador>(colaboradorCreate));
        }

        public ColaboradorResult Get(Guid cat_id)
        {
            return _mapper.Map<ColaboradorResult>(_colaboradorRepository.FindById(cat_id));
        }

        public bool Status(ColaboradorStatus colaboradorStatus)
        {
            return _colaboradorRepository.Status(_mapper.Map<Colaborador>(colaboradorStatus));
        }

        public void Remove(Guid cat_id)
        {
            _colaboradorRepository.Delete(cat_id);
        }

        public void Update(ColaboradorUpdate colaboradorUpdate)
        {
            _colaboradorRepository.Update(_mapper.Map(colaboradorUpdate, _colaboradorRepository
                        .FindById(colaboradorUpdate.Col_id)));
        }
    }
}