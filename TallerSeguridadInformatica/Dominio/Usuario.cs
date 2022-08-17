using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace SeguridadInformatica.Dominio
{
   public class Usuario
    {
            private long _id; 
            private string _nombre;
            private string _contraseña;

            public long Id { get => _id;  set => _id = value; }
            public string Nombre { get => _nombre; set => _nombre = value; }
            public string Contraseña { get => _contraseña; set => _contraseña = value; }
        
            public Usuario() { }
      
        }
    }

