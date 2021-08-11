using Fiba.BL.Interfaces;
using Fiba.DAL;
using Fiba.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fiba.BL
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
						  builder => builder
						  .WithOrigins("http://localhost:4200")
						  .AllowAnyHeader()
						  .AllowAnyMethod());
			});

			services
				.AddControllers(options => { options.ReturnHttpNotAcceptable = true; })
				.AddXmlDataContractSerializerFormatters();

			services.AddDbContext<FibaDbContext>(options =>
			{
				options.UseSqlServer(@"Server=(local);Database=Fiba;Trusted_Connection=True;");
			});

			services.AddScoped<IFibaActors, FibaActors>();
			services.AddScoped<IFibaUnitOfWork, FibaUnitOfWork>();

			services.AddAuthentication();
			//services
			//	.AddAuthentication("Bearer")
			//	.AddJwtBearer("Bearer", options =>
			//	{
			//		options.Authority = "http://localhost:5000";
			//		options.RequireHttpsMetadata = false;
			//		options.TokenValidationParameters = new TokenValidationParameters
			//		{
			//			ValidateAudience = false
			//		};
			//	});

			services.AddAuthorization();
			//services.AddAuthorization(options =>
			//{
			//	options.AddPolicy("ApiScope", policy =>
			//	{
			//		policy.RequireAuthenticatedUser();
			//		policy.RequireClaim("scope", "fiba.api");
			//	});
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler(appBuilder =>
				{
					appBuilder.Run(async context =>
					{
						context.Response.StatusCode = 500;
						await context.Response.WriteAsync("An unexpected fault happened.  Try again later.");
					});
				});
			}

			app.UseRouting();
			app.UseCors(MyAllowSpecificOrigins);
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints
				.MapControllers();
				//.RequireAuthorization("ApiScope");
			});
		}
	}
}
