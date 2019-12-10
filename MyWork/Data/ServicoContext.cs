using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWork.Models;

namespace MyWork.Data
{
    public class ServicoContext : DbContext
    {
        public ServicoContext (DbContextOptions<ServicoContext> options)
            : base(options)
        {
        }

        public DbSet<MyWork.Models.Servico> Servico { get; set; }
    }
}
