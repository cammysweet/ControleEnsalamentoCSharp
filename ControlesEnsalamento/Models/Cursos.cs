using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Curso
    {
        [Display(Name = "Identificação Curso:")]
        public int idCurso { get; set; }

        [Display(Name = "Descrição Curso:")]
        public string nomeCurso { get; set; }

        public List<Turma> mTurma { get; set; }

        public Curso()
        {

        }
    }
}