using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Domain.Repository;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.Helpers;
using Skinet.Core.ServiceContracts.ProductServices;
using Skinet.Core.Services.ProductServices;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Repositories;
using Skinet.Infrastructure.RepositoryContracts;

namespace API.StartupExtensions
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers();

            // Add services and repositories
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductGetServices, ProductGetServices>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Add automapper
            services.AddAutoMapper(typeof(MappingProfiles));

            // Store db context
            services.AddDbContext<StoreDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Override the behavior options when checking for Model state response of the [ApiController] attribute
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actionContext => {
                    var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                                                         .SelectMany(x => x.Value.Errors)
                                                         .Select(x => x.ErrorMessage).ToList();

                    var errorResponse = new ApiValidationErrorResponse() {
                        Errors = errors 
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}