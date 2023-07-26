using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id_Financiamento).HasColumnName("Id_Financiamento");
            builder.Property(x => x.Id_Tema).HasColumnName("Id_Tema");
            builder.Property(x => x.Id_Objetivo).HasColumnName("Id_Objetivo");

        }
    }
}
