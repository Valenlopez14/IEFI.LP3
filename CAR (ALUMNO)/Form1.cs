using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CAR
{
    public partial class Form1 : Form
    {
        clsVentas Ventas;
        clsVendedor Vendedor;

        DataTable dtVentas = new DataTable();
       
        DataTable dtVendedor = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            Ventas = new clsVentas();
            Vendedor = new clsVendedor();

            DataTable dtVentas = new DataTable();
            DataTable dtVendedor = new DataTable();

            dtVentas = Ventas.getTablaVentas();
            dtVendedor = Vendedor.getVendedor();

            





            chart1.Series.Clear();
            int desde = Convert.ToInt32(txtDesde.Text);
            int hasta = Convert.ToInt32(txtHasta.Text);
            Series serie = new Series();



            for (int aa= desde; aa <= hasta; aa++)
            {
               serie = chart1.Series.Add(aa.ToString());


                foreach (DataRow fila in dtVentas.Rows)
                {
                    
                    serie.Points.AddXY(fila["vendedor"], fila["cantidad"]);

                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Ventas = new clsVentas();
               Vendedor = new clsVendedor();
                string SQL = "";
                

                DataTable dV = Vendedor.getTablaVendedor(SQL = "SELECT * FROM VENDEDORES");

                foreach (DataRow fila in dV.Rows)
                {
                    ListViewItem a = listView1.Items.Add(fila["nombre"].ToString());
                    a.Tag = fila["vendedor"];
                }




            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }





        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
