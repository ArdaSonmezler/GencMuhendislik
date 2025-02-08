using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationType> ApplicationTypes {get;set;}
        public DbSet<Blog> Blogs {get;set;}
        public DbSet<Career> Careers {get;set;}
        public DbSet<Contact> Contacts {get;set;}
        public DbSet<Image> Images {get;set;}
        public DbSet<ImageCategory> ImageCategories {get;set;}
        public DbSet<Multilanguage> Multilanguages {get;set;}
        public DbSet<Projects> Projects {get;set;}
        public DbSet<ProjectStatus> ProjectStatuses {get;set;}
        public DbSet<Slider> Sliders {get;set;}
        public DbSet<Users> Users {get;set;}
        public DbSet<Youtube> Youtubes {get;set;}
    }
}