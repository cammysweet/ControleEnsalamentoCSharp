using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Ensalamentos
    {
        [Display(Name = "Identificação:")]
        public int idEnsalamento { get; set; }

        [Display(Name = "Sala:")]
        public int idSala { get; set; }

        [Display(Name = "Professor:")]
        public List<Professor> matriculaProfessor { get; set; }

        [Display(Name = "Disciplina:")]
        public List<Disciplina> idDisciplina { get; set; }

        [Display(Name = "Identificação Turma:")]
        public List<Turma> idTuma { get; set; }

        [Display(Name = "Dia da Semana:")]
        public string diaDaSemana { get; set; }

        [Display(Name = "Disponibilidade Sala:")]
        public string disponibilidadeSala { get; set; }

        [Display(Name = "Turno:")]
        public string turno { get; set; }

        [Display(Name = "Data de inicio:")]
        [DataType(DataType.Date, ErrorMessage = "Data em Formato Inválido")]
        public DateTime dataInicio { get; set; }

        [Display(Name = "Data de fim:")]
        [DataType(DataType.Date, ErrorMessage = "Data em Formato Inválido")]
        public DateTime dataFim { get; set; }

        public Ensalamentos() {

        }
    }
}