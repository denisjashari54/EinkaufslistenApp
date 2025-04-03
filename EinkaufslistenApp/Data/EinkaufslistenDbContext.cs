using Microsoft.EntityFrameworkCore;
using EinkaufslistenApp.Models;

namespace EinkaufslistenApp.Data
{
    public class EinkaufslistenDbContext : DbContext
    {
        public EinkaufslistenDbContext(DbContextOptions<EinkaufslistenDbContext> options)
            : base(options) { }

        public DbSet<EinkaufsItem> EinkaufsItems { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DENISLAPTOP\\SQLEXPRESS;Database=EinkaufslistenDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EinkaufsItem>()
                .HasOne(e => e.Benutzer)
                .WithMany(b => b.EinkaufsItems)
                .HasForeignKey(e => e.BenutzerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Benutzer>().HasData(
                new Benutzer { Id = 1, Benutzername = "Alice", Passwort = "1234" },
                new Benutzer { Id = 2, Benutzername = "Bob", Passwort = "5678" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
