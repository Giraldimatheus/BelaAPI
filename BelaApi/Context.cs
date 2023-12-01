using BelaApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace BelaApi
{
    public class Context : DbContext
    {
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ContatoDoCliente> ContatoDoClientes { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string connectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=BelaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
            catch 
            {
                throw new Exception("Não foi possível criar conexão com banco de dados.");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClienteModel>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<ContatoDoCliente>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
