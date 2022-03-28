using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private popaadbEntities entities = new popaadbEntities();
        public ActionResult Index()
        {
            ViewBag.Appointments = ListAppointments();
            ViewBag.Patients = ListPatients();
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

        [NonAction]
        public List<Patient> ListPatients()
        {
            var patients = from p in entities.Patients
                           select p;
            return patients.ToList();
        }

        [NonAction]
        public List<Appointment> ListAppointments()
        {
            var apps = from a in entities.Appointments
                       select a;
            return apps.ToList();
        }

        [NonAction]
        public List<Doctor> ListDoctors()
        {
            var doctors = from d in entities.Doctors
                       select d;
            return doctors.ToList();
        }
    }
}