using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALLibrary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(); // add access to outer aps (e.g. APIs)
            services.AddSingleton<IBookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:5000").AllowAnyHeader()); // podpięcie pod witrynę, API dostępne globalnie, w innym wypadku może kontrolować dostęp konretnych akcji/kontrolerów, więcej: https://docs.microsoft.com/pl-pl/aspnet/core/security/cors?view=aspnetcore-2.1

            app.UseMvc();
        }
    }
}
