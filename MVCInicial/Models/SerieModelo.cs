﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCInicial.Models
{
    public class SerieModelo
    { 
        public int ID { get; set; }
        public string Nom_serie { get; set; }
        public int? MarcaID { get; set; }
        //int? para permitir valores nulos por ejemplo si no metes marca
      //  [ForeignKey("MarcaModelo")]
        public MarcaModelo Marca{ get; set; }
    }
}