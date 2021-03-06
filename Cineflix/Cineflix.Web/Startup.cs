using Cineflix.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Repository;
using Cineflix.Domain.Service;
using Cineflix.Infra.Service;
using Cineflix.Domain.Mapping;
using Cineflix.Domain.Cryptography;

namespace Cineflix.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<ISessaoService, SessaoService>();
            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IIngressoService, IngressoService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<CriptografiaService>();
            services.AddScoped<EmailService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<CineflixContext>(opts => 
                opts.UseMySQL(Configuration.GetConnectionString("MySqlDb"))
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cineflix.Web", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cineflix.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
