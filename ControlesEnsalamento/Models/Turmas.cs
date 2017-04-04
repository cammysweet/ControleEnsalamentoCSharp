using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Turma
    {
        [Display(Name = "Identificação turma:")]
        public int idTurma { get; set; }

        [Display(Name = "Quantidades alunos:")]
        public int quantidadeAlunos { get; set; }

        [Display(Name = "Identificação Curso:")]
        public Curso mCurso { get; set; }


        public Turma()
        {

        }
    }
}