using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using traininghub.api.AutoMapper;
using traininghub.core;
using traininghub.dac.ef;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.api
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
            services.AddDbContext<TrainingHubContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TrainingHubContextConnection")));

            services.AddMvc()
                    .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<IMapper>((s) => Mapper.Instance);
            services.AddTransient<IDbDataProvider, TrainingHubContext>();
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IGameOrganizer, GameOrganizer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapperConfig.Configure();

            app.UseMvc();
        }
    }
}
