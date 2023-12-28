using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroVisitantes
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String query = "SELECT trabajador.cTrabajador, trabajador.nombre from trabajador";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();

                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "cTrabajador";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
                conexion.Close();
                DropDownList1.Items.Insert(0, new ListItem("(sin selección)", "-1"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rand = new Random().Next(1, 2000000);
            string nVisitante = TextBox1.Text;
            int cTrabajador = Convert.ToInt32(DropDownList1.SelectedValue);
            int cVisitante = InsertarVisitante(nVisitante);

            if(cVisitante != -1)
            {
                string query = $"INSERT INTO historial VALUES((SELECT ISNULL(MAX(cHistorial), 0) FROM historial) + {rand}, GETDATE(), NULL, ?, ?)";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);

                comando.Parameters.AddWithValue("cVisitante", cVisitante);
                comando.Parameters.AddWithValue("cTrabajador", cTrabajador);

                try
                {
                    comando.ExecuteNonQuery();
                    Label1.Text = "Registro exitoso";
                }
                catch (Exception ex)
                {
                    Label1.Text = "ERROR: " + ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                Label1.Text = "No se puede obtener la clave del visitante";
            }
        }
        private int InsertarVisitante(string nVisitante)
        {
            int rand = new Random().Next(1, 2000000);
            string query = $"IF NOT EXISTS (SELECT 1 FROM visitante WHERE nombre = '{nVisitante}') INSERT INTO visitante (cVisitante, nombre) VALUES ((SELECT ISNULL(MAX(cVisitante), 0) FROM visitante) + {rand}, '{nVisitante}')";
            int cVisitante = -1;
            string select = $"SELECT visitante.cVisitante from visitante WHERE nombre = '{nVisitante}'";

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message;
            }
            conexion.Close();

            conexion = new ConexionBD().con;
            comando = new OdbcCommand(select, conexion);
            try
            {
                object result = comando.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    cVisitante = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message;
            }
            conexion.Close ();

            return cVisitante;
        }
    }
}