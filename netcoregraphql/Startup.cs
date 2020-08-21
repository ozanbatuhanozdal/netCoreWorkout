using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using netcoregraphql.Data.Interfaces;
using netcoregraphql.Data.Repository;
using netcoregraphql.Data.Types;

namespace netcoregraphql
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
             services.AddScoped<EasyStoreQuery>();   
             services.AddTransient<ICategoryRepository, CategoryRepository>();
             services.AddTransient<IProductRepository, ProductRepository>();   
             services.AddScoped<IDocumentExecuter, DocumentExecuter>();
             services.AddTransient<CategoryType>();
             services.AddTransient<ProductType>();
             var sp = services.BuildServiceProvider();
             services.AddScoped<ISchema>(_ => new EasyStoreSchema(type => (GraphType) sp.GetService(type)) {Query = sp.GetService<EasyStoreQuery>()});            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
