using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IUserRepository userRepository = new UserRepository();

                // test insert
                var id = (Int64)userRepository.Insert(NewClassificacao());
                Assert.True(id > 0);

                // test get by id
                User user = userRepository.GetById(id);
                Assert.True(user != null);

                // test update
                user.CreateAt = DateTime.Now;
                var rowscuccess = userRepository.Update(user);
                Assert.True(rowscuccess > 0);

                // test delete
                userRepository.Delete(user);

                for (int i = 1; i <= 5; i++)
                    userRepository.Insert(NewClassificacao());

                var list = userRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private User NewClassificacao()
        {
            return new User()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Use_email = "test@gmail.com",
                Use_senha = "123456",
                Identifier = Guid.NewGuid()
            };
        }
    }
}
