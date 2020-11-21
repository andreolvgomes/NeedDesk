using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NeedDesk.Api.Tests
{
    public class UsersControllerTests : IntegrationTests
    {
        [Fact(DisplayName = "Cadastrar novo Usuário")]
        [Trait("Users", "Integração API")]
        public async Task Create_CadastrarNovo_DeveRetornarSucesso()
        {
            // Arrange
            var value = new UserCreate()
            {
                Tenant_id = TenantId.Tenant_id,
                Use_email = "teste@gmail.com.br",
                Use_senha = "123456"
            };

            // Act
            var response = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, value);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
