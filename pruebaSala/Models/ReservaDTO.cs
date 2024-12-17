using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSala.Models
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreSala { get; set; }
    }
}