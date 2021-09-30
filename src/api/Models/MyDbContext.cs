using Microsoft.EntityFrameworkCore;

namespace ElBastard0.Api.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("ENTITY");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName(@"VALUE")
                    .HasMaxLength(255);

                entity.HasData(
                    new Entity { Id = 1, Value = "Example Entity 1" },
                    new Entity { Id = 2, Value = "Example Entity 2" }
                );
            });
        }
    }
}
