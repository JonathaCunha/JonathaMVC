using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (entityType.ClrType == null)
            //        continue;
            //    entityType.Relational().TableName = entityType.ClrType.Name;
            //}

            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("MVCTeste");

            modelBuilder.Entity<Empresa>(m =>
               {
                   m.ToTable("Empresa");

                   m.HasKey(c => c.Id).HasName("Id");
                   m.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                   m.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(255).IsRequired();
                   m.Property(c => c.Site).HasColumnName("Site").HasMaxLength(255).IsRequired(false);
                   m.Property(c => c.QuantidadeFuncionarios).HasColumnName("QuantidadeFuncionarios").IsRequired();
               });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresa { get; set; }
    }
}
