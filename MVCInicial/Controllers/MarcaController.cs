using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInicial.Models;

namespace MVCInicial.Controllers
{
    public class MarcaController : Controller
    {
        Context bd = new Context();
        // GET: Marca
        public ActionResult Index()
        {

            return View();
        }

        // GET: Marca/Details/5
        public ActionResult Desplegable()
        {
            
            ViewBag.Marcas = new SelectList(bd.Marcas, "Id", "Nom_marca");
            ViewBag.Marcas1 = bd.Marcas.ToList(); //tolist te devueve el contenido de una tabla en una lista
           bd.SaveChanges();
            return View();
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(MarcaModelo marca)
        {
            try
            {
                using (var bd = new Context())
                {
                    bd.Marcas.Add(marca);
                    bd.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marca/Delete/5
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
        public ActionResult List()
        {
            List<MarcaModelo> marcas = bd.Marcas.ToList();
            
            return View(marcas);
        }
    }
}
