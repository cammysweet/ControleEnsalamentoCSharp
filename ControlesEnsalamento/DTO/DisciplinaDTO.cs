using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class DisciplinaDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Disciplina disciplinas { get; set; }

        public List<Disciplina> lista { get; set; }
    }
}