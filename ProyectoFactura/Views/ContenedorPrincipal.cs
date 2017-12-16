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

            a.MdiParent = this;
            a.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FacturarProducto facturar = new FacturarProducto();
            facturar.MdiParent = this;
            facturar.Show();
            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ConsultarFacturas consultar = new ConsultarFacturas();
            consultar.MdiParent = this;
            consultar.Show();
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void ContenedorPrincipal_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            // Display a child form to show this is still an MDI application.
          

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
