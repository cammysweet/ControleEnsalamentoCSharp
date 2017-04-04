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
    public class ProfessorController : Controller
    {
        // GET: Professores
        public ActionResult Index()
        {
            return View();
        }

        static List<Professor> listaProfessores = new List<Professor>();
        static int entityProfessores = 0;

        public ActionResult ListaWSDownload()
        {
            try
            {
                WebClient webClient = new WebClient();
                string jsonRecebido = webClient.DownloadString("http://localhost:9999/ControleAcademico/WS/Ensalamentos/Pesquisar");
                Response.Write(jsonRecebido);

                Ensalamentos ensalamentos = JsonConvert.DeserializeObject<Ensalamentos>(jsonRecebido);

                return RedirectToAction("List");

            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }


        public ActionResult List()
        {
            return View(listaProfessores);
        }


        // GET: Professores/Details/5
        public ActionResult Details(int id)
        {
            return View(listaProfessores.Find(x => x.matricula == id));

        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            
                //try
                //{
                //    for (int i = 0; i < collection.Count; i++)
                //    {
                //        Debug.WriteLine(collection[i]);
                //    }
                //    Professor professores = new Professor()
                //    {
                //        matricula = ++entityProfessores,
                //        nomeProfessor = Convert.ToString(collection["nomeProfessor"]),
                //        status = Convert.ToBoolean(collection["statusProfessor"])
                //    };
                //    listaProfessores.Add(professores);
                    string jsonEnvio = JsonConvert.SerializeObject(professor);
                    WebClient webClient = new WebClient();

                    string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Ensalamentos/Cadastrar", jsonEnvio);

                    Response.Write(jsonRecebido);

                    return RedirectToAction("List");

        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Professores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int i = 1;
                
                listaProfessores.Find(x => x.matricula == id).matricula = Convert.ToInt32(collection[++i]);
                listaProfessores.Find(x => x.matricula == id).nomeProfessor = Convert.ToString(collection[++i]);

                string jsonEnvio = JsonConvert.SerializeObject(listaProfessores);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Professores/Atualizar", jsonEnvio);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int id)
        {
            listaProfessores.Remove(listaProfessores.Find(x => x.matricula == id));

            string jsonEnvio = JsonConvert.SerializeObject(listaProfessores);
            WebClient webClient = new WebClient();

            string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Professores/Remover", jsonEnvio);

            return RedirectToAction("List");
        }

        // POST: Professores/Delete/5
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
