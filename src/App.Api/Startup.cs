using App.Api.Extensions;
using App.Core.Notificador;
using App.Data.Context;
using App.Data.Repository;
using App.Data.Repository.Interfaces;
using App.Service.Services;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>();
            services.AddTransient<INotificador, Notificador>();

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IDocumentoRepository, DocumentoRepository>();
            services.AddTransient<IDocumentoBaixaRepository, DocumentoBaixaRepository>();

            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IDocumentoService, DocumentoService>();
            services.AddTransient<IDocumentoBaixaService, DocumentoBaixaService>();

            services.AddSingleton(AutoMapperConfig.GetMapperConfiguration().CreateMapper());

            services.AddMvc();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
