using IO.Swagger.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XchangeCrypt.Backend.ConvergenceService.Filters.Authentication;
using XchangeCrypt.Backend.ConvergenceService.Services;

namespace XchangeCrypt.Backend.ConvergenceService
{
    /// <summary>
    /// Startup of ConvergenceService.
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddHttpsRedirection(options => options.HttpsPort = 443);

            // Azure AD B2C authentication
            services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.Authority = Configuration["Authentication:AzureAD:Authority"];
//                    jwtOptions.Authority =
//                        $"{Configuration["Authentication:AzureAD:AuthorityPrefix"]}/" +
//                        $"{Configuration["Authentication:AzureAD:Tenant"]}/" +
//                        $"{Configuration["Authentication:AzureAD:Policy"]}/" +
//                        $"{Configuration["Authentication:AzureAD:AuthorityPostfix"]}/";
                    jwtOptions.Audience = Configuration["Authentication:AzureAD:ClientId"];
                    jwtOptions.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = AuthenticationFailed
                    };
                });

            // Framework services
            services
                .AddMvc()
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                });

            // API documentation
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "XchangeCrypt REST API Specification",
                        Description = "TradingView REST API Specification for Brokers (ASP.NET Core 2.0)",
                        Contact = new Contact
                        {
                            Name = "Steve",
                            Url = "https://localhost/",
                            Email = ""
                        },
                        License = new License
                        {
                            Name = "Apache License Version 2.0",
                            Url = "https://www.apache.org/licenses/LICENSE-2.0"
                        },
                        TermsOfService = ""
                    });
                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                    // Required for Swagger 2
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[] { }}
                    });
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments(
                        $"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/api/v1");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            // Trading services (Queue)
            services.AddTransient<OrderService>();
            services.AddTransient<UserService>();

            // View services
            services.AddTransient<OrderViewService>();

            // Persistently running queue writer
            services.AddSingleton<TradingQueueWriter>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Enabling dot as a decimal separator symbol
            var cultureInfo = new CultureInfo("en-US")
            {
                NumberFormat = {CurrencySymbol = "€"}
            };
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            // Authentication
            app.UseAuthentication();
            // Fake user for testing purposes only!
            app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
            app
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller}/{action=Index}/{id?}"
                    );
                })
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "XchangeCrypt REST API Specification"
                    );
                    // Or alternatively use the original Swagger contract that's included in the static files
                    c.SwaggerEndpoint(
                        "/swagger-original.json",
                        "TradingView REST API Specification for Brokers Original"
                    );
                });

            // Security
            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                // Error handling
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                // Error handling
                //TODO: Enable production exception handling (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
                // app.UseExceptionHandler("/Home/Error");
            }
        }

        private Task AuthenticationFailed(AuthenticationFailedContext arg)
        {
            // For debugging purposes only!
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            arg.Response.ContentLength = s.Length;
            arg.Response.Body.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
            return Task.FromResult(0);
        }
    }
}