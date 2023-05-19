using System.Globalization;
using IbanNet.DependencyInjection.ServiceProvider;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Presentation.Filters;
using Presentation.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation;

public static class DependencyInjection
{
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIbanNet();
        AddSwagger(services, configuration);
        AddLocalizations(services);
    }

    private static void AddSwagger(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString("2022-01-01")
            })
        );
        services.AddOptions<SwaggerGenOptions>().Configure(swagger =>
        {
            var swaggerOptions = new SwaggerOptions();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            foreach (var document in SwaggerOptions.SwaggerDocs)
                swagger.SwaggerDoc(document, new OpenApiInfo
                {
                    Title = swaggerOptions.Title,
                    Version = "v1",
                    Description = swaggerOptions.Description,
                    Contact = new OpenApiContact
                    {
                        Name = swaggerOptions.Organization,
                        Email = swaggerOptions.Email
                    }
                });


            swagger.OperationFilter<SwaggerOperation>();
        });
    }

    private static void AddLocalizations(this IServiceCollection services)
    {
        services.AddLocalization().Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("fa"),
                new CultureInfo("en")
            };
            options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.ApplyCurrentCultureToResponseHeaders = true;
        });
    }
}