using ControlesEnsalamento.DTO;
using ControlesEnsalamento.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ControlesEnsalamento.Controllers
{
    public class TurmasController : Controller
    {
        string WSPathTurma = WebConfigurationManager.AppSettings["WSPath"] + "/Turma";
        // GET: Turmas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            {
                WebClient wc = new WebClient();
                try
                {
                    string listaDisciplinaJson = wc.DownloadString(WSPathTurma + "/Pesquisar");
                    if (!listaDisciplinaJson.Contains("Vazia"))
                    {
                        TurmaDTO pDTO = JsonConvert.DeserializeObject<TurmaDTO>(listaDisciplinaJson);
                        return View(pDTO.lista);
                    }
                    else
                    {
                        return View(new List<Turma>());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return View(new List<Turma>());
                }
            }
        }


        // GET: Turmas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Turmas/Create
        public ActionResult Create()
        {
            List<SelectListItem> listaCurso = DropDownClass.ListaDropDownCurso();
            ViewBag.ListaCurso = listaCurso;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Turma turma)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers.Add("Content-Type", "application/json");

                string turmaJson = JsonConvert.SerializeObject(turma);
                string jsonRecebido = webClient.UploadString(WSPathTurma + "/Cadastrar", turmaJson);
                return RedirectToAction("List");

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Turmas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                    return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int id)
        {
                return RedirectToAction("List");

        }

        // POST: Turmas/Delete/5
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
