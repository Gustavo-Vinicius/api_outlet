

using Application_outlet.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Application_outlet.Data.Context
{
    public  class ContextDataBase : DbContext
    {
        public ContextDataBase(DbContextOptions<ContextDataBase> options)
            : base(options){}

        public virtual DbSet<ClienteCadastro> ClienteCadastros { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=outletservice;UserId=postgres;Password=12345@rad");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDataBase).Assembly);
        }
    }
}
