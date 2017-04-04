using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class Salas
    {
        [Key]
        [Display(Name = "Idenfiticação Sala:")]
        public int idSala { get; set; }

        [Display(Name = "Capacidade:")]
        public int capacidade { get; set; }

        [Display(Name = "Tipo de sala:")]
        public List<TipoDeSala> tipoSala { get; set; }

        public Salas() {

        }
    }
}