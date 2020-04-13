using System;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.Context;
using Microsoft.EntityFrameworkCore;

namespace APICaixaEletronico.DAO
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options) { }

        public DbSet<ContaContext> Contas { get; set; }

        public DbSet<CaixaEletronicoContext> Caixas { get; set; }

        public DbSet<ClienteContext> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaContext>(entity =>
            {
                entity.HasKey(e => new { e.IdConta });
            });

            modelBuilder.Entity<ClienteContext>(entity =>
            {
                entity.HasKey(e => new { e.CpfCli });
            });

            modelBuilder.Entity<CaixaEletronicoContext>(entity =>
            {
                entity.HasKey(e => new { e.Id_Terminal });
            });
        }
    }
}
