using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azuretest_2.App;
using azuretest_2.infra;
using azuretest_2.WebApi.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace azuretest_2
{
    public class Startup
    {

        
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            //services.AddSqlRepository();
            services.AddCosmosRepository(Configuration);
          //  services.AddMockRepository();
          services.AddThirdPartyServices(Configuration);
          services.AddApplicationInsightsTelemetry();

            services.AddControllers();
          /*  services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "azuretest_2", Version = "v1" });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
           app.UseMiddleware<ErrorHandling>(env);
               // app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "azuretest_2 v1"));
            
            logger.LogInformation(
                "Configuring for {Environment} environment",
                env.EnvironmentName);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
