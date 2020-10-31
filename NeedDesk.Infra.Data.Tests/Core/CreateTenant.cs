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
        public static Int64 Tenant_id()
        {
            ITenantRepository tenantRepository = new TenantRepository();
            var list = tenantRepository.All("Tenant_id > 0");
            if (list != null) return list.FirstOrDefault().Tenant_id;

            // test insert
            return (Int64)tenantRepository.Insert(new Tenant() { Identifier = Guid.NewGuid() });
        }
    }
}
