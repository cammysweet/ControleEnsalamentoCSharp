using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Professor
    {
        [Display(Name = "Matricular Professor:")]
        public int matricula { get; set; }

        [Display(Name = "Nome professor:")]
        public string nomeProfessor { get; set; }

        [Display(Name = "Status:")]
        public String status { get; set; }

        [Display(Name = "Disciplina:")]
        public List<Disciplina> disciplina { get; set; }


        public Professor()
        {

        }
    }
}