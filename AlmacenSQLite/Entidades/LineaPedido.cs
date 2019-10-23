using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LineaPedido : IEquatable<LineaPedido>
    {
       
        public int NumPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public LineaPedido()
        {
        }

        public LineaPedido(int numPedido, int idProducto)
        {
            NumPedido = numPedido;
            IdProducto = idProducto;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LineaPedido);
        }

        public bool Equals(LineaPedido other)
        {
            return other != null &&
                   NumPedido == other.NumPedido &&
                   IdProducto == other.IdProducto;
        }

        public override int GetHashCode()
        {
            var hashCode = 335445878;
            hashCode = hashCode * -1521134295 + NumPedido.GetHashCode();
            hashCode = hashCode * -1521134295 + IdProducto.GetHashCode();
            return hashCode;
        }
    }
}
