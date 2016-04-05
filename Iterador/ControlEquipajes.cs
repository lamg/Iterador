using System;

namespace Iterador
{
	public class ControlEquipajes
	{
		public static bool BuscarEquipaje(string nombre, int mes,int dia, Departamento d){
            mes--;
            dia--;
			var it = (departamentoIterator)d.crearIterador();
			bool e = false;//e == el equipaje existe en el segmento buscado
			it.Next();
			while (it.HasNext () && !e) {
				if (it.GetPositionM() == mes && it.GetPositionD() == dia) {
					var itE = (equipajesIterator)((Equipajes)it.Current ()).crearIterador ();
					while (itE.HasNext() && !e)
					{						
						e = (itE.Current () as Equipaje).GetIdentificador ().Equals (nombre);                        
						itE.Next();
					}
				}
				it.Next ();
			}
			return e;
		}

		public static Departamento Prueba(){
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
			d1.SetDepartamento(4,12,equipajes1);
			d1.SetDepartamento(3,30,equipajes2);
			d1.SetDepartamento(5,20,equipajes3);
			return d1;

		}

	}
}

