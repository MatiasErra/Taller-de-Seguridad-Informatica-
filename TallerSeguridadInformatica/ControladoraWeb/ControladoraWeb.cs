using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeguridadInformatica.Dominio;
using TallerSeguridadInformatica.Dominio;

namespace TallerSeguridad.ControladoraWeb
{
    public class ControladoraWeb
    {
        Controladora unaControladora = new Controladora();

        public List<Usuario> listarUsuarios()
        {
            return unaControladora.ObtenerUsuarios();
        }

        public List<Promocion> listarPromociones()
        {
            return unaControladora.ObtenerPromociones();
        }

        public List<IntentosFallidos> listarIntentos()
        {
            return unaControladora.ObtenerIntentos();
        }

        public bool altaUsuario(string pNombre, string pContraseña)
        {
            Usuario pUsuario = new Usuario();
            Random rnd = new Random();
            long randomN = long.Parse(rnd.Next(10000000, 99999999).ToString() + rnd.Next(10000000, 99999999).ToString());
            List<Usuario> listaU = listarUsuarios();
            int cont = 0;
            while (cont == 0)
            {
                int cont2 = 0;
                foreach (Usuario unUsuario in listaU)
                {
                    if (randomN == unUsuario.Id)
                    {
                        cont2++;
                    }
                }
                if (cont2 == 0)
                {
                    cont = 1;
                }
                else
                {
                    randomN = long.Parse(rnd.Next(10000000, 99999999).ToString() + rnd.Next(10000000, 99999999).ToString());
                }
            }

            pUsuario.Id = randomN;
            pUsuario.Nombre = pNombre;
            pUsuario.Contraseña = pContraseña;
            if (unaControladora.AltaUsuario(pUsuario))
            {
                if(altaAudit(pUsuario.Id, "Se ah creado un nuevo usuario"))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        public bool altaPromocion(string pTitulo, string pDesc, double pPrecioO, double pPrecioP, int pDescuento, string pImagen, string pDetalles, string pCondiciones)
        {
            Promocion pPromocion = new Promocion();
            Random rnd = new Random();
            long randomN = long.Parse(rnd.Next(10000000, 99999999).ToString() + rnd.Next(10000000, 99999999).ToString());
            List<Promocion> listaP = listarPromociones();
            int cont = 0;
            while (cont == 0)
            {
                int cont2 = 0;
                foreach (Promocion unaPromocion in listaP)
                {
                    if (randomN == unaPromocion.Id)
                    {
                        cont2++;
                    }
                }
                if (cont2 == 0)
                {
                    cont = 1;
                }
                else
                {
                    randomN = long.Parse(rnd.Next(10000000, 99999999).ToString() + rnd.Next(10000000, 99999999).ToString());
                }
            }

            pPromocion.Id = randomN;
            pPromocion.Titulo = pTitulo;
            pPromocion.Descripcion = pDesc;
            pPromocion.PrecioOriginal = pPrecioO;
            pPromocion.PrecioPromocion = pPrecioP;
            pPromocion.Descuento = pDescuento;
            pPromocion.Imagen = pImagen;
            pPromocion.Detalles = pDetalles;
            pPromocion.Condiciones = pCondiciones;
            if (unaControladora.AltaPromocion(pPromocion))
            {
                string IdUsuario = System.Web.HttpContext.Current.Session["userId"].ToString();
                if (altaAudit(long.Parse(IdUsuario), "Se ah creado la Promocion "+ pPromocion.Id))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        public bool altaIntentos(long pIdUsuario)
        {
            IntentosFallidos intFall = new IntentosFallidos();
            intFall.Fecha = DateTime.Now;
            intFall.IdUsuario = pIdUsuario;
            if (unaControladora.AltaIntentos(intFall))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool altaAudit(long pIdUsuario, string pMensaje)
        {
            Auditoria audit = new Auditoria();   
            audit.IdUsuario = pIdUsuario;
            audit.Mensaje = pMensaje;
            if (unaControladora.AltaAudit(audit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}