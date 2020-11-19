using Microsoft.AspNetCore.Mvc.Testing;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.DTO.Colaborador;
using NeedDesk.Application.DTO.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NeedDesk.Api.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>>
    {
    }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly NeedDeskAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new NeedDeskAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public async Task<Guid> CadastraCategoriaApi()
        {
            var itemInfo = new CategoriaCreate()
            {
                Cat_descricao = Guid.NewGuid().ToString(),
                Tenant_id = new Guid("e40b0c16-2a13-4fad-97c0-11baa91533d8")
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/categorias", itemInfo);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<CategoriaResult>(result);
            return jsonString.Cat_id;
        }

        public async Task<Guid> CadastraClassificacaoApi()
        {
            var itemInfo = new ClassificacaoCreate()
            {
                Cla_descricao = Guid.NewGuid().ToString(),
                Tenant_id = new Guid("e40b0c16-2a13-4fad-97c0-11baa91533d8")
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/classificacao", itemInfo);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<ClassificacaoResult>(result);
            return jsonString.Cla_id;
        }

        public async Task<Guid> CadastraColaboradorApi()
        {
            var itemInfo = new ColaboradorCreate()
            {
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/colaborador", itemInfo);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<ColaboradorResult>(result);
            return jsonString.Col_id;
        }

        public async Task<Guid> CadastraUserApi()
        {
            var itemInfo = new UserCreate()
            {
                Use_email = "teste@gmail.com",
                Use_senha = "123456",
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/users", itemInfo);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<UserResult>(result);
            return jsonString.Use_id;
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}