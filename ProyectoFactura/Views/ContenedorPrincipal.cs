using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFactura
{
    public partial class ContenedorPrincipal:Form
    {
        public ContenedorPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AgregarProducto a = new AgregarProducto();

            this.Hide();
            a.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FacturarProducto facturar = new FacturarProducto();
            facturar.Show();
            this.Hide();
            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ConsultarFacturas consultar = new ConsultarFacturas();
            consultar.Show();
            this.Hide();
        }
    }
}
