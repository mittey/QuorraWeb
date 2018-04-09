using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuorraWeb.Data;
using QuorraWeb.Models;
using QuorraWeb.Models.Configs;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace QuorraWeb
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = false;

                    config.Password.RequireDigit           = false;
                    config.Password.RequireLowercase       = false;
                    config.Password.RequireUppercase       = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequiredLength         = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Bot configuration
            services.Configure<BotConfiguration>(Configuration);
            //LUIS configuration
            services.Configure<LuisConfiguration>(Configuration);

            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DiHandlerModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Add support of the node_modules folder
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
        }
    }
}
