using System.Reflection;
using API.Middleware;
using Application.Contracts.ExternalAPI;
using Application.Contracts.Repositories.Common;
using Application.Contracts.Repositories.Specific;
using Application.Core;
using Domain.Entities;
using Infrastructure.ExternalAPI.CoinAPI;
using Infrastructure.ExternalAPI.CoinGeckoAPI;
using Infrastructure.ExternalAPI.NewsAPI;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories.Common;
using Persistence.Repositories.Specific;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CryptoDbContext>(options =>
            {
                options.UseNpgsql(_config.GetConnectionString("CryptoDbDefault")!)
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .EnableSensitiveDataLogging();
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });

            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CryptoDbContext>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPIv5", Version = "v1"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowCredentials();
                        policy.WithOrigins("http://localhost:3000");
                    });
            });

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddMediatR(typeof(Result<>).Assembly);
            services.AddSingleton<ICoinApiClient>(new CoinApiClient());
            services.AddSingleton<INewsApiClient>(new NewsApiClient());
            services.AddSingleton<ICoinGeckoApiClient>(new CoinGeckoApiClient());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostReplyRepository, PostReplyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}