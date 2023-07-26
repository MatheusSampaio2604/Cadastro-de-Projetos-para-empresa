using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Anexos> Anexos { get; set; }
        public DbSet<Financiamento> Financiamento { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Gerencia> Gerencia { get; set; }
        public DbSet<GerenciaGeral> GerenciaGeral { get; set; }
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioProjeto> UsuarioProjeto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(k => k.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly, x => x.Namespace == "Infra.Mappings");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLazyLoadingProxies();
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
