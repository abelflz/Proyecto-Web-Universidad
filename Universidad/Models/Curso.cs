using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required]
        [Display(Name = "Código del Curso")]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Nombre de Curso")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Cantidad de Créditos")]
        public int Creditos { get; set; }

        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}