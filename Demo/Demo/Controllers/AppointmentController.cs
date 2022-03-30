﻿using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

        // EDIT
        public ActionResult Edit(int id)
        {
            var appointment = entities.Appointments.Find(id);
            appointment.PatientsList = GetAllPatients();
            appointment.DoctorsList = GetAllDoctors();
            return View(appointment);
        }

        [HttpPut]
        public ActionResult Edit(int id, Appointment appointment)
        {
            try
            {
                Appointment app = entities.Appointments.Find(id);
                if (TryUpdateModel(app))
                {
                    app.Type = appointment.Type;
                    app.PatientId = appointment.PatientId;
                    app.DoctorId = appointment.DoctorId;
                    app.Patient = appointment.Patient;
                    app.Doctor = appointment.Doctor;
                    app.PatientsList = GetAllPatients();
                    app.DoctorsList = GetAllDoctors();
                    entities.SaveChanges();
                    TempData["message"] = "Appointment edited!";
                    return RedirectToAction("Index");
                }
                return View(appointment);
            }
            catch (Exception e)
            {
                return View(appointment);
            }
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

        public ActionResult Select(int patientId, DateTime startDate, DateTime endDate)
        {
            
            return View(GetStoredProc(patientId, startDate, endDate));
        }



        // Helper methods
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

        [NonAction]
        public List<Appointment> GetStoredProc(int patientId, DateTime startDate, DateTime endDate)
        {
            var connString = new popaadbEntities().Database.Connection.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.FindAppointmentsForPatient";
                    cmd.Parameters.Add("@start_date", SqlDbType.Date).Value = startDate;
                    cmd.Parameters.Add("@end_date", SqlDbType.Date).Value = endDate;
                    cmd.Parameters.Add("@patient_id", SqlDbType.Int).Value = patientId;
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    conn.Close();
                    DataTable dt = ds.Tables[0];
                    List<Appointment> apps = new List<Appointment>();
                    foreach (DataRow row in dt.Rows)
                    {
                        apps.Add(new Appointment
                        {
                            Type = row["Type"].ToString(),
                            Date = Convert.ToDateTime(row["Date"].ToString()),
                            PatientId = Convert.ToInt32(row["PatientId"].ToString()),
                            DoctorId = Convert.ToInt32(row["DoctorId"].ToString())
                        });
                    }
                    return apps;
                }
            }
            List<Appointment> list = new List<Appointment>();
            return list;
        }
    }
}