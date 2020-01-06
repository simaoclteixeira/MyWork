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
       
        [Required(ErrorMessage ="Insira o nome")]
        public String Nome { get; set; }
        [StringLength(200, MinimumLength =4)]
        public String Descricao { get; set; }
        [Required(ErrorMessage ="Insira a data")]
        public DateTime Data { get; set; }

    }
}
