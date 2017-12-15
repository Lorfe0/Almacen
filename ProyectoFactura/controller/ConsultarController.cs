using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace ProyectoFactura.controller
{
   
    class ConsultarController
    {

        ConectarBD inst = ConectarBD.instancia();
        
        
        


       
        public void consultarUsuario(Model.cuenta cuenta )
        {
            string consulta = "SELECT contra from cuenta where usu =  " + cuenta.usuario;

            


            
           
        }
        

    }
}
