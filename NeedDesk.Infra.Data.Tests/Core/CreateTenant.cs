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
        private static Int64 tenant_id_session;

        public static Int64 Tenant_id()
        {
            if (tenant_id_session > 0)
                return tenant_id_session;
            ITenantRepository tenantRepository = new TenantRepository();
            
            // test insert
            tenant_id_session = (Int64)tenantRepository.Insert(new Tenant() { Identifier = Guid.NewGuid() });
            return tenant_id_session;
        }
    }
}