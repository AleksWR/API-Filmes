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
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filmes_Data");
            builder.Property(p => p.Id).IsRequired().HasColumnName("filme_id");
            builder.Property(p => p.Name).IsRequired().HasColumnName("filme_name");
            builder.Property(p => p.MinutesDuration).IsRequired().HasColumnName("filme_minutes_duration");
            builder.Property(p => p.Type).HasColumnName("filme_type");
            builder.Property(p => p.Description).HasColumnName("filme_description");
        }
    }
}
