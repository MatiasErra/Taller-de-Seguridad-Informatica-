using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeguridadInformatica.Dominio
{
   public class Promocion
    {
        private long _id;
        private string _titulo;
        private string _producto;
        private string _descripcion;
        private double _precioOriginal;
        private double _precioPromocion;
        private int _descuento;
        private string _imagen;
        private string _detalles;
        private string _condiciones;

        public long Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double PrecioOriginal { get => _precioOriginal; set => _precioOriginal = value; }
        public double PrecioPromocion { get => _precioPromocion; set => _precioPromocion = value; }
        public int Descuento { get => _descuento; set => _descuento = value; }
        public string Imagen { get => _imagen; set => _imagen = value; }
        public string Detalles { get => _detalles; set => _detalles = value; }
        public string Condiciones { get => _condiciones; set => _condiciones = value; }
        public string Producto { get => _producto; set => _producto = value; }

        public Promocion() { }
    }
}
