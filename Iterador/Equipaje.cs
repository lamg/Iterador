using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    public class Equipaje
    {
        string identificador;

        public Equipaje(string identificador)
        {
            this.identificador = identificador;
        }
        public string GetIdentificador()
        {
            return identificador;
        }

		public override bool Equals (object obj)
		{
			return obj as Equipaje != null && obj.ToString () == identificador;
		}

		public override int GetHashCode ()
		{
			return identificador.GetHashCode ();
		}

		public override string ToString ()
		{
			return identificador;
		}
    }
}
