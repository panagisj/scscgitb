using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XchangeCrypt.Backend.TradingBackend.Dispatch;
using XchangeCrypt.Backend.TradingBackend.Repositories;
using XchangeCrypt.Backend.TradingBackend.Services;

namespace XchangeCrypt.Backend.TradingBackend
{
    /// <summary>
    /// Startup of TradingBackend.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Persistently running queue message handler
            services.AddSingleton<IHostedService, DispatchReceiver>();

            // Meta-faculties
            services.AddSingleton<MonitorService>();

            // Custom services
            services.AddTransient<TradingOrderDispatch>();
            services.AddTransient<LimitOrderService>();
            services.AddTransient<MarketOrderService>();
            services.AddTransient<StopOrderService>();

            // Custom repositories
            services.AddTransient<AccountRepository>();
            services.AddTransient<ActivityHistoryRepository>();
            services.AddTransient<TradingRepository>();

            // Custom singleton services
            services.AddTransient<DataAccess>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseMvc()
                // index.html for redirect
                .UseDefaultFiles()
                .UseStaticFiles();
        }
    }
}
