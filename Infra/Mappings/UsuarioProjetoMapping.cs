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
    public class UsuarioProjetoMapping : IEntityTypeConfiguration<UsuarioProjeto>
    {
        public void Configure(EntityTypeBuilder<UsuarioProjeto> builder)
        {
            builder.HasKey(x => new { x.Id_Projeto, x.Id_Usuario, x.Id_Funcao });
            builder.HasOne(x => x.Projeto).WithMany(x => x.UsuarioProjetos).HasForeignKey(x => x.Id_Projeto);
            builder.HasOne(x => x.Funcao).WithMany(x => x.UsuarioProjeto).HasForeignKey(x => x.Id_Funcao);
            builder.HasOne(x => x.Usuario).WithMany(x => x.UsuarioProjeto).HasForeignKey(x => x.Id_Usuario);
        }
    }
}
