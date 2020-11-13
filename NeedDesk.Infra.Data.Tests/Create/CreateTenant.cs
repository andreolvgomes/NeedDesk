using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateTenant
    {
        private static Guid tenant_id_session;

        public static Guid Tenant_id()
        {
            if (!tenant_id_session.IsEmpty())
                return tenant_id_session;
            ITenantRepository tenantRepository = new TenantRepository(Test.Connect);
            
            // test insert
            tenant_id_session = (Guid)tenantRepository.Insert(new Tenant() { });
            return tenant_id_session;
        }
    }
}