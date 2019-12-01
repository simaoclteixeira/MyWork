using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class Departamentos
    {
        [Key]
        public int DepartamentoID { get; set; }

        public String Nome { get; set; }
    }
}
