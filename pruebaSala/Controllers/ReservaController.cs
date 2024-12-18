using Dapper;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using pruebaSala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pruebaSala.Repository.Interface;
using pruebaSala.Repository.Service;

namespace pruebaSala.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaRepository reservaRepository;

        public ReservaController()
        {
            reservaRepository = new ReservaRepository();
        }
        // GET: Reserva
        public ActionResult Index()
        {
            ViewBag.mensaje = "cargar salas disponibles";
            ViewBag.Reserva = reservaRepository.GetReservas();
            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            ViewBag.mensaje = "cargar salas disponibles";
            ViewBag.salas = new List<Sala>();
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(Reserva reserva)//(FormCollection collection)
        {
            
            try
            {
                // TODO: Add insert logic here
                //Validar disponibilidad de la sala
                //ViewBag.Reserva = reservaRepository.AddReserva(reserva);
                if (reserva.SalaID == 0)
                {
                    ViewBag.mensaje = "enviar";
                    //return RedirectToAction("Index");
                    ViewBag.salas = reservaRepository.GetSalasDisponibles(reserva);
                    return View();
                }
                else {
                    ViewBag.Reserva = reservaRepository.AddReserva(reserva);
                    return RedirectToAction("Index");
                }
                
                return View();
            }
            catch
            {
                return View();
            }
        }
        

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.mensaje = "cargar salas disponibles";
            ViewBag.salas = new List<Sala>();
            var result = reservaRepository.GetReserva(id);
            return View(result);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Reserva reserva)
        {
            try
            {
                // TODO: Add update logic here

                if (reserva.SalaID == 0)
                {
                    ViewBag.mensaje = "enviar";
                    //return RedirectToAction("Index");
                    ViewBag.salas = reservaRepository.GetSalasDisponibles(reserva);
                    return View();
                }
                else
                {
                    ViewBag.Reserva = reservaRepository.UpdateReserva(reserva);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserva/Delete/5
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
