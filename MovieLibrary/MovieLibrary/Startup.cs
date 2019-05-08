using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
//using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;


[assembly: OwinStartup(typeof(MovieLibrary.Startup))]

namespace MovieLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //    public IConfiguration Configuration { get; }

        //    // This method gets called by the runtime. Use this method to add services to the 
        //    //container.
        //    public void ConfigureServices(IServiceCollection services)
        //    {
        //        services.AddDbContext<MoviesContext>(opt =>
        //            opt.UseInMemoryDatabase("TodoList"));
        //        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //    }

        //    // This method gets called by the runtime. Use this method to configure the HTTP 
        //    //request pipeline.
        //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //    {
        //        if (env.IsDevelopment())
        //        {
        //            app.UseDeveloperExceptionPage();
        //        }
        //        else
        //        {
        //            // The default HSTS value is 30 days. You may want to change this for 
        //            // production scenarios, see https://aka.ms/aspnetcore-hsts.
        //            app.UseHsts();
        //        }

        //        app.UseHttpsRedirection();
        //        app.UseMvc();
        //    }
        //}
    }
}

