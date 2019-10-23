using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : IEquatable<Empleado>
    {
        public int Id { get; set; }
        public String Nombre { get; set; }


        public Empleado()
        {
        }

        public Empleado(int id, string nombre) : this(id)
        {
            Nombre = nombre;
        }

        public Empleado(int id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Empleado);
        }

        public bool Equals(Empleado other)
        {
            return other != null && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
