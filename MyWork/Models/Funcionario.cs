﻿using System;
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
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Numero { get; set; }
    }
}
