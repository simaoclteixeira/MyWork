using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class Servico{

        [Key]
        public int ServicoID { get; set; }
       
        [Required]
        public String Nome { get; set; }

    }
}
