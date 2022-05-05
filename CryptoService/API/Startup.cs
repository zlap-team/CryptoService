using API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

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
            });

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPIv5", Version = "v1"}); });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins("https://localhost:3000");
                    });
            });
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