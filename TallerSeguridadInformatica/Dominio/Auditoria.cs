using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerSeguridadInformatica.Dominio
{
    public class Auditoria
    {
        private long _idUsuario;
        private string _mensaje;

        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }

        public Auditoria() { }
    }
}