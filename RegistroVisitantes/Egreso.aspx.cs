using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroVisitantes
{
    public partial class Egreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nVisitante = TextBox1.Text;
            string update = $"UPDATE historial SET fEgreso = GETDATE() WHERE cVisitante = (SELECT visitante.cVisitante from visitante WHERE visitante.nombre = '{nVisitante}')";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(update, conexion);
            try
            {
                comando.ExecuteNonQuery();
                Label1.Text = "Registro exitoso";
            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message;
            }
            
            conexion.Close();
        }
    }
}