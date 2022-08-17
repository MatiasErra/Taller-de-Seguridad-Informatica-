using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SeguridadInformatica.Dominio;
using TallerSeguridadInformatica.Dominio;

namespace SeguridadInformatica.Persistencia
{ 
    public class persistenciaUsuario : Conexion
    {
        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            Usuario usuario;
            using (SqlConnection conexionSQL = Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerUsuarios", conexionSQL);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = long.Parse(reader["Id"].ToString());
                            usuario.Nombre = reader["Usuario"].ToString();
                            usuario.Contraseña = reader["Contrasenia"].ToString();
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }
            }
            return listaUsuarios;
        }
        public static bool AltaUsuario(Usuario pUsuario)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", pUsuario.Id));
                cmd.Parameters.Add(new SqlParameter("@Usuario", pUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Contrasenia", pUsuario.Contraseña));

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
        public static bool AltaIntentos(IntentosFallidos intFall)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaIntentos", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@fecha", intFall.Fecha));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", intFall.IdUsuario));
                

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

        public static List<IntentosFallidos> ObtenerIntentos()
        {
            List<IntentosFallidos> listaIntentos = new List<IntentosFallidos>();

            IntentosFallidos intFall;
            using (SqlConnection conexionSQL = Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerIntentos", conexionSQL);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            intFall = new IntentosFallidos();
                            intFall.IdUsuario = long.Parse(reader["idUsuario"].ToString());
                            intFall.Fecha = DateTime.Parse(reader["fecha"].ToString());
                            listaIntentos.Add(intFall);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());

                }
            }
            return listaIntentos;
        }

        public static bool AltaAduitoria(Auditoria audit)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaAudit", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdUsuario", audit.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@Mensaje", audit.Mensaje));

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

