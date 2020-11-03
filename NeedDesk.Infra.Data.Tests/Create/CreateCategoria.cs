using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateCategoria
    {
        private static Categoria CategoriaSession;

        public static Categoria Categoria()
        {
            if (CategoriaSession == null)
            {
                ICategoriaRepository categoriaRepository = new CategoriaRepository(Test.Connect);
                var id = categoriaRepository.Insert(NewCategoria());
                CategoriaSession = categoriaRepository.FindById(id);
            }
            return CategoriaSession;
        }

        public static Categoria NewCategoria()
        {
            return new Categoria()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cat_descricao = Faker.Company.Name(),
            };
        }
    }
}
