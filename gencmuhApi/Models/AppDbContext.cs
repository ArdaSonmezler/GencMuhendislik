using Microsoft.EntityFrameworkCore;

namespace gencmuhApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Multilanguage> Multilanguage { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
        public DbSet<Youtube> Youtubes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Career> Careers { get; set; }
    }
}