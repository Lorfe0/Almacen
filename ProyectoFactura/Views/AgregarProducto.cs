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
    public partial class AgregarProducto : Form
    {
        private  static string idProductoSelect;
        int fila;

        Inventario inv = new Inventario();
        public AgregarProducto()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contenedor = new ContenedorPrincipal();
            contenedor.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength != 0 && txtDescripcion.TextLength != 0 && txtPrecio.TextLength != 0)
            {
                Producto p = new Producto(txtCodigo.Text, txtDescripcion.Text, double.Parse(txtPrecio.Text));         
                inv.AddProducto(p);
                Cargar();
            }
            else
            {
                MessageBox.Show("No pueden estar vacio los campos");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                idProductoSelect = datosProductos[0, fila].Value.ToString();
                txtCodigo.Text = datosProductos[1, fila].Value.ToString();
                txtDescripcion.Text = datosProductos[2, fila].Value.ToString();
                txtPrecio.Text = datosProductos[3, fila].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            fila = datosProductos.CurrentRow.Index;
            Producto p = new Producto(txtCodigo.Text, txtDescripcion.Text, double.Parse(txtPrecio.Text));
            datosProductos[1, fila].Value = txtCodigo.Text;
            datosProductos[2, fila].Value = txtDescripcion.Text;
            datosProductos[3, fila].Value = txtPrecio.Text;
            inv.Actualizar(p);
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto(txtCodigo.Text, txtDescripcion.Text, double.Parse(txtPrecio.Text));
                datosProductos.Rows.RemoveAt(fila);
                inv.Eliminar(p);
            }
            catch (Exception)
            {

                MessageBox.Show("No existe productos");
            }
                
        }

        public void Cargar()
        {

            string obtenerTabla = "SELECT * FROM producto";
            ConectarBD.Conectar();
            MySqlCommand cmd = new MySqlCommand(obtenerTabla, ConectarBD.Conectar());
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {

                datosProductos.Rows.Add(r["idProducto"].ToString(),
                                        r["CodigoProducto"].ToString(),
                                        r["nombreProducto"].ToString(),
                                        r["precioProducto"].ToString());

            }



            ConectarBD.Desconectar();
        }

        public Boolean validar(string mes)
        {
            if (txtCodigo.TextLength != 0 && txtDescripcion.TextLength != 0 && txtPrecio.TextLength != 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(mes);
                return false;
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal con = new ContenedorPrincipal();
            this.Hide();
            con.Show();
       
        }
    }
}
