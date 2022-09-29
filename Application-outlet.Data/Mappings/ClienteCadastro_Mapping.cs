using Application_outlet.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application_outlet.Data.Mappings
{
    public class ClienteCadastro_Mapping : IEntityTypeConfiguration<ClienteCadastro>
    {
        public void Configure(EntityTypeBuilder <ClienteCadastro> entity)
        {
           entity.HasKey(e => e.Nascimento)
                    .HasName("cliente_cadastro_pkey");

                entity.ToTable("cliente_cadastro");

                entity.Property(e => e.Nascimento).HasMaxLength(15);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(20)
                    .HasColumnName("CIdade");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .HasColumnName("CPF");

                entity.Property(e => e.Idade).HasMaxLength(15);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("UF");
        }
    }
}