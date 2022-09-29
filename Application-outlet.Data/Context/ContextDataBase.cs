using System;
using System.Collections.Generic;
using Application_outlet.Business.Models;
using Application_outlet.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
                optionsBuilder.UseNpgsql("Host=localhost;Database=outletservice;Username=postgres;Password=admin");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDataBase).Assembly);
        }
    }
}
