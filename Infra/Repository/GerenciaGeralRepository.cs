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
    public class GerenciaGeralRepository : Repository<GerenciaGeral>, IGerenciaGeralRepository

    {

        public GerenciaGeralRepository(DataContext context) : base(context)

        {

        }

    }


}

