using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguridadInformatica.Dominio
{
 public class Conexion
    {
        protected static string CadenaDeConexion
        {
            get
            {
                return @"Server=DESKTOP-0P9DIB8\SQLEXPRESS;Initial Catalog=SeguridadInformatica; Integrated Security=True";
            }
        
        }

        public static SqlConnection Conectar()
        {
            SqlConnection conectar = new SqlConnection(CadenaDeConexion);
            try
            {
                conectar.Open();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return conectar;
        }
    }

}

