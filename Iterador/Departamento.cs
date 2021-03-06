﻿using System;

namespace Iterador
{
    public class Departamento:Agregado 
    {
        Equipajes[,] equipajes;

       
        public Departamento()
        {
            equipajes = new Equipajes[12, 31];
            /*Equipaje aux = new Equipaje("");
            Equipaje[] aux2 = new Equipaje[1];
            aux2[0] = aux;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    equipajes[i, j] = new Equipajes(aux2);
                }
            }*/
           
        }

        public void SetDepartamento(int mes , int dia , Equipajes eq)
        {
            equipajes[mes-1, dia-1] = eq;
        }
        public Equipajes GetDepartamento(int mes, int dia)
        {
            return equipajes[mes-1, dia-1];
        }
        public override object crearIterador()
        {
            return new departamentoIterator(this.equipajes);
        }
    }
}
