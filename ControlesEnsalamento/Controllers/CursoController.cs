using ControlesEnsalamento.DTO;
using ControlesEnsalamento.Models;
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
    public class CursoController : Controller
    {
        string WSPathCurso = WebConfigurationManager.AppSettings["WSPath"] + "/Curso";

        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List() {
            WebClient wc = new WebClient();

            try {
                string listaCurso = wc.DownloadString(WSPathCurso + "/Pesquisar");
                if (!listaCurso.Contains("Vazia")) {
                    CursoDTO pDTO = JsonConvert.DeserializeObject<CursoDTO>(listaCurso);
                    return View(pDTO.lista);
                }
                else {
                    return View(new List<Curso>());
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return View(new List<Curso>());
            }
        }
        
        // GET: Curso/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    WebClient webClient = new WebClient();
                    var jsonCurso = webClient.DownloadString(WSPathCurso + "/Recuperar/" + id.ToString());
                    CursoDTO pDto = JsonConvert.DeserializeObject<CursoDTO>(jsonCurso);
                    return View(pDto.curso);
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return View(new Curso());
            }
            
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }
    

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content-Type", "application/json");

                string cursoJson = JsonConvert.SerializeObject(curso);
                string jsonRecebido = webClient.UploadString(WSPathCurso + "/Cadastrar", cursoJson);
                return RedirectToAction("List");

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int? id)
        {
            WebClient webClient = new WebClient();
            try
            {
                string retorno = webClient.DownloadString(WSPathCurso + "/Recuperar/" + id.ToString());
                CursoDTO pDto = JsonConvert.DeserializeObject<CursoDTO>(retorno);
                return View(pDto.curso);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View(new Curso());
            }
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Curso curso)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                string jsonCurso = JsonConvert.SerializeObject(curso);

                string retorno = webClient.UploadString(WSPathCurso + "/Atualizar", "PUT", jsonCurso);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("List", new List<Curso>());
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curso/Delete/5
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
