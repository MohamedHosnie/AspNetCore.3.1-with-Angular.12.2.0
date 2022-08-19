using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using ElectronicsShop.Application.Errors;
using ElectronicsShop.Application;
using ElectronicsShop.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ElectronicsShop.EntityFrameworkCore;
using NSwag;

namespace ElectronicsShop
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ElectronicsShopDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("ElectronicsShopDbConnection"));
            });

            services.AddRepositories();
            services.AddDomainServices();
            services.AddApplicationServices();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerDocument(options =>
            {
                options.Title = "Electronics Shop API";
                options.AddSecurity("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the bearer scheme (\"bearer {token}\")",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Name = "Authorization",
                    Type = OpenApiSecuritySchemeType.ApiKey
                });
            });
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                .Error; 
                
                var message = env.IsDevelopment() ? exception.Message : "Internal Server Error!";

                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new Error()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = message
                }));
            }));

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
