using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gasto>()
                .Property(g => g.Monto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Gasto>()
                .HasOne(g => g.Empleado)
                .WithMany()
                .HasForeignKey(g => g.EmpleadoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
