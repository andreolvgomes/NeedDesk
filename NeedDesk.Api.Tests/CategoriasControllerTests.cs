using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Categoria;
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
    public class CategoriasControllerTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public CategoriasControllerTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Categoria")]
        [Trait("Categorias", "Integração API")]
        public async Task NovaCategoria_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new CategoriaCreate()
            {
                Cat_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/categorias", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Categoria")]
        [Trait("Categorias", "Integração API")]
        public async Task UpdateCategoria_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewCategoriaApi();
            var value = new CategoriaUpdate()
            {
                Cat_id = cat_id,
                Cat_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/categorias", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Categoria Não existente")]
        [Trait("Categorias", "Integração API")]
        public async Task UpdateCategoria_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new CategoriaUpdate()
            {
                Cat_id = Guid.NewGuid(),
                Cat_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/categorias", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Categoria")]
        [Trait("Categorias", "Integração API")]
        public async Task RemoverCategoria_CategoriaExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewCategoriaApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/categorias/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Categoria Não existente")]
        [Trait("Categorias", "Integração API")]
        public async Task RemoverCategoria_CategoriaNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/categorias/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Categorias")]
        [Trait("Categorias", "Integração API")]
        public async Task GetAll_CategoriasExistentes_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/categorias/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Categoria pelo Id")]
        [Trait("Categorias", "Integração API")]
        public async Task Get_CategoriaExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewCategoriaApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/categorias/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Categoria Não existente pelo Id")]
        [Trait("Categorias", "Integração API")]
        public async Task Get_CategoriaNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/categorias/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Categorias", "Integração API")]
        public async Task Status_MudarStatusCategoria_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewCategoriaApi();
            var value = new CategoriaStatus()
            {
                Cat_id = cat_id,
                Cat_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/categorias/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Categoria Não existente")]
        [Trait("Categorias", "Integração API")]
        public async Task Status_MudarStatusCategoria_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new CategoriaStatus()
            {
                Cat_id = Guid.NewGuid(),
                Cat_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/categorias/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}