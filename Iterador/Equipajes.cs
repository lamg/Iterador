using System;

namespace Iterador
{
    public class Equipajes:Agregado
    {
        Equipaje[] equipajes;

        public Equipajes(Equipaje[] equipajes)
        {
            this.equipajes = equipajes;
        }

        public Equipaje[] EquipajesL
        {
            get { return equipajes; }
            set { equipajes = value; }

        }
        public void SetEquipajes(int pos , Equipaje equip)
        {
            equipajes[pos] = equip;
        }
        public override object crearIterador()
        {
            return new equipajesIterator(this.equipajes);
        }
        public bool ExistsEquip(Equipaje equip)
        {
			//equipajes no contiene al menos un nulo
			bool b = true;
            for (int i = 0; i != equipajes.Length && b; i++)
            {
				b = equip != null && equipajes [i].GetIdentificador ().Equals (equip.GetIdentificador ());                
            }
            return b;
        }
    }
}
