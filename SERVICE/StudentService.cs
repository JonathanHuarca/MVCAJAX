using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using INFRAESTRUCTURE;

namespace SERVICE
{
    public class StudentService
    {
        public List<Student> Get() 
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetById(int ID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }
            return student;
        }

        public Student GetStudent(string name)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(name);
            }
            return student;
        }
        public void Insert(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Update(Student student, int ID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);
                studentNew.studentName = student.studentName;
                studentNew.studentAddress = student.studentAddress;
                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.Find(ID);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public List<Student> GetSearch(string name)
        {
            List<Student> lista = new List<Student>();

            using (var context = new SchoolContext())
            {
                lista = context.Students.Where(x => x.studentName == name).ToList();
            }
            return lista;
        }
    }
}
