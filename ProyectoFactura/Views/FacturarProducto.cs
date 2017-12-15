using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoFactura
{
    public partial class FacturarProducto : Form
    {

        private string consulta;
        Inventario inv = new Inventario();
        List<Detalle> facturado = new List<Detalle>();
        Factura f = new Factura();
        ConectarBD conec = ConectarBD.instancia();

        public FacturarProducto()
        {
            InitializeComponent();
        }

        //Metodo load ppara la fecha
        private void FacturarProducto_Load(object sender, EventArgs e)
        {
            
            lbFecha.Text = f.GetFecha().ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contenedor = new ContenedorPrincipal();
            this.Hide();
            contenedor.Show();

        }

        //Metodo para buscar productos
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength != 0)
            {
                try
                {
                    consulta = "SELECT  nombreProducto, precioProducto FROM producto WHERE codigoProducto = " + txtCodigo.Text;
                    MySqlCommand cmd = new MySqlCommand(consulta, ConectarBD.Conectar());
                    cmd.Parameters.AddWithValue("codigoProducto", txtCodigo.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtProducto.Text = Convert.ToString(reader["nombreProducto"]);
                        lbPrecio.Text = Convert.ToString(reader["precioProducto"]);
                    }
                }
                 catch(Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                    
                }
            }
            else { limpiar(); }

        }
        //Metodo para eliminar el producto encontrado
        public void limpiar()
        {
            if (txtCodigo.TextLength == 0)
                txtProducto.Text = "";
            lbPrecio.Text = "";

        }

        //boton para colocar los productos
        private void btnColocar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto(txtCodigo.Text, txtProducto.Text, Convert.ToDouble(lbPrecio.Text));
            Detalle d = new Detalle(p, Convert.ToInt64(txtCantidad.Text));
            f.AddDetalle(d);
            lbTotalApagar.Text = f.GetTotalFacturado().ToString();
            dataProductos.Rows.Add(d.GetProducto().GetCodigo(), d.GetProducto().GetDescripcion(), d.GetCantidad(), d.GetProducto().GetPrecioVenta(), d.GetTotalDetalle());
        }
        //Boton para eliminar los productos
       private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                facturado = f.listDetalle();
                int fila = 0;
                string idProductoSelect = dataProductos[0, fila].Value.ToString();
                dataProductos.Rows.RemoveAt(fila);
                facturado.RemoveAt(fila);           
                lbTotalApagar.Text = f.GetTotalFacturado().ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("No existe Producto");
            }

        }
        //Boton de facturar
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {

                Factura();
                ProdFacturados();
            }
           
            
            
            

       }
        //Generador de la factura
        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder st = new StringBuilder();
            foreach (Detalle item in f.listDetalle())
	        {
                st.Append( "\n"+ item.GetProducto().GetDescripcion() + " \t\t     " + item.GetCantidad() + " \t\t      " + item.GetProducto().GetPrecioVenta() +" \t\t   " +item.GetTotalDetalle());
	        }
            MessageBox.Show("\t\t\t\t\tFECHA "+ f.GetFecha() +"\n\t\t\t SU FACTURA" +"\n\n<------------------------------------------------------------------>"+
                "\nProducto\t\t Cantidad\t\t precio\t\t Total" +"\n"+
                            st.ToString());



            Limpiar();
        }
        //Metodos para validar los campos
        public Boolean Validar()
        {
            return (txtCodigo.TextLength != 0 &
              txtProducto.TextLength != 0 &
             txtCantidad.TextLength != 0 &
             txtVendedor.TextLength != 0 &
             txtCliente.TextLength != 0);
           
        }
        //Metodos que envia a la base de datos los productos ya facturado
        private void ProdFacturados()
        {
            foreach (Detalle det in f.listDetalle())
            {
                consulta = "INSERT INTO detalles(numeroFactura, codigoProducto, descripcionProducto, precioProducto, cantidadProducto) VALUES( '" + Convert.ToInt32(txtNumero.Text) + "','" +
                                                                                                                                               det.GetProducto().GetCodigo() +"','" +
                                                                                                                                              det.GetProducto().GetDescripcion() + "','" +
                                                                                                                                             det.GetProducto().GetPrecioVenta() +"','"
                                                                                                                                                  + det.GetCantidad() +"')";
                conec.Ejecutar(consulta);
                ConectarBD.Desconectar();
                
            }
        }
        //Cantidad total de los productos por productos
        private double CantidadTotal()
        {
            double cantTotal = 0;

            foreach (Detalle item in f.listDetalle())
            {
                cantTotal += item.GetCantidad();
            }
            return cantTotal;
        }
        //Metodo que inserta a la base de datos la factura
        private void Factura()
        {
            ConectarBD.Conectar();

            consulta = "INSERT INTO facturas(numeroFactura, fecha, nombreVendedor, nombreCliente, totalProductos, totalPagado) VALUES( '" + Convert.ToInt32(txtNumero.Text) + "','" +
                                                                                                                                    Convert.ToDateTime(f.GetFecha()) + "','" +
                                                                                                                                     txtVendedor.Text + "','" +
                                                                                                                                    txtCliente.Text + "','" +
                                                                                                                                          CantidadTotal() + "','" +
                                                                                                                                     Convert.ToDouble(lbTotalApagar.Text) + "')";
                                                                                            
            conec.Ejecutar(consulta, "Los productos se han facturado");
            ConectarBD.Desconectar();
        }
        //Metodo para despues de facturar se limpia todo el contenido
        public void Limpiar()
        {

            txtCantidad.Text = "";
            txtCliente.Text = "";
            txtCodigo.Text = "";
            txtNumero.Text = "";

            txtProducto.Text = "";
            txtVendedor.Text = "";
            lbPrecio.Text = "";
            lbTotalApagar.Text = "";
                
            
            
        }
    }
}