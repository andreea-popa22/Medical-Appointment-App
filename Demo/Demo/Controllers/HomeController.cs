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
        public List<Demo.Models.Patient> ListPatients()
        {
            var patientsList = new List<Demo.Models.Patient>();
            var patients = from p in entities.Patients
                           select p;
            //foreach (var patient in patients)
            //{
            //    patientsList.Add(new Patient
            //    {
            //        Value = patient.PatientId.ToString(),
            //        Text = patient.Name.ToString() + " " + patient.Surname.ToString()
            //    });
            //}
            return patients.ToList();
        }
    }
}