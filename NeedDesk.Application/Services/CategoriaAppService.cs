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

        public Guid Create(CategoriaCreate categoriaCreate)
        {
            return (Guid)_categoriaRepository.Insert(_mapper.Map<Categoria>(categoriaCreate));
        }

        public CategoriaResult Get(Guid cat_id)
        {
            return _mapper.Map<CategoriaResult>(_categoriaRepository.FindById(cat_id));
        }

        public bool Status(CategoriaStatus categoriaStatus)
        {
            return _categoriaRepository.Status(_mapper.Map<Categoria>(categoriaStatus));
        }

        public void Remove(Guid cat_id)
        {
            _categoriaRepository.Delete(cat_id);
        }

        public void Update(CategoriaUpdate categoriaUpdate)
        {
            _categoriaRepository.Update(_mapper.Map(categoriaUpdate, _categoriaRepository
                        .FindById(categoriaUpdate.Cat_id)));
        }
    }
}