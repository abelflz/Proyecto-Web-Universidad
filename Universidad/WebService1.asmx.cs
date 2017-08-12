using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;

namespace Universidad
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [DataContract]
        public class Curso
        {
            [DataMember]
            public string codigo { get; set; }

            [DataMember]
            public string nombre { get; set; }

            [DataMember]
            public int credito { get; set; }
        }
        [WebMethod]
        public List<Curso> MostrarCurso()
        {
            List<Curso> curso = new List<Curso>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ABEL-PC;Initial Catalog=Uni2;Integrated Security=True";

            con.Open();

            SqlCommand cmd = new SqlCommand("select Codigo, Nombre, Creditos from Cursoes", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var llenarCurso = new Curso
                {
                    nombre = reader["Nombre"].ToString(),
                    codigo = reader["Codigo"].ToString(),
                    credito = Convert.ToInt32(reader["Creditos"])
                };
                curso.Add(llenarCurso);
            }
            return curso;
        }
    }
}
