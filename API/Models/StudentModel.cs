using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class StudentModel
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentAddress { get; set; }
        public string LastName { get; set; }
        public string Codigo { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public bool Activo { get; set; }

    }
}

