﻿using Microsoft.Extensions.DependencyInjection;
using NeedDesk.Application.Interfaces;
using NeedDesk.Application.Services;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.CrossCutting.DependecyInjection
{
    public class ConfigureInjectServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<ILoginAppService, LoginAppService>();
            services.AddTransient<ICategoriaAppService, CategoriaAppService>();
        }
    }
}