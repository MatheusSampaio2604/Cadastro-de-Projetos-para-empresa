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
    public class GerenciaMapping : IEntityTypeConfiguration<Gerencia>
    {
        public void Configure(EntityTypeBuilder<Gerencia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.GerenciaGeral).WithMany(x => x.Gerencias).HasForeignKey(x => x.Id_GG);
        }
    }
}
