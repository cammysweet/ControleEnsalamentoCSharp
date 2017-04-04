using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class TurmaDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Turma turma { get; set; }

        public List<Turma> lista { get; set; }
    }
}