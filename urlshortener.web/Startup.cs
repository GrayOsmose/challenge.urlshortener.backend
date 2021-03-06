﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using urlshortener.domain.model;
using urlshortener.domain.data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using urlshortener.web.Middleware;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using urlshortener.web.Data;

namespace urlshortener.web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()
                                                                            .AllowCredentials()));

            // Add framework services.
            services.AddMvc();

            // Add application services.
            services.AddTransient<IUrlManager, UrlManagerMongo>((serviceProvider) => { return new UrlManagerMongo(Configuration.GetConnectionString("urlshortener_mongo")); });
            services.AddTransient<Data.IKeyManager, KeyManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // allow request from anyone
            app.UseCors("AllowAll");

            // use identity cookie middleware to track connection
            app.CookieIdentityMiddleware();

            app.UseMvc();
        }
    }
}
