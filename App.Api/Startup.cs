using App.Data.Context;
using App.Data.Repository;
using App.Data.Repository.Interfaces;
using App.Domain.Models.Seguranca;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;

namespace App.Api
{
    public class Startup
    {
        private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            InitializeContainer();
        }

        private void InitializeContainer()
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<AppDbContext>(Lifestyle.Scoped);

            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
            container.Register<IDocumentoRepository, DocumentoRepository>(Lifestyle.Scoped);
            container.Register<IDocumentoBaixaRepository, DocumentoBaixaRepository>(Lifestyle.Scoped);

            container.RegisterInstance(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            container.Verify();
        }
    }
}
