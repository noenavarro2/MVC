using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInicial.Models
{
    public class VehiculoModelo
    {
        //Id color matricula serie modelo serieID
        public int ID { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public SerieModelo Serie { get; set; }
        public int SerieID { get; set; }


        //items para el listbox
        public List<int> ExtrasSeleccionados { get; set; }//examen seguro 
        public List<VehiculosExtrasModelo> VehiculoExtras { get; set; }



    }
}