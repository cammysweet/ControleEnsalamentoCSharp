using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class TipoDeSalaDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public TipoDeSala tipoDeSala { get; set; }

        public List<TipoDeSala> lista { get; set; }
    }
}