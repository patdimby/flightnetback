using System;

using Microsoft.Extensions.DependencyInjection;

namespace Flight.Application.Applications
{
    public static class CorsMiddleware
    {
        public static void ConfigureCORS(this IServiceCollection services)
        {
           services.AddCors(options =>
           {
               options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
           });
        }
    }
}
