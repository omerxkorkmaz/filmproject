using FilmProject.WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProject.WEBAPI.EntityFramework
{
    public class FilmDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
            
        }
        public DbSet<Films> Films { get; set; }

        public DbSet<FilmNoteAndPoint> FilmsNoteAndPoint { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json")
        //       .Build();

        //    var connectionString = _configuration.GetConnectionString("SqlServer");

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Films>();

        //}
    }
}
