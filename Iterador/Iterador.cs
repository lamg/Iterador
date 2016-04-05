using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    abstract class Iterador
    {

        public abstract bool HasNext();
        public abstract object First();
        public abstract void Next();
        public abstract object Current();

    }

}
