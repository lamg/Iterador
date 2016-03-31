using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    class Departamento:Agregado 
    {
        Equipajes[,] equipajes;

       
        public Departamento()
        {
            equipajes = new Equipajes[12, 31];
            Equipaje aux = new Equipaje("");
            Equipaje[] aux2 = new Equipaje[1];
            aux2[0] = aux;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    equipajes[i, j] = new Equipajes(aux2);
                }
            }
           
        }

        public void SetDepartamento(int mes , int dia , Equipajes eq)
        {
            equipajes[mes, dia] = eq;
        }
        public Equipajes GetDepartamento(int mes, int dia)
        {
            return equipajes[mes, dia]; 
        }
        public override object crearIterador()
        {
            return new departamentoIterator(this.equipajes);
        }
    }
}
