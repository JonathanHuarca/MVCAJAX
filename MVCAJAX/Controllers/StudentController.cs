using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using DOMAIN;
using SERVICE;
using System.Web.Mvc;
using INFRAESTRUCTURE;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();

        public ActionResult IndexRazor()
        {

            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             studentID = c.studentID,
                             studentAddress = c.studentAddress,
                             studentName = c.studentName,
                             LastName = c.LastName,
                             Codigo=c.Codigo,
                             FechaCreacion = c.FechaCreacion,
                             FechaModificacion = c.FechaModificacion

                         }).ToList();

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public ActionResult searchStudent()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getStudentWithFilter(string name)
        {
            var students = service.GetSearch(name);
            return Json(students, JsonRequestBehavior.AllowGet);
        }

    }
}