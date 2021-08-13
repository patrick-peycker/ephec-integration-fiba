using Fiba.BL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fiba.BL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//CreateHostBuilder(args).Build().Run();

			var host = CreateHostBuilder(args).Build();

			if (args.Length > 0 && args[0].ToLower() == "/seed")
			{
				SeedDatabase(host);
				return;
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			 Host.CreateDefaultBuilder(args)
				  .ConfigureWebHostDefaults(webBuilder =>
				  {
					  webBuilder.UseStartup<Startup>();
				  });

		private static void SeedDatabase(IHost host)
		{
			var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

			using (var scope = scopeFactory.CreateScope())
			{
				var seeder = scope.ServiceProvider.GetService<Seeder>();
				seeder.SeedAsync().Wait();
			}
		}
	}
}
