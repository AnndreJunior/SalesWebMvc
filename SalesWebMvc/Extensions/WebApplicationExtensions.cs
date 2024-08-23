using SalesWebMvc.Data;

namespace SalesWebMvc.Extensions;

public static class WebApplicationExtensions
{
    public static async Task UseSeedingService(this WebApplication app)
    {
        using var scode = app.Services.CreateScope();
        var seeder = scode.ServiceProvider.GetRequiredService<SeedingService>();
        await seeder.Seed();
    }
}
