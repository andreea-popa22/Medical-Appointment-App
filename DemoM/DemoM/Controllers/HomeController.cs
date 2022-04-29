using DemoM.Data;
using DemoM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoM.Controllers
{
    public class HomeController : Controller
    {
        private PopaaDbContext entities = new PopaaDbContext();
        public ActionResult Index()
        {
            ViewBag.Doctors = ListDoctors();
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
