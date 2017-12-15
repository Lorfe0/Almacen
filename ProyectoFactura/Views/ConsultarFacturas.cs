using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ProyectoFactura
{
    public partial class ConsultarFacturas : Form
    {
        private string consultar;
        public ConsultarFacturas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (cbBuscar.Text == "Facturas")
            {
                try
                {
                    consultar = "Select * FROM facturas WHERE numeroFactura =" + txtBuscar.Text;
                    buscarFactura(consultar);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                  
               
                
            }
           else if(cbBuscar.Text == "Productos Facturados")
            {
                consultar = "Select * FROM detalles WHERE numeroFactura =" + txtBuscar.Text;
                buscarFactura(consultar);

            }


        }


        private void buscarFactura(string consultar)
        {
            ConectarBD.Conectar();
            MySqlCommand cmd = new MySqlCommand(consultar, ConectarBD.Conectar());

            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ConectarBD.Desconectar();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ContenedorPrincipal c = new ContenedorPrincipal();
            c.Show();
            this.Hide();
        }
    }
}
