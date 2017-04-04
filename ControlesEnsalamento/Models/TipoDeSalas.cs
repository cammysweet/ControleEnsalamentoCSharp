using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.Models
{
    public class TipoDeSala
    {
        [Key]
        [Display(Name = "Identificação tipos:")]
        public int idTipoSala { get; set; }

        [Display(Name = "Tipo de sala:")]
        public string nomeTipo { get; set; }

        public TipoDeSala()
        {

        }
    }
}