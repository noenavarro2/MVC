using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInicial.Models;
using System.Data.Entity;

namespace MVCInicial.Controllers
{
    public class VehiculoController : Controller
    {
        Context bd = new Context();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculos =bd.Vehiculos.Include(x =>  x.Serie);

            return View(vehiculos.ToList());
        }

        // GET: Vehiculo/Details/
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {

            ViewBag.SerieID = new SelectList(bd.Series,"ID", "Nom_serie");//en el desplegable nos tiene que salir las series vectra corsa... para elegir
           
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            try
            {
                bd.Vehiculos.Add(vehiculo);
                bd.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehiculo/Edit/5
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

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehiculo/Delete/5
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
