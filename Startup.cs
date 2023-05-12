using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritabanıProje.Models;

namespace VeritabanıProje
{
    public class Startup
    {
        Context c = new Context();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Home/Index/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Stand}/{action=Index}/{id?}");
            });
            HandleExpiredFairs(c);
        }
        private void HandleExpiredFairs(Context dbContext)
        {
            var today = DateTime.Today;
            var expiredFairs = dbContext.fuars.Where(f => f.tarih < today && f.aktif).ToList();
            var sektorler = expiredFairs.Select(y => y.sektor_adı).ToList();
            var sirketler = dbContext.sirkets.Where(x => sektorler.Contains(x.sektor_adı)).ToList();
            var ziyaretciler = dbContext.ziyaretcis.Where(z => expiredFairs.Contains(z.fuar)).ToList();
            var standlar = dbContext.stands.Where(s => expiredFairs.Contains(s.fuar_)).ToList();
            foreach (var fair in expiredFairs)
            {
                fair.aktif = false;
            }
            foreach (var sirket in sirketler)
            {
                c.sirkets.Remove(sirket);
            }
            foreach(var zi in ziyaretciler)
            {
                c.ziyaretcis.Remove(zi);
            }
            foreach( var stand in standlar)
            {
                c.stands.Remove(stand);
            }

            dbContext.SaveChanges();
        }
    }
}
