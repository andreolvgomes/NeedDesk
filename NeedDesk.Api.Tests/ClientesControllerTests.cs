using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Cliente;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NeedDesk.Api.Tests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class ClientesControllerTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public ClientesControllerTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Cliente")]
        [Trait("Clientes", "Integração API")]
        public async Task NovaCliente_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new ClienteCreate()
            {
                Cli_nome = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/clientes", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Cliente")]
        [Trait("Clientes", "Integração API")]
        public async Task UpdateCliente_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClienteApi();
            var value = new ClienteUpdate()
            {
                Cli_id = cat_id,
                Cli_nome = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/clientes", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Cliente Não existente")]
        [Trait("Clientes", "Integração API")]
        public async Task UpdateCliente_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ClienteUpdate()
            {
                Cli_id = Guid.NewGuid(),
                Cli_nome = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/clientes", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Cliente")]
        [Trait("Clientes", "Integração API")]
        public async Task RemoverCliente_ClienteExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClienteApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/clientes/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Cliente Não existente")]
        [Trait("Clientes", "Integração API")]
        public async Task RemoverStatus_StatusNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/clientes/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Clientes")]
        [Trait("Clientes", "Integração API")]
        public async Task GetAll_ClientesExistentes_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/clientes/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Cliente pelo Id")]
        [Trait("Clientes", "Integração API")]
        public async Task Get_ClienteExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClienteApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/clientes/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Cliente Não existente pelo Id")]
        [Trait("Clientes", "Integração API")]
        public async Task Get_ClienteNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/clientes/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Clientes", "Integração API")]
        public async Task Status_MudarStatusCliente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClienteApi();
            var value = new ClienteStatus()
            {
                Cli_id = cat_id,
                Cli_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/clientes/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Cliente Não existente")]
        [Trait("Clientes", "Integração API")]
        public async Task Status_MudarStatusCliente_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ClienteStatus()
            {
                Cli_id = Guid.NewGuid(),
                Cli_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/clientes/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}