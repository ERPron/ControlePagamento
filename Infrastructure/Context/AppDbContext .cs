using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Valor).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(p => p.Data).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });

            modelBuilder.Entity<Pagamento>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
