using Microsoft.EntityFrameworkCore;
using SithecModels.Interface;
using SithecModels.Models;

namespace SithecData.Data
{
    public class HumanoContext : DbContext
    {
        public HumanoContext(DbContextOptions<HumanoContext> options) : base(options) { }

        public DbSet<Humano> Humanos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Humano>().ToTable("Humanos").Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
