using AutoMapper;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class ClassificacaoAppService : IClassificacaoAppService
    {
        private readonly IClassificacaoRepository _classificacaoRepository;
        private readonly IMapper _mapper;

        public ClassificacaoAppService(IMapper mapper, IClassificacaoRepository classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClassificacaoResult> All()
        {
            return _mapper.Map<IEnumerable<ClassificacaoResult>>(_classificacaoRepository.All(""));
        }

        public Guid Create(ClassificacaoCreate classificacaoCreate)
        {
            return (Guid)_classificacaoRepository.Insert(_mapper.Map<Classificacao>(classificacaoCreate));
        }

        public ClassificacaoResult Get(Guid cat_id)
        {
            return _mapper.Map<ClassificacaoResult>(_classificacaoRepository.FindById(cat_id));
        }

        public void Remove(Guid cat_id)
        {
            _classificacaoRepository.Delete(cat_id);
        }

        public bool Status(ClassificacaoStatus classificacaoStatus)
        {
            return _classificacaoRepository.Status(_mapper.Map<Classificacao>(classificacaoStatus));
        }

        public void Update(ClassificacaoUpdate classificacaoUpdate)
        {
            _classificacaoRepository.Update(_mapper.Map(classificacaoUpdate, _classificacaoRepository
                .FindById(classificacaoUpdate.Cla_id)));
        }
    }
}