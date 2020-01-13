﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class PaginacaoDepartamentos
    {
        public IEnumerable<Departamentos> Departamento { get; set; }

        public int PagAtual { get; set; }

        public int TotPaginas { get; set; }

        public int PriPagina { get; set; }

        public int UltPagina { get; set; }
    }
}