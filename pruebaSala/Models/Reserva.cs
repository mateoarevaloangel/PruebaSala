using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSala.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int SalaID { get; set; }
    }
}