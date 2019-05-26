﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AikaEmu.WebServer
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "member",
                    template: "member/{action}.asp",
                    defaults: new {controller = "Member"});

                routes.MapRoute(
                    name: "servers",
                    template: "servers/{action}.asp",
                    defaults: new {controller = "Servers"});

                routes.MapRoute(
                    name: "news",
                    template: "news/{action}.aspx",
                    defaults: new {controller = "News"});

                routes.MapRoute(
                    name: "default",
                    template: "{action}.html",
                    defaults: new {controller = "Patch", action = "Patch"});
            });
        }
    }
}