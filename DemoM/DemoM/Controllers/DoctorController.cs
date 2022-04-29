using DemoM.Models;
using DemoM.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Controllers
{
    public class DoctorController : Controller
    {
        private PopaaDbContext entities = new PopaaDbContext();
        public ActionResult Index()
        {
            return View(entities.Doctors.ToList());
        }

        // NEW
        public ActionResult New()
        {
            Doctor doctor = new Doctor();
            doctor.MedicalCentersList = GetAllMedicalCenters();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult New(Doctor doctor)
        {
            entities.Doctors.Add(doctor);
            entities.SaveChanges();
            ViewBag.Message = "Doctor added successfully!";
            return Redirect("/Doctor/Show/" + doctor.DoctorId);
        }

        // SHOW
        public ActionResult Show(int id)
        {
            var doctor = entities.Doctors.Find(id);
            return View(doctor);
        }

        // EDIT
        public ActionResult Edit(int id)
        {
            var doctor = entities.Doctors.Find(id);
            doctor.MedicalCentersList = GetAllMedicalCenters();
            return View(doctor);
        }

        [HttpPut]
        public ActionResult Edit(int id, [FromBody] Doctor doctor)
        {
            try
            {
                Doctor dr = entities.Doctors.Find(id);
                if (ModelState.IsValid)
                {
                    dr.Name = doctor.Name;
                    dr.Surname = doctor.Surname;
                    dr.Gender = doctor.Gender;
                    dr.Specialization = doctor.Specialization;
                    dr.Experience = doctor.Experience;
                    dr.MedicalCenterId = doctor.MedicalCenterId;
                    dr.MedicalCenter = doctor.MedicalCenter;
                    entities.SaveChanges();
                    TempData["message"] = "Doctor details updated!";
                    return RedirectToAction("Index");
                }
                return View(doctor);
            }
            catch (Exception e)
            {
                return View(doctor);
            }
        }

        // DELETE
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Doctor doctor = entities.Doctors.Find(id);
            entities.Doctors.Remove(doctor);
            entities.SaveChanges();
            TempData["message"] = "Doctor " + doctor.DoctorId + " was successfully deleted!";
            return RedirectToAction("Index");
        }

        // Helper methods
        [NonAction]
        public IEnumerable<SelectListItem> GetAllMedicalCenters()
        {
            var medicalCentersList = new List<SelectListItem>();
            var medicalCenters = from p in entities.MedicalCenters
                           select p;
            foreach (var medicalCenter in medicalCenters)
            {
                medicalCentersList.Add(new SelectListItem
                {
                    Value = medicalCenter.MedicalCenterId.ToString(),
                    Text = medicalCenter.Name.ToString()
                });
            }
            return medicalCentersList;
        }
    }
}