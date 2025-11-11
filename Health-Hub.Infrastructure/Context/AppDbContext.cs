using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Health_Hub.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.EmailCorporativo).IsUnique();
                b.Property(u => u.EmailCorporativo).IsRequired();
            });

            modelBuilder.Entity<Questionario>(b =>
            {
                b.HasKey(m => m.Id);
                b.HasOne(m => m.Usuario).WithMany(u => u.Questionarios).HasForeignKey(m => m.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Relatorio>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasOne(r => r.Usuario).WithMany(u => u.Relatorios).HasForeignKey(r => r.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
