using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFactura
{
    class Factura
    {
        private int Numero;
        private string nombreCliente;
        private string fecha;
        private string nombreVendedor;

        //Lista para los detalle
        private List<Detalle> detalle = new List<Detalle>();
       
        public Factura(int numero, string nombreCliente, string nombreVendedor)
        {
            SetNumero(numero);
            SetNombreCliente(nombreCliente);
            SetNombreVendedor(nombreVendedor);

        }

        public Factura() { }
        //Metodo para AGREGAR un detalle, 
        public void AddDetalle(Detalle det)
        {
               detalle.Add(det);
               
        }

        //Metodo para retornar la lista 
        public List<Detalle> listDetalle()
        {
            return detalle;
        }

        //Metodo para Obtener el total Facturado
        public double GetTotalFacturado()
        {
            double total  = 0;
            foreach (Detalle det in detalle)
            {
                 total += det.GetTotalDetalle();
            }

            return total;
        }

        private void SetNumero(int numero)
        {

            this.Numero = numero;
        }

        private void SetNombreCliente(string nombreCliente)
        {
            this.nombreCliente = nombreCliente;
        }

        private void SetNombreVendedor(string nombreVendedor)
        {
            this.nombreVendedor = nombreVendedor;
        }

        //Metodo para obtener la fecha
        public string GetFecha()
        {
            fecha = DateTime.Now.ToShortDateString();
            return fecha;

            
        }

        
    }
    }
