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
    public class AnexosMapping : IEntityTypeConfiguration<Anexos>
    {
        public void Configure(EntityTypeBuilder<Anexos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Projetos).WithMany(x => x.Anexos).HasForeignKey(x => x.Id_Projeto);
        }
    }
}
