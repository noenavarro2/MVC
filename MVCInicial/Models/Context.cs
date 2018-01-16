using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCInicial.Models
{
    public class Context : DbContext
    {     
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
    }

}