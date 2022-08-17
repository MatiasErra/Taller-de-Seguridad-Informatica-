using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguridadInformatica.Persistencia;
using TallerSeguridadInformatica.Dominio;

namespace SeguridadInformatica.Dominio
{
  public class Controladora
    {
        public List<Usuario> ObtenerUsuarios()
        {
            return persistenciaUsuario.ObtenerUsuarios();
        }
        public List<Promocion> ObtenerPromociones()
        {
            return persistenciaPromocion.ObtenerPromociones();
        }
        public List<IntentosFallidos> ObtenerIntentos()
        {
            return persistenciaUsuario.ObtenerIntentos();
        }

        public bool AltaIntentos(IntentosFallidos intFall)
        {
            return persistenciaUsuario.AltaIntentos(intFall);
        }
        public bool AltaUsuario(Usuario pUsuario)
        {
            return persistenciaUsuario.AltaUsuario(pUsuario);
        }
        public bool AltaPromocion(Promocion pPromocion)
        {
            return persistenciaPromocion.AltaPromocion(pPromocion);
        }
        public bool AltaAudit(Auditoria pAudit)
        {
            return persistenciaUsuario.AltaAduitoria(pAudit);
        }
    }
}
