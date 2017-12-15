using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFactura
{
    class Detalle
    {
            
            private Producto producto;
            private float Cantidad;
           
            public Detalle(Producto producto, float cantidad)
            {
                SetPrducto(producto);
                SetCantidad(cantidad);
            }
            public Detalle() { }
            //Metodo para reciibir el producto
            private void SetPrducto(Producto producto)
            {
                this.producto = producto;
            }

            //metodo que retorna el producto
            public Producto GetProducto()
            {
                    
                return producto;

            }

            public float GetCantidad()
            {
                return Cantidad;
            }

            private void SetCantidad(float cantidad)
            {
                this.Cantidad = cantidad;
            }

            //Metodo que recibe la cantidad y lo mult por el precio de venta del producto
            public double GetTotalDetalle()
            {
                return GetCantidad() * producto.GetPrecioVenta();

            }

        }
    }

