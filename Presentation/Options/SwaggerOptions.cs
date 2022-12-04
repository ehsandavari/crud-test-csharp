namespace Presentation.Options;

public class SwaggerOptions
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Organization { get; set; }
    public string Email { get; set; }

    public static IEnumerable<string> SwaggerDocs => new[]
    {
        "public",
        "admin",
        "client"
    };
}