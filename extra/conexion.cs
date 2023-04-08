using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace extra
{
    class conexion
    {
        SqlConnection con = new SqlConnection("Data source=DESKTOP-0LNL72F\\ISAACW7; Initial Catalog=ejemplo;Integrated Security=True ");
        private SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        
        public void conectar()
        {
            try
            {
                con.Open();
                MessageBox.Show("conectado");
            }
            catch
            {
                MessageBox.Show("fallo en la conexion");
            }
            finally
            {
                con.Close();
            }
        }
        public void consulta(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }
        public bool insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();

            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public bool baja(string tabla, string condicion)
        {
            con.Open();
            string eliminar = "delete from " + tabla + " where " + condicion;
            comando = new SqlCommand(eliminar, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        public bool modificar(string tabla, string campos, string condicion)
        {
            con.Open();
            string modifica = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new SqlCommand(modifica, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool existeID(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            

            int i = (int)cmd.ExecuteScalar();

            
            if (i > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
            
        }


    }
}

