using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static UniversityDBAJAXEntities DbContext;
        static DAL()
        {
            DbContext = new UniversityDBAJAXEntities();
        }

        public static List<Student> GetAllStudents()
        {
            return DbContext.Students.ToList();
        }
        public static Student GetStudent(int studentID)
        {
            return DbContext.Students.Where(p => p.studentID == studentID).FirstOrDefault();
        }

        public static bool InsertStudent(Student productItem)
        {
            bool status;
            try
            {
                DbContext.Students.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool UpdateStudent(Student productItem)
        {
            bool status;
            try
            {
                Student prodItem = DbContext.Students.Where(p => p.studentID == productItem.studentID).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.studentName = productItem.studentName;
                    prodItem.studentAddress = productItem.studentAddress;
                    prodItem.LastName = productItem.LastName;
                    prodItem.Codigo = productItem.Codigo;
                    prodItem.FechaCreacion = productItem.FechaCreacion;
                    prodItem.FechaModificacion = productItem.FechaModificacion;
                    prodItem.Activo = productItem.Activo;

                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteStudent(int id)
        {
            bool status;
            try
            {
                Student prodItem = DbContext.Students.Where(p => p.studentID == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.Students.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
