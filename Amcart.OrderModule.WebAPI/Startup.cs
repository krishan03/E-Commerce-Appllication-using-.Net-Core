using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmCart.Core;
using AmCart.Core.ExceptionManagement;
using AmCart.OrderModule.AppServices;
using AmCart.OrderModule.AppServices.Mapper;
using AmCart.OrderModule.Configuration;
using AmCart.OrderModule.Data.DBContext;
using AmCart.OrderModule.Data.UoW;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Amcart.OrderModule.WebAPI
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
            services.AddCors(o => o.AddPolicy("OrderServicePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            ArrayPool<char> charPool = ArrayPool<char>.Create();
            JsonOutputFormatter jsonOutputFormatter = new JsonOutputFormatter(serializerSettings, charPool);
            services.AddMvc(
                options =>
                {
                    options.OutputFormatters.Clear();
                    options.OutputFormatters.Insert(0, jsonOutputFormatter);
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.RegisterRepositories();
            services.AddScoped<IOrderModuleUnitOfWork, OrderModuleUnitOfWork>();

            services.AddDbContext<OrderModuleDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            AmCart.Core.Logging.ILogger logger = new AmCart.Logging.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddScoped<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddScoped<IExceptionManager, ExceptionManager>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<AmCart.Core.Logging.ILogger, AmCart.Logging.NLog.Logger>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<AmCart.Core.Data.DBSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddScoped<IOrderMongoDBUnitOfWork, OrderMongoDBUnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseCors("OrderServicePolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
