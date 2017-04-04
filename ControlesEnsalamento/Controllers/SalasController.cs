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
    public class SalasController : Controller
    {
        // GET: Salas
        public ActionResult Index()
        {
            return View();
        }




        static List<Salas> listaSalas = new List<Salas>();
        static int entitySalas = 0;

        public ActionResult ListaWSDownload()
        {
            try
            {
                WebClient webClient = new WebClient();
                string jsonRecebido = webClient.DownloadString("http://localhost:9999/ControleAcademico/WS/Salas/Pesquisar");
                Response.Write(jsonRecebido);

                Salas salas = JsonConvert.DeserializeObject<Salas>(jsonRecebido);

                return RedirectToAction("List");

            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }


        public ActionResult List()
        {
            return View(listaSalas);

        }

        // GET: Salas/Details/5
        public ActionResult Details(int id)
        {
            return View(listaSalas.Find(x => x.idSala == id));
        }

        // GET: Salas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }
                Salas salas = new Salas()
                {
                    idSala  = ++entitySalas,
                    capacidade = Convert.ToInt32(collection["capacidade"]),
                };
                listaSalas.Add(salas);
                string jsonEnvio = JsonConvert.SerializeObject(salas);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Salas/Cadastrar", jsonEnvio);

                Response.Write(jsonRecebido);

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Salas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Salas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int i = 1;

                listaSalas.Find(x => x.idSala == id).idSala = Convert.ToInt32(collection[i]);
                listaSalas.Find(x => x.idSala == id).capacidade = Convert.ToInt32(collection[++i]);


                string jsonEnvio = JsonConvert.SerializeObject(listaSalas);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Salas/Atualizar", jsonEnvio);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Salas/Delete/5
        public ActionResult Delete(int id)
        {
            listaSalas.Remove(listaSalas.Find(x => x.idSala == id));
            return RedirectToAction("List");
        }

        // POST: Salas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
