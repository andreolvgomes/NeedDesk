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
                IUserRepository userRepository = new UserRepository(Test.Connect);

                // test insert
                var id = (Guid)userRepository.Insert(CreateUser.NewUser());
                Assert.True(!id.IsEmpty());

                // test get by id
                User user = userRepository.FindById(id);
                Assert.True(user != null);

                // test update
                user.CreateAt = DateTime.Now;
                var rowscuccess = userRepository.Update(user);
                Assert.True(rowscuccess > 0);

                // test delete
                userRepository.Delete(user);

                for (int i = 1; i <= 5; i++)
                    userRepository.Insert(CreateUser.NewUser());

                var list = userRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Fact]
        public void ShouldFindByLogin()
        {
            try
            {
                IUserRepository userRepository = new UserRepository(Test.Connect);

                var user = CreateUser.NewUser();
                userRepository.Insert(user);
                var login = userRepository.FindByLogin(user.Use_email);
                Assert.True(login != null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
