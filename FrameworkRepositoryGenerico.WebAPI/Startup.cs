using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.RepositoriesModels;
using Microsoft.EntityFrameworkCore;


namespace FrameworkRepositoryGenerico.WebAPI
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyCadastroContext>(options => options.UseMySql(sqlConnection, b => b.MigrationsAssembly("FrameworkRepositoryGenerico.DataBase")));
            services.AddMvc();

            services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryAno, RepositoryAno>();
            services.AddScoped<IRepositoryFabricante, RepositoryFabricante>();
            services.AddScoped<IRepositoryModelo, RepositoryModelo>();
            services.AddScoped<IRepositoryTipoContato, RepositoryTipoContato>();
            services.AddScoped<IRepositoryTipoProduto, RepositoryTipoProduto>();
            services.AddScoped<IRepositoryTipoCliente, RepositoryTipoCliente>();
            services.AddScoped<IRepositoryCategoria, RepositoryCategoria>();
            services.AddScoped<IRepositoryRegra, RepositoryRegra>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
