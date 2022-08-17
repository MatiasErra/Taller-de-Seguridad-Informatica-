using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerSeguridadInformatica.Dominio
{
    public class RegistroPromociones
    {
        private long _idPromocion;
        private long _idUsuario;
        private DateTime _fecha;

        public long IdPromocion { get => _idPromocion; set => _idPromocion = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
    
        public RegistroPromociones() { }
    }
}