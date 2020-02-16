using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using auth.identity;
using bookstore.site.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.IO;
using System.Reflection;

namespace bookstore.site
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
            services.AddEntityContext();
            services.AddRepositoryService();
            services.AddOperationService();

            services.AddAuth();

            //services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApplicationPartManager(ConfigureApplicationParts);
            //services.AddControllersWithViews();
            //services.AddRazorPages();
        }

        private void ConfigureApplicationParts(ApplicationPartManager apm)
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var assemblyFiles = Directory.GetFiles(rootPath, "*.dll");
            foreach (var assemblyFile in assemblyFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFile(assemblyFile);
                    if (assemblyFile.EndsWith(this.GetType().Namespace + ".Views.dll") || assemblyFile.EndsWith(this.GetType().Namespace + ".dll"))
                        continue;
                    else if (assemblyFile.EndsWith(".Views.dll"))
                        apm.ApplicationParts.Add(new CompiledRazorAssemblyPart(assembly));
                    //else
                    //    apm.ApplicationParts.Add(new AssemblyPart(assembly));
                }
                catch (Exception e) 
                {
                    var a = 56;
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
