using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateDepartamento
    {
        private static Departamento DepartamentoSession;

        public static Departamento Departamento()
        {
            if (DepartamentoSession == null)
            {
                IDepartamentoRepository departamentoRepository = new DepartamentoRepository();
                var id = departamentoRepository.Insert(NewDepartamento());
                DepartamentoSession = departamentoRepository.FindById(id);
            }
            return DepartamentoSession;
        }

        public static Departamento NewDepartamento()
        {
            return new Departamento()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Dep_descricao = Faker.Company.Name()
            };
        }
    }
}
