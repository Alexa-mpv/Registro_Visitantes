using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace RegistroVisitantes
{
    public class ConexionBD
    {
        public OdbcConnection con { get; set; }
        public ConexionBD()
        {
            System.Configuration.Configuration webConfig;
            webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Registro");
            System.Configuration.ConnectionStringSettings StringDeConexion;
            StringDeConexion = webConfig.ConnectionStrings.ConnectionStrings["BDRegistro"];
            con = new OdbcConnection(StringDeConexion.ToString());
            con.Open();
        }
    }
}