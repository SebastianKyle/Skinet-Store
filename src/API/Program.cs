using API.Middleware;
using API.StartupExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Skinet.Core.Domain.Entities.Identity;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

var skinetAppCorsPolicy = "CorsPolicy";

builder.Services.ConfigureSwaggerServices();

builder.Services.AddCors(option => {
    option.AddPolicy(skinetAppCorsPolicy, policy => {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

builder.Services.ConfigureServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// re-execute pipeline with alternate path in case user try to reach an unavailable controller or action method
app.UseStatusCodePagesWithReExecute("/Errors/{0}");

app.UseHttpsRedirection();

app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")
    ), RequestPath = "/content"
});

app.UseCors(skinetAppCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerDocumentation();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreDbContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();