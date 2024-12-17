using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSala.Models
{
    public class Sala
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
    }
}