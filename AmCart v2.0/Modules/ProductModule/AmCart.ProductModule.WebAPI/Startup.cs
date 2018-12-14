using AmCart.Core.Data;
using AmCart.Core.ExceptionManagement;
using AmCart.ProductModule.AppServices;
using AmCart.ProductModule.AppServices.Mapper;
using AmCart.ProductModule.Configuration;
using AmCart.ProductModule.Data.DBContext;
using AmCart.ProductModule.Data.UoW;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmCart.ProductModule.WebAPI
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        private IExceptionManager exceptionManager;
        public Startup(IHostingEnvironment configuration)
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
       

            });
            var builder = new ConfigurationBuilder()
                .SetBasePath(configuration.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configuration.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.RegisterRepositories();
            services.AddScoped<IProductModuleUnitOfWork, ProductModuleUnitOfWork>();
            services.AddDbContext<ProductModuleDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Core.Logging.ILogger logger = new Logging.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddScoped<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddScoped<IExceptionManager, ExceptionManager>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<Core.Logging.ILogger, Logging.NLog.Logger>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<DBSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
