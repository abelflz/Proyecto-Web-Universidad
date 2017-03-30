using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models
{
    public class Profesor
    {
        [Display(Name = "Cédula")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string cedula { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Apellido")]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; }

        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}