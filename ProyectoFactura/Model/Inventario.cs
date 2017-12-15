using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
namespace ProyectoFactura
{
    class Inventario
    {
        //lista para gestionar los productos.
        private static List<Producto> producto = new List<Producto>();
        private string consultar;
        //conect: la instancia del patron singleton
        ConectarBD conect = ConectarBD.instancia();


        static Inventario()
        {
            producto = new List<Producto>();
        }

        //Metodo para agregar un producto al inventario, recibe un producto y lo inserta a la base de datos
        public void AddProducto(Producto p)
        {
            producto.Add(p);
            consultar = "INSERT INTO producto(codigoProducto, nombreProducto, precioProducto) VALUES( '" + p.GetCodigo() + "','" +
                                                                                                        p.GetDescripcion() + "','" +
                                                                                                        Convert.ToDouble(p.GetPrecioVenta()) + "')";
            //metodo de consulta, y recibe el string indicado
            conect.Ejecutar(consultar, "Se agrego el producto");
        }

        //Metodo para buscar un producto
        public Producto GetProducto(Producto p)
        {
            try
            {
            ConectarBD.Conectar();
                        consultar = "SELECT  nombreProducto, precioProducto FROM producto WHERE codigoProducto = " + p.GetCodigo();

                MySqlCommand cmd = new MySqlCommand(consultar, ConectarBD.Conectar());
                cmd.Parameters.AddWithValue("codigoProducto", p.GetCodigo());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    Producto pr = new Producto(p.GetCodigo(), Convert.ToString(reader["nombreProducto"]), Convert.ToDouble(reader["precioProducto"]));
                    return pr;
                }
                    ConectarBD.Desconectar();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            return p;
            //consultar = "Select nombreProducto FROM producto WHERE idProducto = " + p.GetCodigo();

            //MySqlCommand cmd = new MySqlCommand(consultar, ConectarBD.Conectar());
            //cmd.Parameters.AddWithValue("codigoProducto", p.GetCodigo());
            //MySqlDataReader reader = cmd.ExecuteReader();
            //return reader;
        }

        //Metodo para EDITAR o actualizar un producto
        public void Actualizar(Producto p)
        {
           
            ConectarBD.Conectar();
            consultar = "UPDATE producto SET nombreProducto = '" + p.GetDescripcion() +
                                        "', precioProducto = '" + p.GetPrecioVenta() +
                                        "' WHERE codigoProducto = '" + p.GetCodigo() + "'";

            conect.Ejecutar(consultar, "El producto se modifico ");

            ConectarBD.Desconectar();
}

        //Metodo para ELIMINAR un producto
        public void Eliminar(Producto p)
        {
            //Para remover el producto seleccionado
            foreach (Producto item in producto)
            {
                producto.Remove(p);
            }
            consultar = "Delete FROM producto WHERE codigoProducto = " + p.GetCodigo();
            conect.Ejecutar(consultar, "se elimino el producto");
        }
    }
}


