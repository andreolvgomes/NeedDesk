using NeedDesk.Application.DTO.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IStatusAppService
    {
        IEnumerable<StatusResult> All();
        Guid Create(StatusCreate statusCreate);
        void Update(StatusUpdate statusUpdate);
        void Remove(Guid cat_id);
        StatusResult Get(Guid cat_id);
        bool Status(StatusStatus statusStatus);
    }
}