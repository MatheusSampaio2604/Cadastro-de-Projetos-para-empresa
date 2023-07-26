using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository

    {

        public UsuarioRepository(DataContext context) : base(context)

        {

        }

    }


}
