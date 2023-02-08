using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infra.Data.Configurations
{
    public class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.ToTable("Filmes_Auth");
            builder.Property(p => p.Id).IsRequired().HasColumnName("auth_id");
            builder.Property(p => p.Username).IsRequired().HasColumnName("auth_username");
            builder.Property(p => p.Password).IsRequired().HasColumnName("auth_password");
        }
    }
}
