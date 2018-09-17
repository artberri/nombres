using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Names.API
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
            services.AddCors();
            services.AddResponseCaching();
            services.AddResponseCompression();
            services.AddMvc().AddJsonOptions(opt =>
            {
                var resolver  = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;  // <<!-- this removes the camelcasing
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddProjectDependencies();
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

            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
                {
                    Public = true,
                };
                context.Response.Headers[HeaderNames.LastModified] = new string[] { (new DateTime(2018, 5, 17)).ToString() };

                await next();
            });

            app.UseResponseCompression();

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:61061"));

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".wasm"] = "application/wasm";
            provider.Mappings[".dll"] = "application/octet-stream";

            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
#endif

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
