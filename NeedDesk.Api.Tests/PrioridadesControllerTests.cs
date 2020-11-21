using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Prioridade;
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
    public class PrioridadesControllerTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public PrioridadesControllerTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Prioridade")]
        [Trait("Prioridades", "Integração API")]
        public async Task NovaPrioridade_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new PrioridadeCreate()
            {
                Pri_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/prioridades", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Prioridade")]
        [Trait("Prioridades", "Integração API")]
        public async Task UpdatePrioridade_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewPrioridadeApi();
            var value = new PrioridadeUpdate()
            {
                Pri_id = cat_id,
                Pri_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/prioridades", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Prioridade Não existente")]
        [Trait("Prioridades", "Integração API")]
        public async Task UpdatePrioridade_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new PrioridadeUpdate()
            {
                Pri_id = Guid.NewGuid(),
                Pri_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/prioridades", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Prioridade")]
        [Trait("Prioridades", "Integração API")]
        public async Task RemoverPrioridade_PrioridadeExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewPrioridadeApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/prioridades/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Prioridade Não existente")]
        [Trait("Prioridades", "Integração API")]
        public async Task RemoverPrioridade_PrioridadeNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/prioridades/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Prioridades")]
        [Trait("Prioridades", "Integração API")]
        public async Task GetAll_PrioridadesExistentes_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/prioridades/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Prioridade pelo Id")]
        [Trait("Prioridades", "Integração API")]
        public async Task Get_PrioridadeExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewPrioridadeApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/prioridades/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Prioridade Não existente pelo Id")]
        [Trait("Prioridades", "Integração API")]
        public async Task Get_PrioridadeNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/prioridades/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Prioridades", "Integração API")]
        public async Task Status_MudarStatusPrioridade_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewPrioridadeApi();
            var value = new PrioridadeStatus()
            {
                Pri_id = cat_id,
                Pri_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/prioridades/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Prioridade Não existente")]
        [Trait("Prioridades", "Integração API")]
        public async Task Status_MudarStatusPrioridade_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new PrioridadeStatus()
            {
                Pri_id = Guid.NewGuid(),
                Pri_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/prioridades/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}