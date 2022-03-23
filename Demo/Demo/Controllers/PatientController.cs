using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PatientController : Controller
    {
        private popaadbEntities entities = new popaadbEntities();
        public ActionResult Index()
        {
            return View(entities.Patients.ToList());
        }

        // NEW
        public ActionResult New()
        {
            Patient patient = new Patient();
            return View(patient);
        }

        [HttpPost]
        public ActionResult New(Patient patient)
        {
            entities.Patients.Add(patient);
            entities.SaveChanges();
            ViewBag.Message = "Patient added successfully!";
            return Redirect("/Patient/Show/" + patient.PatientId);
        }

        // SHOW
        public ActionResult Show(int id)
        {
            var patient = entities.Patients.Find(id);
            return View(patient);
        }

        // EDIT
        public ActionResult Edit(int id)
        {
            var patient = entities.Patients.Find(id);
            return View(patient);
        }

        [HttpPut]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                Patient pt = entities.Patients.Find(id);
                if (TryUpdateModel(pt))
                {
                    pt.Name = patient.Name;
                    pt.Surname = patient.Surname;
                    pt.Gender = patient.Gender;
                    pt.BirthDate = patient.BirthDate;
                    entities.SaveChanges();
                    TempData["message"] = "Patient details updated!";
                    return RedirectToAction("Index");
                }
                return View(patient);
            }
            catch (Exception e)
            {
                return View(patient);
            }
        }

        // DELETE
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Patient patient = entities.Patients.Find(id);
            entities.Patients.Remove(patient);
            entities.SaveChanges();
            TempData["message"] = "Patient " + patient.PatientId + " was successfully deleted!";
            return RedirectToAction("Index");
        }
    }
}