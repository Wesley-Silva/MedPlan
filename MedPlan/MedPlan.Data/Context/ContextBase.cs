using MedPlan.Domain.Interfaces.Configuracao;
using MedPlan.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MedPlan.Data.Context
{
    public class ContextBase : IdentityDbContext<Usuario>
    {
        public ContextBase()
        {
        }

        public ContextBase(DbContextOptions<ContextBase> options)
            : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(t => t.Id);

            // Aqui estou obtendo todas as classes de configuração das entidades.
            // através da interface IEntityConfig, criada única e exclusivamente para isto.
            // Sendo assim, não precisamos lembrar de, ao criar a configuração de alguma entidade, colocar mais uma linha de código neste trecho.
            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();


            // app excluir em cascanding colocar msg p/ perguntar
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }        
    }
}
