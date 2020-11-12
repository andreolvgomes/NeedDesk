using AutoMapper;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaAppService(IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoriaResult> All()
        {
            return _mapper.Map<IEnumerable<CategoriaResult>>(_categoriaRepository.All(""));
        }

        public long Create(CategoriaCreate categoriaCreate)
        {
            return (Int64)_categoriaRepository.Insert(_mapper.Map<Categoria>(categoriaCreate));
        }

        public CategoriaResult Get(long cat_id)
        {
            return _mapper.Map<CategoriaResult>(_categoriaRepository.FindById(cat_id));
        }

        public bool Inativar(long cat_id)
        {
            return _categoriaRepository.Inativar(cat_id);
        }

        public void Remove(long cat_id)
        {
            _categoriaRepository.Delete(_categoriaRepository.FindById(cat_id));
        }

        public void Update(CategoriaUpdate categoriaUpdate)
        {
            _categoriaRepository.Update(_mapper.Map<Categoria>(categoriaUpdate));
        }
    }
}
