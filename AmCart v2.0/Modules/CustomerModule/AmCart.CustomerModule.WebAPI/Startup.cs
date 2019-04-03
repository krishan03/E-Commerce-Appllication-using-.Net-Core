using AmCart.Core.Data;
using AmCart.Core.ExceptionManagement;
using AmCart.CustomerModule.AppService;
using AmCart.CustomerModule.AppService.Mapper;
using AmCart.CustomerModule.Data.DBContext;
using AmCart.CustomerModule.Data.UoW;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmCart.CustomerModule.WebAPI
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
			services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.Configure<DBSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "http://localhost:5000/resources";
                });

            services.AddDbContext<CustomerModuleDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Core.Logging.ILogger logger = new Logging.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddScoped<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddScoped<IExceptionManager, ExceptionManager>();
            services.AddScoped<INewCustomerAppService, NewCustomerAppService>();
            services.AddScoped<Core.Logging.ILogger, Logging.NLog.Logger>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICustomerModuleUnitOfWork, CustomerModuleUnitOfWork>();
            services.AddScoped<INewCustomerUnitOfWork, NewCustomerUnitOfWork>();
            services.Configure<Core.Data.DBSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddScoped<IExceptionManager, ExceptionManager>();
            services.AddMvc();
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

            app.UseCors("AllRequests");
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
