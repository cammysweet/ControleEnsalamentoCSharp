using ControlesEnsalamento.DTO;
using ControlesEnsalamento.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControlesEnsalamento.Controllers
{
    public class DisciplinasController : Controller
    {
        string WSPathDisciplina = WebConfigurationManager.AppSettings["WSPath"] + "/Disciplina";

        // GET: Disciplinas
        public ActionResult Index() {
            return View();
        }

        static List<Disciplina> listaDisciplinas = new List<Disciplina>();
        static int EntityDisciplinas = 0;

        public ActionResult List() {
            WebClient wc = new WebClient();
            try {
                string listaDisciplinaJson = wc.DownloadString(WSPathDisciplina + "/Pesquisar");
                if (!listaDisciplinaJson.Contains("vazia")) {
                    DisciplinaDTO pDTO = JsonConvert.DeserializeObject<DisciplinaDTO>(listaDisciplinaJson);
                    return View(pDTO.lista);
                }
                else {
                    return View(new List<Disciplina>());
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return View(new List<Disciplina>());
            }

        }

        // GET: Disciplinas/Details/5
        public ActionResult Details(int id)
        {
            return View(listaDisciplinas.Find(x => x.idDisciplina == id));
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplinas/Create
        [HttpPost]
        public ActionResult Create(Disciplina disciplina)//FormCollection collection
        {
            try
            {
                //for (int i = 0; i < collection.Count; i++)
                //{
                //    Debug.WriteLine(collection[i]);
                //}
                //Disciplinas diciplinas = new Disciplinas()
                //{
                //    //idDisciplina = ++EntityDisciplinas,
                //    descricaoDisciplinas = Convert.ToString(collection["descricaoDisciplina"])
                //};
                //listaDisciplinas.Add(diciplinas);
                string jsonEnvio = JsonConvert.SerializeObject(disciplina);//diciplinas
                WebClient webClient = new WebClient();

                webClient.Headers.Add("Content-Type", "Application/Json");
                string jsonRecebido = webClient.UploadString(WSPathDisciplina + "/Cadastrar", jsonEnvio);

                Response.Write(jsonRecebido);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Disciplinas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Disciplinas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int i = 1;
                listaDisciplinas.Find(x => x.idDisciplina == id).descricaoDisciplinas = Convert.ToString(collection[++i]);

                string jsonEnvio = JsonConvert.SerializeObject(listaDisciplinas);
                WebClient webClient = new WebClient();

                string jsonRecebido = webClient.UploadString("http://localhost:9999/ControleAcademico/WS/Ensalamentos/Atualizar", jsonEnvio);

                return View();
                               
            }
            
            catch
            {
                return View();
            }
        }

        // GET: Disciplinas/Delete/5
        public ActionResult Delete(int id)
        {
            listaDisciplinas.Remove(listaDisciplinas.Find(x => x.idDisciplina == id));
            return RedirectToAction("List");
        }

        // POST: Disciplinas/Delete/5
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
