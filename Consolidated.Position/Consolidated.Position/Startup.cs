using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Consolidated.Position
{
    /// <summary>Classe Startup API.</summary>
    public class Startup
    {
        /// <summary>Interface Configuração</summary>
        public IConfiguration Configuration { get; }
        
        /// <summary>Inicia uma nova instância da classe <see cref="Startup" />.</summary> 
        /// <param name="configuration">Configuração repository</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>Adicionar Serviços no Container</summary>
        /// <param name="services">This method gets called by the runtime. Use this method to add services to the container.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consolidated.Position.API", Version = "v1" });
            });
        }

        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</summary>
        /// <param name="app">Interface applicationbuilder</param>
        /// <param name="env">Interface HostingEnvironment</param>
        /// <param name="loggerFactory">Configuração Logger</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var log = loggerFactory.CreateLogger(GetType());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consolidated Position API");
            });

            log.LogInformation("Swagger habilitado.");

            app.UseCors("AllowAnyCorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
