using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace CAR
{
    class clsVentas
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsVentas()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Ventas";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[3];
            dc[0] = tabla.Columns["vendedor"];
            dc[1] = tabla.Columns["aa"];
            dc[2] = tabla.Columns["mm"];
            tabla.PrimaryKey = dc;
        }

        public DataTable getTablaVentas()
        {
            return tabla;
        }
    }
}
