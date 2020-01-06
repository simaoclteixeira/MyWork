using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWork.Models;

namespace MyWork.Models
{
    public class GestaoServicoContext : DbContext
    {
        public GestaoServicoContext (DbContextOptions<GestaoServicoContext> options)
            : base(options)
        {
        }

        public DbSet<MyWork.Models.Departamentos> Departamentos { get; set; }

        public DbSet<MyWork.Models.Funcionario> Funcionario { get; set; }

        public DbSet<MyWork.Models.Servico> Servico { get; set; }
    }
}
