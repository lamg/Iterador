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
        int positionM, ind;
        int positionD;
		bool b;

        public departamentoIterator(Equipajes[,] matrix)
        {
            equipajes = matrix;
			ind = 0;
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
			return equipajes != null && b && positionM < equipajes.GetLength(0) && positionD < equipajes.GetLength(1);            
        }

        public override void Next()
        {
			b = false;
			while (!b && ind != equipajes.Length) {
				positionM = ind / equipajes.GetLength (1);
				positionD = ind % equipajes.GetLength (1);
				b = equipajes [positionM, positionD] != null;
				ind++;
			}

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
