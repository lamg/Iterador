using System;

namespace Iterador
{
    class Program
    {
        static void Main(string[] args)
        {
			var d1 = ControlEquipajes.Prueba ();
			//Valores para la busquedad
			int dia = 30;
			int mes = 2;
			string equipajebuscados = "Equipaje 4";
			bool e = ControlEquipajes.BuscarEquipaje (equipajebuscados, mes, dia, d1);
            Console.WriteLine ("El equipaje {0}ha sido encontrado", e ? "" : "no ");
            
           
            //Como quitar clase Equipajes , Como controlar los null
        }
    }
}
