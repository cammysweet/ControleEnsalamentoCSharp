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
    public class EnsalamentoController : Controller
    {

        string WSPathEnsalamento = WebConfigurationManager.AppSettings["WSPath"] + "/Ensalamento";

        public ActionResult Index() {
            return View();
        }

        public enum Turno {
            MATUTINO = 'M', VESPERTINO = 'V', NOTURNO = 'N'
        };


        public ActionResult List() {
            if (Session["idEnsalamento"] != null)  {
                WebClient webClient = new WebClient();
                try {
                    string listaEnsalamento = webClient.DownloadString(WSPathEnsalamento + "/Pesquisar");

                    if (!listaEnsalamento.Contains("vazia")) {
                        EnsalamentoDTO eDto = JsonConvert.DeserializeObject<EnsalamentoDTO>(listaEnsalamento);
                        return View(eDto.lista);
                    }
                    else {
                        return View(new List<Ensalamentos>());
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return View(new List<Ensalamentos>());
                }
            }
                else
                return RedirectToAction("List");
        }



        // GET: Ensalamento/Details/5
        public ActionResult Details(int? id) {
            if (Session["idEnsalamento"] != null) {
                try {
                    if (id.HasValue) {
                        WebClient webClient = new WebClient();
                        var jsonEnsalamento = webClient.DownloadString(WSPathEnsalamento + "/Recuperar/" + id.ToString());
                        EnsalamentoDTO pDto = JsonConvert.DeserializeObject<EnsalamentoDTO>(jsonEnsalamento);
                        return View(pDto.ensalamento);
                    } else
                        return new HttpNotFoundResult();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return View(new Ensalamentos());
                }
            } else
                return RedirectToAction("Login", "Home");
        }


        // GET: Ensalamento/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Ensalamento/Create
        [HttpPost]
        public ActionResult Create(Ensalamentos ensalamentos) {
            try {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/json");

                string ensalamentoJson = JsonConvert.SerializeObject(ensalamentos);
                string jsonRecebido = webClient.UploadString(WSPathEnsalamento + "/Cadastrar", ensalamentoJson);

                if (Session["idEnsalamento"] != null)
                    return RedirectToAction("List");
                else
                    return RedirectToAction("Create");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return View("List");
            }
        }

        // GET: Ensalamento/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Ensalamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                   return RedirectToAction("List");
            }
            catch {
                return View();
            }
        }

        // GET: Ensalamento/Delete/5
        public ActionResult Delete(int id) {


            return RedirectToAction("List");
        }



        // POST: Ensalamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                return RedirectToAction("List");
            }
            catch {
                return View();
            }
        }
    }
}
