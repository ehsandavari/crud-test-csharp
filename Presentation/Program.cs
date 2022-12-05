using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using Presentation;
using Presentation.Filters;
using Presentation.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
    options.Filters.Add<ApiActionFilterAttribute>();
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});
builder.Services.AddPresentation(builder.Configuration);

var webApplication = builder.Build();
using (var scope = webApplication.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataBaseContext>().Database.Migrate();
}

var allowedOrigins = new[]
{
    "http://localhost:8000"
};

webApplication.UseCors(b =>
    b.WithOrigins(allowedOrigins).AllowCredentials().AllowAnyMethod().AllowAnyHeader().Build());
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI(options =>
    {
        foreach (var swaggerDoc in SwaggerOptions.SwaggerDocs)
            options.SwaggerEndpoint($"/swagger/{swaggerDoc}/swagger.json", swaggerDoc);
    });
}

webApplication.UseRequestLocalization(webApplication.Services.GetService<IOptions<RequestLocalizationOptions>>()!
    .Value);
webApplication.UseStaticFiles();
webApplication.MapControllers();
webApplication.Run();