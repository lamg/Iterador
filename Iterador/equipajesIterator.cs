using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    class equipajesIterator : Iterador
    {
        Equipaje[] equipajes;
        int position;
        public equipajesIterator(Equipaje[] equipajesarray)
        {
            this.equipajes = equipajesarray;
            position = 0;
        }

        public override object Current()
        {
            return equipajes[position];
        }

        public override object First()
        {
            return equipajes[0];
        }

        public override bool HasNext()
        {
            if (position < equipajes.Length)
                return true;
            return false;
        }

        public override void Next()
        {
            position++;
        }
    }
}
