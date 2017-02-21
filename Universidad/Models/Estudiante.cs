using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Estudiante
    {
        [Key]
        [Required(ErrorMessage ="Debe digitar una matrícula")]
        [Display(Name = "Matrícula")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "El nombre del Estudiante es Requerido")]
        [Display(Name = "Nombre del Estudiante")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del Estudiante es Requerido")]
        [Display(Name = "Apellido del Estudiante")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Debe digitar un correo")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La fecha de Inscripción es necesario")]
        [Display(Name = "Fecha de Inscripción", Description = "Fecha de Inscripción")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha_Inscripccion { get; set; }

        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}