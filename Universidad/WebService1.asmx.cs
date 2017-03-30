using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

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

        [WebMethod]
        public List<String> MostrarCurso()
        {
            List<String> Tabla = new List<String>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ABEL-PC;Initial Catalog=Uni2;Integrated Security=True";

            con.Open();

            SqlCommand cmd = new SqlCommand("select Nombre from Cursoes", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tabla.Add(reader["Nombre"].ToString());
            }
            return Tabla;     
        }
    }
}
