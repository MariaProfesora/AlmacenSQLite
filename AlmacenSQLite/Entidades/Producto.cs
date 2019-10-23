using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IEquatable<Producto>
    {
       
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }


        public Producto()
        {
        }

        public Producto(int id, string descripcion, double precio, int stock) : this(id)
        {
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }

        public Producto(int id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Producto);
        }

        public bool Equals(Producto other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
