using AutoMapper;
using NeedDesk.Application.DTO.Status;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Services
{
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusAppService(IMapper mapper, IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public IEnumerable<StatusResult> All()
        {
            return _mapper.Map<IEnumerable<StatusResult>>(_statusRepository.All(""));
        }

        public Guid Create(StatusCreate statusCreate)
        {
            return (Guid)_statusRepository.Insert(_mapper.Map<Status>(statusCreate));
        }

        public StatusResult Get(Guid cat_id)
        {
            return _mapper.Map<StatusResult>(_statusRepository.FindById(cat_id));
        }

        public bool Status(StatusStatus statusStatus)
        {
            return _statusRepository.Status(_mapper.Map<Status>(statusStatus));
        }

        public void Remove(Guid cat_id)
        {
            _statusRepository.Delete(cat_id);
        }

        public void Update(StatusUpdate statusUpdate)
        {
            _statusRepository.Update(_mapper.Map(statusUpdate, _statusRepository
                        .FindById(statusUpdate.Sta_id)));
        }
    }
}