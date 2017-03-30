using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Universidad.Models;
using System.Data.Entity;


namespace Universidad.DAL
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("CS")
        {

        }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}