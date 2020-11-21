using Microsoft.AspNetCore.Mvc.Testing;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.DTO.Colaborador;
using NeedDesk.Application.DTO.Status;
using NeedDesk.Application.DTO.Departamento;
using NeedDesk.Application.DTO.Prioridade;
using NeedDesk.Application.DTO.User;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using NeedDesk.Application.DTO.Cliente;

namespace NeedDesk.Api.Tests.Config
{
    //[CollectionDefinition(nameof(IntegrationApiStatupTestsFixtureCollection))]
    //public class IntegrationApiStatupTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }

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

        public async Task<Guid> NewCategoriaApi()
        {
            CategoriaCreate value = new CategoriaCreate()
            {
                Cat_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/categorias", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<CategoriaResult>(result);
            return jsonString.Cat_id;
        }

        public async Task<Guid> NewStatusApi()
        {
            var value = new StatusCreate()
            {
                Sta_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/status", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<StatusResult>(result);
            return jsonString.Sta_id;
        }

        public async Task<Guid> NewClienteApi()
        {
            var value = new ClienteCreate()
            {
                Cli_nome = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/clientes", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<ClienteResult>(result);
            return jsonString.Cli_id;
        }

        public async Task<Guid> NewDepartamentoApi()
        {
            var value = new DepartamentoCreate()
            {
                Dep_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/departamentos", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<DepartamentoResult>(result);
            return jsonString.Dep_id;
        }

        public async Task<Guid> NewPrioridadeApi()
        {
            var value = new PrioridadeCreate()
            {
                Pri_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/prioridades", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<PrioridadeResult>(result);
            return jsonString.Pri_id;
        }

        public async Task<Guid> NewClassificacaoApi()
        {
            ClassificacaoCreate value = new ClassificacaoCreate()
            {
                Cla_descricao = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/classificacao", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<ClassificacaoResult>(result);
            return jsonString.Cla_id;
        }

        public async Task<Guid> NewColaboradorApi()
        {
            Guid user_id = await this.NewUserApi();
            ColaboradorCreate value = new ColaboradorCreate()
            {
                Col_nome = Guid.NewGuid().ToString(),
                Col_sobrenome = Guid.NewGuid().ToString(),
                Tenant_id = TenantId.Tenant_id,
                Use_id = user_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/colaboradores", value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var jsonString = JsonConvert.DeserializeObject<ColaboradorResult>(result);
            return jsonString.Col_id;
        }

        public async Task<Guid> NewUserApi()
        {
            UserCreate value = new UserCreate()
            {
                Use_email = "teste@gmail.com",
                Use_senha = "123456",
                Tenant_id = TenantId.Tenant_id
            };

            // Recriando o client para evitar configurações de Web
            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/users", value);
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