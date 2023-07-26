﻿using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class GerenciaRepository : Repository<Gerencia>, IGerenciaRepository

    {

        public GerenciaRepository(DataContext context) : base(context)

        {

        }

    }


}

