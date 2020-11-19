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
        public async Task NovaCategoria_CadastrarNovo_DeveCadastrarSucesso()
        {
            Guid cat_id = await _testsFixture.CadastraUserApi();
            // Arrange
            var itemInfo = new ColaboradorCreate()
            {
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
                Use_id = cat_id,
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/colaboradores", itemInfo);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Categoria")]
        [Trait("Colaboradores", "Integração API")]
        public async Task UpdateCategoria_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.CadastraColaboradorApi();
            var itemInfo = new ColaboradorUpdate()
            {
                Col_id = cat_id,
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
            };

            // Act
            var postResponse = await _testsFixture.Client.PutAsJsonAsync("api/colaboradores", itemInfo);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Categoria Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task UpdateCategoria_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var itemInfo = new ColaboradorUpdate()
            {
                Col_id = Guid.NewGuid(),
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
            };
            // Act
            var putResponse = await _testsFixture.Client.PutAsJsonAsync("api/colaboradores", itemInfo);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, putResponse.StatusCode);
        }

        [Fact(DisplayName = "Remover Categoria")]
        [Trait("Colaboradores", "Integração API")]
        public async Task RemoverCategoria_CategoriaExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.CadastraColaboradorApi();

            // Act
            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/colaboradores/{cat_id}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Categoria Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task RemoverCategoria_CategoriaNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/colaboradores/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, deleteResponse.StatusCode);
        }

        [Fact(DisplayName = "Listar Categorias")]
        [Trait("Colaboradores", "Integração API")]
        public async Task GetAll_CategoriasExistentes_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/colaboradores/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Categoria pelo Id")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Get_CategoriaExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.CadastraColaboradorApi();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/colaboradores/{cat_id}");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Categoria Não existente pelo Id")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Get_CategoriaNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/colaboradores/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Status_MudarStatusCategoria_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.CadastraColaboradorApi();
            ColaboradorStatus colaboradorStatus = new ColaboradorStatus()
            {
                Col_id = cat_id,
                Col_inativo = true,
            };

            // Act
            var getResponse = await _testsFixture.Client.PutAsJsonAsync($"api/colaboradores/status", colaboradorStatus);

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Categoria Não existente")]
        [Trait("Colaboradores", "Integração API")]
        public async Task Status_MudarStatusCategoria_DeveRetornarBadRequest()
        {
            // Arrange
            ColaboradorStatus colaboradorStatus = new ColaboradorStatus()
            {
                Col_id = Guid.NewGuid(),
                Col_inativo = true,
            };

            // Act
            var getResponse = await _testsFixture.Client.PutAsJsonAsync($"api/colaboradores/status", colaboradorStatus);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }
    }
}