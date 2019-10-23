using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido : IEquatable<Pedido>
    {
        public int NumPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
          public List<LineaPedido> LineasPedido { get; set; }
        public Pedido()
        {
        }

        public Pedido(int numPedido)
        {
            NumPedido = numPedido;
        }

        public Pedido(int numPedido, DateTime fecha, int idEmpleado) : this(numPedido)
        {
            Fecha = fecha;
            IdEmpleado = idEmpleado;
        
        }

        public Pedido(int numPedido, DateTime fecha, int idEmpleado,  List<LineaPedido> lineasPedido) : this(numPedido, fecha, idEmpleado)
        {
            LineasPedido = lineasPedido;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pedido);
        }

        public bool Equals(Pedido other)
        {
            return other != null && NumPedido == other.NumPedido;
        }

        public override int GetHashCode()
        {
            return -577621642 + NumPedido.GetHashCode();
        }
    }
}
