using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation.Filters;

public class SwaggerOperation : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Examples = new Dictionary<string, OpenApiExample>
            {
                {
                    "fa", new OpenApiExample
                    {
                        Description = "Persian nationality",
                        Value = new OpenApiString("fa")
                    }
                },
                {
                    "en", new OpenApiExample
                    {
                        Description = "English nationality",
                        Value = new OpenApiString("en")
                    }
                }
            }
        });
    }
}