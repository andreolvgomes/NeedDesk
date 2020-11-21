using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Departamento;
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
    public class DepartamentosControllerTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public DepartamentosControllerTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Departamento")]
        [Trait("Departamentos", "Integração API")]
        public async Task NovaDepartamento_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new DepartamentoCreate()
            {
                Dep_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/departamentos", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Departamento")]
        [Trait("Departamentos", "Integração API")]
        public async Task UpdateDepartamento_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid id = await _testsFixture.NewDepartamentoApi();
            var value = new DepartamentoUpdate()
            {
                Dep_id = id,
                Dep_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/departamentos", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Departamento Não existente")]
        [Trait("Departamentos", "Integração API")]
        public async Task UpdateDepartamento_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new DepartamentoUpdate()
            {
                Dep_id = Guid.NewGuid(),
                Dep_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/departamentos", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Departamento")]
        [Trait("Departamentos", "Integração API")]
        public async Task RemoverDepartamento_DepartamentoExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid id = await _testsFixture.NewDepartamentoApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/departamentos/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Departamento Não existente")]
        [Trait("Departamentos", "Integração API")]
        public async Task RemoverDepartamento_DepartamentoNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/departamentos/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Departamentos")]
        [Trait("Departamentos", "Integração API")]
        public async Task GetAll_DepartamentoresExistentes_DeveRetornarSucesso()
        {
            // Act
            var responde = await _testsFixture.Client.GetAsync($"api/departamentos/");

            // Assert
            responde.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Departamento pelo Id")]
        [Trait("Departamentos", "Integração API")]
        public async Task Get_DepartamentoExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewDepartamentoApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/departamentos/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Departamento Não existente pelo Id")]
        [Trait("Departamentos", "Integração API")]
        public async Task Get_DepartamentoNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/departamentos/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Departamentos", "Integração API")]
        public async Task Status_MudarStatusDepartamento_DeveRetornarSucesso()
        {
            // Arrange
            Guid id = await _testsFixture.NewDepartamentoApi();
            var value = new DepartamentoStatus()
            {
                Dep_id = id,
                Dep_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/departamentos/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Departamento Não existente")]
        [Trait("Departamentos", "Integração API")]
        public async Task Status_MudarStatusDepartamento_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new DepartamentoStatus()
            {
                Dep_id = Guid.NewGuid(),
                Dep_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/departamentos/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}