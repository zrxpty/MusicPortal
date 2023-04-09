using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MyMusic> MyMusics { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole("Admin"),
                         new IdentityRole("User"));
        
            
        }
    }
    
}
