using ControlesEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlesEnsalamento.DTO
{
    public class ProfessorDTO
    {
        public bool ok { get; set; }

        public string mensagem { get; set; }

        public Professor professor { get; set; }
         
        public List<Professor> lista { get; set; }
    }
}