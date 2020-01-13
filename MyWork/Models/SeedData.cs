using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWork.Models
{
    public class SeedData
    {
        public static void Populate(GestaoServicoContext db)
        {
            PopulateFuncionario(db);
            PopulateServico(db);
            PopulateDepartamento(db);
        }
        public static void PopulateFuncionario(GestaoServicoContext db)
        {
            if (db.Funcionario.Any())
            {
                return;
            }
            db.Funcionario.AddRange(
                new Funcionario { Nome = "José", Numero = "912634912", Email = "José@gmail.com" },
                new Funcionario { Nome = "André", Numero = "919472975", Email = "André@gmail.com" },
                new Funcionario { Nome = "Ana", Numero = "918255928", Email = "Ana@gmail.com" }, 
                new Funcionario { Nome = "Joana", Numero = "912294582", Email = "Joana@gmail.com" }



                );
            db.SaveChanges();


        }

        public static void PopulateServico(GestaoServicoContext db)
        {
            if (db.Servico.Any())
            {
                return;
            }
            db.Servico.AddRange(
                new Servico { Nome = "Stock Bar", Descricao = "Reposição de stock nos 3 bares."},
                new Servico { Nome = "Reunião Departamentos", Descricao = "Reunião semestral de todos os departamentos." },
                new Servico { Nome = "Palestra", Descricao = "Palestra sobre métodos eficazes de estudo." }

                );
            db.SaveChanges();


        }

        public static void PopulateDepartamento(GestaoServicoContext db)
        {
            if (db.Departamentos.Any())
            {
                return;
            }
            db.Departamentos.AddRange(
                new Departamentos { Nome = "Gestão" },
                new Departamentos { Nome = "Informática" },
                new Departamentos { Nome = "Contabilidade" },
                new Departamentos { Nome = "Marketing" },
                new Departamentos { Nome = "Gestão de recursos humanos" },
                new Departamentos { Nome = "Bar" }



                );
            db.SaveChanges();


        }

    }
}



    

