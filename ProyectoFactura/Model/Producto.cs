using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFactura
{
    class Producto
    {
        private string codigo;
        private string descripcion;
        private double precio;

        public Producto(string codigo, string descripcion, double precio)
        {
            SetCodigo(codigo);
            SetDescripcion(descripcion);
            SetPrecio(precio);
        }

        public Producto(string codigo, string descripcion)
        {
            SetCodigo(codigo);
            SetDescripcion(descripcion);
        }

        public void SetCodigo(string codigo)
        {
            this.codigo = codigo;
        }

        private void SetPrecio(double precio)
        {
            this.precio = precio;
        }

        public string GetCodigo()
        {

            return codigo;
        }

        public string GetDescripcion()
        {
            return descripcion;
        }

        private void SetDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public double GetPrecioVenta()
        {
            
            return precio;

        }

    }
}
