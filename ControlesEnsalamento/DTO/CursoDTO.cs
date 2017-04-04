using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class CursoDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Curso curso { get; set; }

        public List<Curso> lista { get; set; }


    }
}