using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.StartupExtensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection ConfigureSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}