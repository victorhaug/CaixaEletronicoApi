using APICaixaEletronico.DAO;
using APICaixaEletronico.DAO.DAO;
using APICaixaEletronico.DAO.Interface;
using APICaixaEletronico.Service.Interface;
using APICaixaEletronico.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace APICaixaEletronico
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()

            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",

                builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                );


            });
            services.AddDbContext<CommonDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Defaultconnection"));
            });


            services.AddTransient<IOperacoesCaixaEletronicoDAO, OperacoesCaixaEletronicoDAO>();
            services.AddTransient<IOperacoesCaixaEletronicoService, OperacoesCaixaEletronicoService>();
            services.AddTransient<ICaixaEletronicoDAO, CaixaEletronicoDAO>();
            services.AddTransient<ICaixaEletronicoService, CaixaEletronicoService>();
            services.AddControllers().AddNewtonsoftJson();

            services.AddControllers();



        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
