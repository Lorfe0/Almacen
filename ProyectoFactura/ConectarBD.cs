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
    class ConectarBD
    {

        private static ConectarBD ins;
        private MySqlCommand cmd;

        private ConectarBD() { }

        //Patron singleton
        public static ConectarBD instancia()
        {
            if (ins == null)
                ins = new ConectarBD();
            return ins;
        }

        //string de coneccion a la base de datos, para conectarce
        public static MySqlConnection Conectar()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1;" +
                                                            "database=almacen;"+ 
                                                            "Uid=root;"+ 
                                                            "pwd=1234;");
            conectar.Open();
            return conectar;
        }
        
        //Metodo para cerrar la coneccion 
        public static MySqlConnection Desconectar()
        {
            MySqlConnection desconectar = new MySqlConnection("server = 127.0.0.1; database = almacen; Uid=root; pwd=1234;");
            desconectar.Close();
            return desconectar;
        }

        //Metodo para ejecutar consulta, recibe un string dependiendo de la consulta
        public void Ejecutar(string consultar, string mensj)
        {

            try
            {
                ConectarBD.Conectar();
                cmd = new MySqlCommand(consultar, ConectarBD.Conectar());
                cmd.ExecuteNonQuery();
                MessageBox.Show(mensj);
                ConectarBD.Desconectar();
            }
            catch (MySqlException myEx)
            {

                MessageBox.Show(myEx.Message);
            }


        }



        public void Ejecutar(string consultar)
        {
            ConectarBD.Conectar();
            cmd = new MySqlCommand(consultar, ConectarBD.Conectar());
            cmd.ExecuteNonQuery();
            ConectarBD.Desconectar();
        }

    }
}
