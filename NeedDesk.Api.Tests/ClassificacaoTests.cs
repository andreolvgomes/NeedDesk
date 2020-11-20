using NeedDesk.Api.Tests.Config;
using NeedDesk.Application.DTO.Classificacao;
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
    public class ClassificacaoTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public ClassificacaoTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Cadastrar nova Classificação")]
        [Trait("Classificação", "Integração API")]
        public async Task NovaClassificao_CadastrarNovo_DeveCadastrarSucesso()
        {
            // Arrange
            var value = new ClassificacaoCreate()
            {
                Cla_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Act
            var response = await _testsFixture.Client.PostAsJsonAsync("api/classificacao", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Classificação")]
        [Trait("Classificação", "Integração API")]
        public async Task UpdateClassificao_Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClassificacaoApi();
            var value = new ClassificacaoUpdate()
            {
                Cla_id = cat_id,
                Cla_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/classificacao", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Atualizar Classificação Não existente")]
        [Trait("Classificação", "Integração API")]
        public async Task UpdateClassificao_Atualizar_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ClassificacaoUpdate()
            {
                Cla_id = Guid.NewGuid(),
                Cla_descricao = Guid.NewGuid().ToString()
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync("api/classificacao", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Remover Classificação")]
        [Trait("Classificação", "Integração API")]
        public async Task RemoverClassificao_ClassificaoExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClassificacaoApi();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/classificacao/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover Classificação Não existente")]
        [Trait("Classificação", "Integração API")]
        public async Task RemoverClassificao_ClassificaoNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            var cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.DeleteAsync($"api/classificacao/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Listar Classificações")]
        [Trait("Classificação", "Integração API")]
        public async Task GetAll_ClassificaosExistentes_DeveRetornarSucesso()
        {
            // Act
            var response = await _testsFixture.Client.GetAsync($"api/classificacao/");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Classificação pelo Id")]
        [Trait("Classificação", "Integração API")]
        public async Task Get_ClassificaoExistente_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClassificacaoApi();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/classificacao/{cat_id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar Classificação Não existente pelo Id")]
        [Trait("Classificação", "Integração API")]
        public async Task Get_ClassificaoNaoExistente_DeveRetornarBadRequest()
        {
            // Arrange
            Guid cat_id = Guid.NewGuid();

            // Act
            var response = await _testsFixture.Client.GetAsync($"api/classificacao/{cat_id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo)")]
        [Trait("Classificação", "Integração API")]
        public async Task Status_MudarStatusClassificao_DeveRetornarSucesso()
        {
            // Arrange
            Guid cat_id = await _testsFixture.NewClassificacaoApi();
            var value = new ClassificacaoStatus()
            {
                Cla_id = cat_id,
                Cla_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/classificacao/status", value);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Mudar Status(ativo/inativo) de Classificação Não existente")]
        [Trait("Classificação", "Integração API")]
        public async Task Status_MudarStatusClassificao_DeveRetornarBadRequest()
        {
            // Arrange
            var value = new ClassificacaoStatus()
            {
                Cla_id = Guid.NewGuid(),
                Cla_inativo = true,
            };

            // Act
            var response = await _testsFixture.Client.PutAsJsonAsync($"api/classificacao/status", value);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}