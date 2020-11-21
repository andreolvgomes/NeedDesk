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

        //protected async Task AuthenticationAsync()
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        //}

        //private async Task<string> GetJwtAsync()
        //{
        //    // Arrange
        //    var value = new UserCreate()
        //    {
        //        Tenant_id = TenantId.Tenant_id,
        //        Use_email = "teste@gmail.com.br",
        //        Use_senha = "123456"
        //    };

        //    // Act
        //    var response = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, value);
        //    var result = await response.Content.ReadAsAsync<UserResult>();
        //}
    }
}