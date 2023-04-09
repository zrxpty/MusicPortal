using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.DAL;
using MusicPortal.DAL.Interface;
using MusicPortal.DAL.Models;
using MusicPortal.DAL.Repositories;
using MusicPortal.WEB.AutoMapperProfiles;

using System.Diagnostics;

namespace MusicPortal.WEB
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
            services.AddControllersWithViews();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            Debug.WriteLine(connection);

            /*services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("Connection")));*/

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connection));

            services.AddDefaultIdentity<Author> (options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }
            )
            .AddEntityFrameworkStores<AppDbContext>();

           

            services.AddAutoMapper(typeof(MusicProfile));
            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(MyMusicService));

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IMusicService, MusicServices>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IMyMusicInterface, MyMusicService>();

            services.AddRazorPages();
            services.AddControllersWithViews();
            
            
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
            app.UseAuthentication();
            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
           
            
        }
    }
}
