using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedDesk.Api
{
    //public static class RoutesCategorias
    //{
    //    private static readonly string Root = "api";
    //    private static readonly string Name = "categorias";
    //    private static readonly string Base = $"{Root}/{Name}";

    //    public static readonly string Create = Base;
    //    public static readonly string GetAll = Base;
    //    public static readonly string GetById = $"{Base}/id";
    //}

    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root;// + "/" + Version;

        public static class Categorias
        {
            public const string GetAll = Base + "/categorias";
            public const string Get = Base + "/categorias/{id}";
            public const string Create = Base + "/categorias/";
            public const string Update = Base + "/categorias";
            public const string Delete = Base + "/categorias/{id}";
            public const string Status = Base + "/categorias/status";
        }

        public static class Users
        {
            public const string GetAll = Base + "/users";
            public const string Get = Base + "/users/{id}";
            public const string Create = Base + "/users/";
            public const string Update = Base + "/users";
            public const string Delete = Base + "/users/{id}";

            public const string LogIn = Base + "/users/{id}";
        }
    }
}