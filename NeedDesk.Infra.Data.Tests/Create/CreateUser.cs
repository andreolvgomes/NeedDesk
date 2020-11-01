using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateUser
    {
        private static User UserSession;

        public static User User()
        {
            if (UserSession != null)
                return UserSession;
            IUserRepository userRepository = new UserRepository();

            // test insert
            var id = (Int64)userRepository.Insert(NewUser());
            UserSession = userRepository.FindById(id);
            return UserSession;
        }

        public static User NewUser()
        {
            return new User()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Use_email = Faker.Internet.Email(),
                Use_senha = Guid.NewGuid().ToString().Substring(0, 5) + new Random().Next(0, 99999).ToString()
            };
        }
    }
}
