using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Colaborador;
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
    public class ColaboradoresTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public ColaboradoresTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Categoria")]
        [Trait("Colaboradores", "Integração API")]
        public async Task NovaColaborador_CadastrarNovo_DeveCadastrarSucesso()
        {
            Guid cat_id = await _testsFixture.NewUserApi();
            // Arrange
            var value = new ColaboradorCreate()
            {
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
                Use_id = cat_id,
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/colaboradores", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Colaborador")]
        [Trait("Colaboradores", "Integração API")]
        public async Task UpdateColaborador_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid col_id = await _testsFixture.NewColaboradorApi();
            var value = new ColaboradorUpdate()
            {
                Col_id = col_id,
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/colaboradores", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Colaborador Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task UpdateColaborador_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ColaboradorUpdate()
            {
                Col_id = Guid.NewGuid(),
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
            };
            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/colaboradores", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Colaborador")]
        [Trait("Colaboradores", "Integração API")]
        public async Task RemoverColaborador_ColaboradorExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewColaboradorApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/colaboradores/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Colaborador Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task RemoverColaborador_ColaboradorNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/colaboradores/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Colaboradores")]
        [Trait("Colaboradores", "Integração API")]
        public async Task GetAll_ColaboradoresExistentes_DeveRetornarSucesso()
        {
            // Act
            var response = await _testsFixture.Client.GetAsync($"api/colaboradores/");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Colaborador pelo Id")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Get_ColaboradorExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewColaboradorApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/colaboradores/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Colaborador Não existente pelo Id")]
        [Trait("Colaboradores", "Integração API")]
        public async Task GetColaboradorNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/colaboradores/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Status_MudarStatusColaborador_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewColaboradorApi();
            var value = new ColaboradorStatus()
            {
                Col_id = cat_id,
                Col_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/colaboradores/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Colaborador Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Status_MudarStatusColaborador_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ColaboradorStatus()
            {
                Col_id = Guid.NewGuid(),
                Col_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/colaboradores/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}