using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x =>
            {
                x.WithDictionaryHandle();
            });

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
