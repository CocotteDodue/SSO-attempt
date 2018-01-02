using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions.Startup
{
    public static class IHostingEnvironmentExtensions
    {
        public static bool IsProdEnvironment(this IHostingEnvironment env)
        {
            return env.IsProduction() || env.IsEnvironment("ProductionAzure");
        }
        public static bool IsApiOnly(this IHostingEnvironment env)
        {
            return env.IsEnvironment("ApiOnly");
        }
    }
}
