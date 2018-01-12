using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInicial.Models;

namespace MVCInicial.Controllers
{
    public class SerieController : Controller
    {
        // GET: Serie
        public ActionResult Index()
        {
          
            return View();
        }
       

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            Context bd = new Context();
            ViewBag.MarcaID = new SelectList(bd.Marcas, "ID", "Nom_marca");
            bd.SaveChanges();
            return View();
        }

        // POST: Serie/Create
        [HttpPost]
        public ActionResult Create(SerieModelo serie)
        {
            try
            {
                using (var bd = new Context())
                {
                    bd.Series.Add(serie);
                    bd.SaveChanges();
                }

                // TODO: Add insert logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Serie/Edit/5
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

        // GET: Serie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Serie/Delete/5
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
