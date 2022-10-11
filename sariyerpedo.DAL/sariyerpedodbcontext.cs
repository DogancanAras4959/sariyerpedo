using Microsoft.EntityFrameworkCore;
using sariyerpedo.DAL.Mapping;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL
{
    public class sariyerpedodbcontext : DbContext
    {
        public sariyerpedodbcontext(DbContextOptions<sariyerpedodbcontext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<Post> news { get; set; }
        public virtual DbSet<Roles> roles { get; set; }
        public virtual DbSet<Treatments> treatments { get; set; }
        public virtual DbSet<SiteSettings> siteSettings { get; set; }
        public virtual DbSet<Language> languages { get; set; }
        public virtual DbSet<Sliders> sliders { get; set; }
        public virtual DbSet<ImageFile> imageFile { get; set; }
        public virtual DbSet<LangCountry> langCountry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new SiteSettingMapping());
            modelBuilder.ApplyConfiguration(new TreatmentMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SliderMapping());
            modelBuilder.ApplyConfiguration(new ImageFileMapping());
            modelBuilder.ApplyConfiguration(new LangCountryMapping());
        }
    }
}
