using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionariosID { get; set; }
        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o número")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Número inválido")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Insira o email")]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email inválido")]
        public String Email { get; set; }


    }
}
