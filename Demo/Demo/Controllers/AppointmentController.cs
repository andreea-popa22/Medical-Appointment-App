using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class AppointmentController : Controller
    {
        private popaadbEntities entities = new popaadbEntities();
        public ActionResult Index()
        {
            return View(entities.Appointments.ToList());
        }

        // NEW
        public ActionResult New()
        {
            Appointment appointment = new Appointment();
            appointment.PatientsList = GetAllPatients();
            appointment.DoctorsList = GetAllDoctors();

            return View(appointment);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment model)
        {
            var entities = new popaadbEntities();
            entities.Appointments.Add(model);
            entities.SaveChanges();
            ViewBag.Message = "Appointment created successfully!";
            return View();
        }

        // SHOW
        public ActionResult Show(int id)
        {

            var appointment = entities.Appointments.Find(id);
            return View(appointment);
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllPatients()
        {
            var patientsList = new List<SelectListItem>();
            var patients = from p in entities.Patients
                        select p;
            foreach (var patient in patients)
            {
                patientsList.Add(new SelectListItem
                {
                    Value = patient.PatientId.ToString(),
                    Text = patient.Name.ToString() + " " + patient.Surname.ToString()
                });
            }
            return patientsList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllDoctors()
        {
            var doctorsList = new List<SelectListItem>();
            var doctors = from d in entities.Doctors
                           select d;
            foreach (var doctor in doctors)
            {
                doctorsList.Add(new SelectListItem
                {
                    Value = doctor.DoctorId.ToString(),
                    Text = doctor.Name.ToString() + " " + doctor.Surname.ToString()
                });
            }
            return doctorsList;
        }
    }
}