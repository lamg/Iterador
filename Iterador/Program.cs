using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterador
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipaje eq1 = new Equipaje("Equipaje 1");
            Equipaje eq2 = new Equipaje("Equipaje 2");
            Equipaje eq3 = new Equipaje("Equipaje 3");
            Equipaje eq4 = new Equipaje("Equipaje 4");
            Equipaje eq5 = new Equipaje("Equipaje 5");

            Equipaje[] array1 = new Equipaje[2];
            array1[0] = eq1;
            array1[1] = eq2;
            Equipaje[] array2 = new Equipaje[2];
            array2[0] = eq3;
            array2[1] = eq4;
            Equipaje[] array3 = new Equipaje[1];
            array3[0] = eq5;

            Equipajes equipajes1 = new Equipajes(array1);
            Equipajes equipajes2 = new Equipajes(array2);
            Equipajes equipajes3 = new Equipajes(array3);	


            Departamento d1 = new Departamento();
            d1.SetDepartamento(3,12,equipajes1);
            d1.SetDepartamento(2,30,equipajes2);
            d1.SetDepartamento(5,20,equipajes3);

            //Valores para la busquedad
            int dia = 30;
            int mes = 2;
            //Equipaje equipajebuscado = new Equipaje("Equipaje 4");
            string equipajebuscados = "Equipaje 4";
            departamentoIterator iteradorD = (departamentoIterator)d1.crearIterador();
     

            while (iteradorD.HasNext())
            {
                if (iteradorD.GetPositionM() == mes && iteradorD.GetPositionD() == dia)
                {
                    equipajesIterator iteradorE = (equipajesIterator)((Equipajes)iteradorD.Current()).crearIterador();
					bool e = false;//e == el equipaje existe en el segmento buscado
                    while (iteradorE.HasNext() && !e)
                    {
						e = (iteradorE.Current () as Equipaje).GetIdentificador ().Equals (equipajebuscados);                        
                        iteradorE.Next();
                    }
					Console.WriteLine ("El equipaje {0}ha sido encontrado", e ? "" : "no ");
                   
                }
                iteradorD.Next();
            }
           
            //Como quitar clase Equipajes , Como controlar los null
        }
    }
}
