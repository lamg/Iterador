using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    class departamentoIterator:Iterador
    {
        Equipajes[,] equipajes;
        int positionM;
        int positionD;
        public departamentoIterator(Equipajes[,] matrix)
        {
            equipajes = matrix;
            positionM = 0;
            positionD = 0;
        }

        public override object Current()
        {
            return equipajes[positionM,positionD];
        }

        public override object First()
        {
           return equipajes[0,0];
        }

        public override bool HasNext()
        {
            if (positionM < equipajes.GetLength(0) && positionD < equipajes.GetLength(1))
                return true;
            return false;
        }

        public override void Next()
        {
            if (positionD == 30)
            {
                positionD = 0;
                positionM++;
            }
            positionD++;
        }
       
        public int GetPositionM()
        {
            return positionM;
        }
        public int GetPositionD()
        {
            return positionD;
        }
    }
}
