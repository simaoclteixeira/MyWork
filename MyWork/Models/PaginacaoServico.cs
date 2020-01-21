using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class PaginacaoServico
    {
        public IEnumerable<Servico> Servico { get; set; }

        public int PagAtual { get; set; }

        public int TotPaginas { get; set; }

        public int PriPagina { get; set; }

        public int UltPagina { get; set; }

        public string StringProcurar { get; set; }
        public string Procurar { get; set; }
        public string Sort { get; set; }
    }
}
