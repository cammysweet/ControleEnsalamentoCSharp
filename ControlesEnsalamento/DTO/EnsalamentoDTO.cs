using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class EnsalamentoDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Ensalamentos ensalamento { get; set; }

        public List<Ensalamentos> lista { get; set; }
    }
}