using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UpcomingMovies.Domain.Interfaces;
using UpcomingMovies.Application;
using UpcomingMovies.Infrastructure.Repositories;
using UpcomingMovies.Infrastructure.TMDbApi;

namespace UpcomingMovies.Api
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
            services.AddRouting(options => options.LowercaseUrls = true);
            ConfigureDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            const string tmdbApiPath = "https://api.themoviedb.org/3";
            const string tmdbApiKey = "1f54bd990f1cdfb230adb312546d765d";

            services.AddSingleton(new TMDbApiConfiguration(tmdbApiPath, tmdbApiKey));
            services.AddTransient<ITMDbService, TMDbService>();
            services.AddScoped<ITMDbRepository, TMDbRepository>();
        }
    }
}
