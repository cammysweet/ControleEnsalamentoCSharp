using ControlesEnsalamento.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControlesEnsalamento.Controllers
{
    public class TipoSalasController : Controller
    {
        // GET: TipoSalas
        public ActionResult Index() {
            return View();
        }

        static List<TipoDeSala> listaTipoSalas = new List<TipoDeSala>();
        static int entityTipos = 0;

        public ActionResult ListaWSDownload() {
            try {
                WebClient webClient = new WebClient();
                string jsonRecebido = webClient.DownloadString("http://localhost:9999/ControleAcademico/WS/TipoSalas/Pesquisar");
                Response.Write(jsonRecebido);

                Salas salas = JsonConvert.DeserializeObject<Salas>(jsonRecebido);

                return RedirectToAction("List");

            }
            catch (Exception) {
                return new EmptyResult();
            }
        }

        public ActionResult List()
        {
            return View(listaTipoSalas);
        }


        // GET: TipoSalas/Details/5
        public ActionResult Details(int id)
        {
            return View(listaTipoSalas.Find(x => x.idTipoSala == id));
        }

        // GET: Ensalamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ensalamento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                for (int i = 0; i < collection.Count; i++) {
                    Debug.WriteLine(collection[i]);
                }
                TipoDeSala tipoSalas = new TipoDeSala() {
                    idTipoSala = ++entityTipos,
                    nomeTipo = Convert.ToString(collection["descricaoSala"])
                };
                listaTipoSalas.Add(tipoSalas);
                string jsonEnvio = JsonConvert.SerializeObject(tipoSalas);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/TipoSalas/Cadastrar", jsonEnvio);

                Response.Write(jsonRecebido);

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Ensalamento/Edit/5
        public ActionResult Edit(int id) {
            return View(listaTipoSalas.Find(x => x.idTipoSala == id));
        }

        // POST: Ensalamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                int i = 1;
                listaTipoSalas.Find(x => x.idTipoSala == id).idTipoSala = Convert.ToInt32(collection[++i]);
                listaTipoSalas.Find(x => x.idTipoSala == id).nomeTipo = Convert.ToString(collection[++i]);

                string jsonEnvio = JsonConvert.SerializeObject(listaTipoSalas);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/TipoSalas/Atualizar", jsonEnvio);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ensalamento/Delete/5
        public ActionResult Delete(int id)
        {
            listaTipoSalas.Remove(listaTipoSalas.Find(x => x.idTipoSala == id));
            string jsonEnvio = JsonConvert.SerializeObject(listaTipoSalas);
            WebClient webClient = new WebClient();

            string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/TipoSalas/Remover", jsonEnvio);


            return RedirectToAction("List");
        }

        // POST: Ensalamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
