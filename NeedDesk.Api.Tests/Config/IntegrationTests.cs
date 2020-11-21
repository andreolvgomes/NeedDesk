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
            if (!UserAuthentication.IsAuthentication())
            {
                UserAuthentication.Email = "teste@gmail.com.br";
                UserAuthentication.Password = "123456";

                // Arrange
                var value = new UserCreate()
                {
                    Tenant_id = TenantId.Tenant_id,
                    Use_email = UserAuthentication.Email,
                    Use_senha = UserAuthentication.Password
                };

                // Act
                await _client.PostAsJsonAsync(ApiRoutes.Users.Create, value);
            }

            var responseLogIn = await _client.PostAsJsonAsync(ApiRoutes.Identity.LogIn, new LogIn()
            {
                 Use_senha = UserAuthentication.Password,
                 Use_email = UserAuthentication.Email
            });

            var sigInAuthorization = await responseLogIn.Content.ReadAsAsync<AuthenticationResult>();
            return sigInAuthorization.Token;
        }
    }
}