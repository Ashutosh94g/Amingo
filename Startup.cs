using System;
using System.Net;
using System.Text;
using Amingo.Data;
using Amingo.Helpers;
using Amingo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace Amingo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<UserDataContext>(option => option.UseMySQL(
				Configuration.GetConnectionString("Default")
			));
			// services.AddScoped<IUserData, MockUserData>();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddCors();

			services.AddScoped<IAuthRepo, AuthRepo>();
			services.AddScoped<IAmingoRepo, AmingoRepo>();

			services.AddControllers().AddNewtonsoftJson(s =>
			{
				s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});
			// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
			services
					.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.IncludeErrorDetails = true; // Default: true

						options.TokenValidationParameters = new TokenValidationParameters
						{
							// Let "sub" assign to User.Identity.Name
							NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
							// Let "roles" assign to Roles for [Authorized] attributes
							RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

							// Validate the Issuer
							ValidateIssuer = false,
							ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),

							ValidateAudience = false,
							//ValidAudience = "JwtAuthDemo", // TODO

							ValidateLifetime = true,

							ValidateIssuerSigningKey = true,

							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value))
						};
					});
			// services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			// 					.AddJwtBearer(options =>
			// 					{
			// 						options.TokenValidationParameters = new TokenValidationParameters
			// 						{
			// 							ValidateIssuerSigningKey = true,
			// 							IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
			// 							ValidateIssuer = false,
			// 							ValidateAudience = false
			// 						};
			// 					});
			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/build";
			});
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
				app.UseExceptionHandler(builder =>
				{
					builder.Run(async context =>
					{
						context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						var error = context.Features.Get<IExceptionHandlerFeature>();
						if (error == null)
						{
							context.Response.AppApplicationError(error.Error.Message);
							await context.Response.WriteAsync(error.Error.Message);
						}
					});
				});
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseAuthentication();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
			});
		}
	}
}
