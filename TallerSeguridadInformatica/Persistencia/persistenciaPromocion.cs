using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SeguridadInformatica.Dominio;
using TallerSeguridadInformatica.Dominio;

namespace SeguridadInformatica.Persistencia
{

    public class persistenciaPromocion : Conexion
    {

        public static List<Promocion> ObtenerPromociones()
        {
            List<Promocion> listaPromociones = new List<Promocion>();

            Promocion promocion;
            using (SqlConnection conexionSQL = Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerPromociones", conexionSQL);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            promocion = new Promocion();
                            promocion.Id = long.Parse(reader["Id"].ToString());
                            promocion.Titulo = reader["Titulo"].ToString();
                            promocion.Descripcion = reader["Descripcion"].ToString();
                            promocion.PrecioOriginal = double.Parse(reader["PrecioOriginal"].ToString());
                            promocion.PrecioPromocion = double.Parse(reader["PrecioPromocion"].ToString());
                            promocion.Descuento = int.Parse(reader["PorcentajeDescuento"].ToString());
                            promocion.Imagen = reader["Imagen"].ToString();
                            promocion.Detalles = reader["DetallesOferta"].ToString();
                            promocion.Condiciones = reader["Condiciones"].ToString();
                            listaPromociones.Add(promocion);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }
            }
            return listaPromociones;
        }
        public static bool AltaPromocion(Promocion pPromocion)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaPromocion", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", pPromocion.Id));
                cmd.Parameters.Add(new SqlParameter("@Titulo", pPromocion.Titulo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pPromocion.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@PrecioOriginal", pPromocion.PrecioOriginal));
                cmd.Parameters.Add(new SqlParameter("@PrecioPromocion", pPromocion.PrecioPromocion));
                cmd.Parameters.Add(new SqlParameter("@PorcentajeDescuento", pPromocion.Descuento));
                cmd.Parameters.Add(new SqlParameter("@Imagen", pPromocion.Imagen));
                cmd.Parameters.Add(new SqlParameter("@DetallesOferta", pPromocion.Detalles));
                cmd.Parameters.Add(new SqlParameter("@Condiciones", pPromocion.Condiciones));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception)
            {
                return false;
            }

            return resultado;

        }
        
    }

}
