using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInicial.Models
{
    public class ClienteModelo
    {
        public int ID { get; set; }
        public string Nom_marca { get; set; }
        public List<VehiculoModelo> vehiculos { get; set; }
    }
}