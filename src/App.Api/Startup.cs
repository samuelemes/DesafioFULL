using App.Api.Extensions;
using App.Core.Notificador;
using App.Data.Context;
using App.Data.Repository;
using App.Data.Repository.Interfaces;
using App.Service.Services;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials());
            });

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

            services.AddMvc(setupAction => {
                setupAction.EnableEndpointRouting = false;
                }).AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
            app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Documentos}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=GetTituloVencidos}/{id?}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=GetFaturas}/{id?}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=Create}/{id?}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=Create}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=Post}/{id?}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=Post}");
                endpoints.MapControllerRoute("Titulos", "{controller=Titulos}/{action=CreateDocument}/{id?}");

            });
        }
    }
}
