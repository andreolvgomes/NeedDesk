using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Categoria;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NeedDesk.Api.Tests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class CategoriasTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public CategoriasTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Categoria")]
        [Trait("Categoria", "Integreação API - Categorias")]
        public async Task NovaCategoria_CadastrarNovo_DeveCadastrarComSucesso()
        {
            var itemInfo = new CategoriaCreate()
            {
                Cat_descricao = Guid.NewGuid().ToString(),
                Tenant_id = new Guid("e40b0c16-2a13-4fad-97c0-11baa91533d8")
            };

            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/categorias", itemInfo);
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Categoria existente")]
        [Trait("Categoria", "Integreação API - Categorias")]
        public async Task RemoverCategoria_CategoriaExistente_DeveRetornarSucesso()
        {
            // Arrange
            var produtoId = new Guid("e40b0c16-2a14-490e-8068-f4f192cd0bff");

            // Act
            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/categorias/{produtoId}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Listar Categorias existententes")]
        [Trait("Categoria", "Integreação API - Categorias")]
        public async Task ListarCategorias_CategoriaExistente_DeveRetornarSucesso()
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"api/categorias/");

            // Assert
            getResponse.EnsureSuccessStatusCode();
            string list = await getResponse.Content.ReadAsStringAsync();
        }
    }
}