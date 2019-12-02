using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class Funcionário
    {
        [Key]
        public int IDFuncionarios { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }


    }
}
