using Application_outlet.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application_outlet.Data.Mappings
{
    public class UserLogin_Mapping : IEntityTypeConfiguration<UserLogin>
    {
         public void Configure(EntityTypeBuilder <UserLogin> entity)
        {
              // entity.ToTable("user_login");
                entity.ToTable("UserLogin");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
        }
    }
}