using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Disciplina
    {
        [Display(Name = "Identificação da disciplina:")]
        public int idDisciplina { get; set; }

        [Display(Name = "Disciplina:")]
        public string descricaoDisciplinas { get; set; }

        public Disciplina() {

        }
    }
}