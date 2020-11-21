using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NeedDesk.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NeedDesk.Api.Tests.Config
{
    public class IntegrationTests
    {
        protected readonly HttpClient _client;

        public IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        //services.RemoveAll(
                    });
                });

            _client = appFactory.CreateClient();
        }

        protected async Task AuthenticationAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            string use_email = "teste@gmail.com.br";
            string use_senha = "123456";
            // Arrange
            var value = new UserCreate()
            {
                Tenant_id = TenantId.Tenant_id,
                Use_email = use_email,
                Use_senha = use_senha
            };

            // Act
            var responseCreateUser = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, value);

            var responseLogIn = await _client.PostAsJsonAsync(ApiRoutes.Users.LogIn, new LogIn()
            {
                 Use_senha = use_senha,
                 Use_email = use_email
            });

            var sigInAuthorization = await responseLogIn.Content.ReadAsAsync<SigInAuthorization>();
            return sigInAuthorization.Token;
        }
    }
}