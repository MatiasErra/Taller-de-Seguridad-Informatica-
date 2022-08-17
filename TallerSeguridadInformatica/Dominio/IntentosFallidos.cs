using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerSeguridadInformatica.Dominio
{
    public class IntentosFallidos
    {
        private DateTime _fecha;
        private long _idUsuario;

        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        public IntentosFallidos() { }
    }
}