using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public enum Nota
    {
        A, B, C, D, F
    }
    public class Inscripcion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Profesor")]
        public string profesor { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Curso", Description = "Curso")]
        public string CodigoCurso { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Estudiante", Description = "Estudiante")]
        public int Matricula { get; set; }

        [Display(Name = "Nota", Description = "Nota")]
        public Nota? Nota { get; set; }

        [ForeignKey("CodigoCurso")]
        public virtual Curso Curso { get; set; }

        [ForeignKey("Matricula")]
        public virtual Estudiante Estudiante { get; set; }

        [ForeignKey("Profesor")]
        public virtual Profesor Profesor { get; set; }
    }
}