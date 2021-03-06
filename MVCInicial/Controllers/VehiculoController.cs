﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInicial.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MVCInicial.Controllers
{
    public class VehiculoController : Controller
    {
        Context bd = new Context();

        // GET: Vehiculo
        public ActionResult Index()
        {
            ViewBag.cualquiera = bd.Marcas.ToList();
            var vehiculos = bd.Vehiculos.Include(x => x.Serie);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculo/Details/
        public ActionResult BuscarVehiculos(String busqueda = "")//si a busqueda no le pasas ningun parametro busca toma "" y si si le pasas 
        {
        
            var lista = (from p in bd.Vehiculos.Include(x => x.Serie) where p.Matricula.Contains(busqueda) select p).ToList();//p.matricul.contains es como cuando hacemos el == de busqueda que sera la matricula que le pasemos          
                                                                                                        //el in es para llamar el bd. vehiculos le ponemos el in y se le llamara a partir de ahora p//var es un obajeto que se le pasa lo que se da la gana ..depende de lo que le pases sera eso... por ejemplo le pasas una lista y es una lista


            return View(lista);
        }
        public ActionResult Details(int id)//si a busqueda no le pasas ningun parametro busca toma "" y si si le pasas 
        {
            ViewBag.cualquiercosa = bd.Marcas.ToList();
            VehiculoModelo vehiculo = bd.Vehiculos.Include(x => x.Serie).FirstOrDefault(v => v.ID == id);


            return View(vehiculo);
        }

        public ActionResult BuscarPorDespelgable(String laMatricula = "")//si a busqueda no le pasas ningun parametro busca toma "" y si si le pasas 
        {
            ViewBag.laMatricula = new SelectList(bd.Vehiculos, "Matricula", "Matricula");
            var lista = (from p in bd.Vehiculos.Include(x => x.Serie) where p.Matricula.Equals(laMatricula) select p).ToList();
            return View(lista);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.SerieID = new SelectList(bd.Series, "ID", "Nom_serie");//en el desplegable nos tiene que salir las series vectra corsa... para elegir
            ViewBag.ExtraList= new MultiSelectList(bd.Extras, "ID", "TipoExtra");
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
                foreach (var extraId in vehiculo.ExtrasSeleccionados)
                {
                   var obj = new VehiculosExtrasModelo() { vehiculoID = vehiculo.ID, extraID = extraId} ;
                    bd.VehiculosExtras.Add(obj);
                }
                bd.SaveChanges();  
                    

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
            VehiculoModelo vehiculo = bd.Vehiculos.Find(id);
            ViewBag.SerieID = new SelectList(bd.Series, "ID", "Nom_serie", vehiculo.SerieID);
            vehiculo.ExtrasSeleccionados = bd.VehiculosExtras.Where(m => m.vehiculoID == vehiculo.ID).Select(m => m.extraID).ToList();
          //  var lista = (from p in bd.VehiculosExtras where p.vehiculoID.Equals(id) select p.extraID).ToList();
            ViewBag.ExtraList = new MultiSelectList(bd.Extras, "ID", "TipoExtra", vehiculo.ExtrasSeleccionados);//como 4 parametro se le pasan los elementos seleccionados 

            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehiculoModelo vehiculo)
        {
            try
            {

                VehiculoModelo vehActualizar = bd.Vehiculos.SingleOrDefault(x => x.ID == id);
                vehActualizar.Matricula = vehiculo.Matricula;
                vehActualizar.Color = vehiculo.Color;
                vehActualizar.SerieID = vehiculo.SerieID;
              
                foreach (var extraId in vehiculo.ExtrasSeleccionados)
                {
                  // var vehelim = bd.FirstOrDefault(v => v.ID == id);
                   // bd.Vehiculos.Remove(vehelim);
                }
               
                bd.SaveChanges();

                foreach (var extraId in vehiculo.ExtrasSeleccionados)
                {
                    //VehiculosExtrasModelo vehiculosExtrasactualizar
                    var obj = new VehiculosExtrasModelo() { vehiculoID = vehiculo.ID, extraID = extraId };
                    bd.VehiculosExtras.Add(obj);
                }
                bd.SaveChanges();



                bd.SaveChanges();

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
            ViewBag.cualquiercosa = bd.Marcas.ToList();
            VehiculoModelo vehiculo = bd.Vehiculos.Include(x => x.Serie).FirstOrDefault(v => v.ID == id);
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                VehiculoModelo vehiculo = bd.Vehiculos.FirstOrDefault(v => v.ID == id);
                bd.Vehiculos.Remove(vehiculo);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Vehiculo/List/5
        public ActionResult Listado2(int idMarca = 1, int idSerie = 0)
        {
            
            ViewBag.idMarca = new SelectList(bd.Marcas, "ID", "Nom_marca");
            ViewBag.IdSerie = new SelectList(bd.Series.Where(x => x.MarcaID == idMarca), "ID", "Nom_serie");
            var vehiculos = bd.Vehiculos.Where(x => x.SerieID == idSerie );

            return View(vehiculos.ToList());
        }
        //get Color
        public ActionResult ListadoPorColor(string color="")//si no recibe nada es ""
        {
            ViewBag.color = new SelectList(bd.Vehiculos.Select(x => new { Color = x.Color}).Distinct(), "Color", "Color");//consulta de select,value , y text

            var lista = bd.Database.SqlQuery<VehiculoTotal>("getVehiculosPorColor @ColorSel",new SqlParameter("@ColorSel",color)).ToList();//voy a llamar a getvehiculosporcolor a traves de colorsell de procedures del sql server
            return View(lista);
        }
        // GET: Vehiculo/List/5
        public ActionResult Listado3()
        {
            var lista = bd.Database.SqlQuery<VehiculoTotal>("getSeriesVehiculos").ToList();

            return View(lista);
        }
        public class VehiculoTotal
        {
            public string Nom_marca { get; set; }
            public string Nom_serie { get; set; }
            public string Matricula { get; set; }
            public string color { get; set; }
        }
    }
  
}
