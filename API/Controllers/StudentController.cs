using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SERVICE;
using DOMAIN;
using API.Models;
using System.Web.Http.Results;
using API.Repository;
using DataAccessLayer;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        StudentService Service;
        public StudentController()
        {
            Service = new StudentService();
        }

        //GET: STUDENT
        [HttpGet]

        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<DataAccessLayer.Student, StudentModel> mapObj = new EntityMapper<DataAccessLayer.Student, StudentModel>();
            List<DataAccessLayer.Student> prodList = DAL.GetAllStudents();
            List<StudentModel> Students = new List<StudentModel>();
            foreach (var item in prodList)
            {
                Students.Add(mapObj.Translate(item));
            }
            return Json<List<StudentModel>>(Students);
        }
        [HttpGet]
        public JsonResult<StudentModel> GetStudent(int id)
        {
            EntityMapper<DataAccessLayer.Student, StudentModel> mapObj = new EntityMapper<DataAccessLayer.Student, StudentModel>();
            DataAccessLayer.Student dalStudent = DAL.GetStudent(id);
            StudentModel Students = new StudentModel();
            Students = mapObj.Translate(dalStudent);
            return Json<StudentModel>(Students);
        
        }
        [HttpPost]
        public bool InsertStudent(StudentModel student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, DataAccessLayer.Student> mapObj = new EntityMapper<StudentModel, DataAccessLayer.Student>();
                DataAccessLayer.Student StudentObj = new DataAccessLayer.Student();
                StudentObj = mapObj.Translate(student);
                status = DAL.InsertStudent(StudentObj);
                status = true;
            }
            return status;
        }

        [HttpPut]
        public bool UpdateStudent(StudentModel student)
        {

            EntityMapper<StudentModel, DataAccessLayer.Student> mapObj = new EntityMapper<StudentModel, DataAccessLayer.Student>();
            DataAccessLayer.Student StudentObj = new DataAccessLayer.Student();
            StudentObj = mapObj.Translate(student);
            var status = DAL.UpdateStudent(StudentObj);
     
            return status;  
        }

        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            var status = DAL.DeleteStudent(id);
           
            return status;
        }
    }
}
