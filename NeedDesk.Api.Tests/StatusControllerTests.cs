using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Status;
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
    public class StatusControllerTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public StatusControllerTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Status")]
        [Trait("Status", "Integração API")]
        public async Task NovaStatus_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new StatusCreate()
            {
                Sta_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Status")]
        [Trait("Status", "Integração API")]
        public async Task UpdateStatus_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewStatusApi();
            var value = new StatusUpdate()
            {
                Sta_id = cat_id,
                Sta_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Status Não existente")]
        [Trait("Status", "Integração API")]
        public async Task UpdateStatus_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new StatusUpdate()
            {
                Sta_id = Guid.NewGuid(),
                Sta_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Status")]
        [Trait("Status", "Integração API")]
        public async Task RemoverStatus_StatusExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewStatusApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/status/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Status Não existente")]
        [Trait("Status", "Integração API")]
        public async Task RemoverStatus_StatusNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/status/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Statuss")]
        [Trait("Status", "Integração API")]
        public async Task GetAll_StatussExistentes_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/status/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Status pelo Id")]
        [Trait("Status", "Integração API")]
        public async Task Get_StatusExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewStatusApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/status/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Status Não existente pelo Id")]
        [Trait("Status", "Integração API")]
        public async Task Get_StatusNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/status/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Status", "Integração API")]
        public async Task Status_MudarStatusStatus_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewStatusApi();
            var value = new StatusStatus()
            {
                Sta_id = cat_id,
                Sta_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/status/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Status Não existente")]
        [Trait("Status", "Integração API")]
        public async Task Status_MudarStatusStatus_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new StatusStatus()
            {
                Sta_id = Guid.NewGuid(),
                Sta_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/status/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}