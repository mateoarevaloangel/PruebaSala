using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace pruebaSala.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var DBConnection = "Data Source=DESKTOP-HRBLSGJ\\SQLEXPRESS; Initial Catalog = PruebaDB; User ID = userPrueba2; Password = 123;Trusted_Connection=SSPI;MultipleActiveResultSets=true;";
            //var DBConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
            var queryReservaciones = "SELECT * FROM Sala";
            using (var connection = new SqlConnection(DBConnection))
            {
                var sala = connection.Query(queryReservaciones).ToList();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}