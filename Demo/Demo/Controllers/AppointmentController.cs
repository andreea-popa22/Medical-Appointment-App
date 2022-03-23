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

        [HttpPost]
        public ActionResult New(Appointment appointment)
        {
            entities.Appointments.Add(appointment);
            entities.SaveChanges();
            ViewBag.Message = "Appointment created successfully!";
            return Redirect("/Appointment/Show/" + appointment.AppointmentId);
        }

        // SHOW
        public ActionResult Show(int id)
        {

            var appointment = entities.Appointments.Find(id);
            return View(appointment);
        }

        // DELETE
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Appointment appointment = entities.Appointments.Find(id);
            entities.Appointments.Remove(appointment);
            entities.SaveChanges();
            TempData["message"] = "Appointment " + appointment.AppointmentId + " was successfully deleted!";
            return RedirectToAction("Index");
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