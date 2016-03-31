using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    class Equipaje
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
    }
}
