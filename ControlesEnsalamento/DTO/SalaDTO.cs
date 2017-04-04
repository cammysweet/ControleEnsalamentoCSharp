using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class SalaDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Salas sala { get; set; }

        public List<Salas> lista { get; set; }
    }
}