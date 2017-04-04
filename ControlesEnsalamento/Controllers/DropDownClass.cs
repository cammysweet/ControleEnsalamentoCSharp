using ControlesEnsalamento.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControlesEnsalamento.Controllers
{
    public static class DropDownClass
    {
        static string WSPathCurso= WebConfigurationManager.AppSettings["WSPath"] + "/Curso";
        static WebClient wc = new WebClient(); 

        public static List<SelectListItem> ListaDropDownCurso()
        {
            string lista = wc.DownloadString(WSPathCurso + "/Pesquisar");

            List<SelectListItem> listaDropDown = new List<SelectListItem>();
            if (!lista.Contains("Vazia"))
            {
                CursoDTO pDTO = JsonConvert.DeserializeObject<CursoDTO>(lista);

                foreach (var item in pDTO.lista)
                {
                    listaDropDown.Add(new SelectListItem {
                        Text = item.nomeCurso,
                        Value = item.idCurso.ToString()
                    });
                }

            }
            return listaDropDown;
        }
    }
}