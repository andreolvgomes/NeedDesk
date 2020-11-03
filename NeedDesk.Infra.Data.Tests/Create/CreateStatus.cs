using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateStatus
    {
        private static Status StatusSession;

        public static Status Status()
        {
            if (StatusSession == null)
            {
                IStatusRepository statusRepository = new StatusRepository(Test.Connect);
                var id = statusRepository.Insert(NewStatus());
                StatusSession = statusRepository.FindById(id);
            }
            return StatusSession;
        }

        public static Status NewStatus()
        {
            return new Status()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Sta_descricao = Faker.Company.Name()
            };
        }
    }
}
