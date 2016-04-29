using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EquipajesAdm
{
	public class BuscarEquipaje:Form
	{
		TextBox nEqp;
		Button bsc,add, del;
		Iterador.Departamento d;
        MonthCalendar cal;
        ListView lv;

		public BuscarEquipaje ()
		{
			d = Iterador.ControlEquipajes.Prueba ();
			
			Text = "Administrar equipaje";
			Width = 500;
			Height = 300;

            cal = new MonthCalendar();        
            cal.MinDate = new DateTime(2015, 1, 1);
            cal.MaxDate = new DateTime(2015, 12, 31);
            cal.ShowToday = false;
            cal.Top = 10;
            cal.Left = 20;
            cal.DateSelected += Cal_DateSelected;
            cal.Show();

            lv = new ListView();
            lv.Top = cal.Top;
            lv.Left = cal.Left + cal.Width + 30;
            lv.Width = 192;
            lv.Height = 162;
            lv.View = View.List;
            lv.Show();

            nEqp = new TextBox ();
			nEqp.Width = lv.Width;
			nEqp.Height = 10;
			nEqp.Top = cal.Top + cal.Height + 20;
			nEqp.Left = lv.Left;
			nEqp.Show ();

			bsc = new Button ();
			bsc.Width = 60;
			bsc.Height = 20;
			bsc.Text = "Buscar";
			bsc.Top = nEqp.Top + nEqp.Height + 30;
			bsc.Left = lv.Left;
			bsc.Click += Bsc_Click;
			bsc.Show ();

			add = new Button ();
			add.Width = bsc.Width;
			add.Height = bsc.Height;
			add.Text = "Añadir";
			add.Top = bsc.Top;
			add.Left = bsc.Left + bsc.Width + 10;
			add.Click += Add_Click;
			add.Show ();

            del = new Button();
            del.Text = "Borrar";
            del.Height = bsc.Height;
            del.Width = bsc.Width;
            del.Top = bsc.Top;
            del.Left = add.Left + add.Width + 10;
            del.Click += Del_Click;
            del.Show();

            Controls.Add(lv);
            Controls.Add(cal);
		    Controls.Add (nEqp);
			Controls.Add (bsc);
			Controls.Add (add);
            Controls.Add(del);
		}

        private void Del_Click(object sender, EventArgs e)
        {            
            var qs = new List<Iterador.Equipaje>(d.GetDepartamento(Mes, Dia).EquipajesL);
            
            foreach (var i in lv.SelectedIndices)
            {
                lv.Items.RemoveAt((int)i);
                qs.RemoveAt((int)i);
            }
            d.SetDepartamento(Mes, Dia, new Iterador.Equipajes(qs.ToArray()));
            nEqp.Clear();
        }

        private void Cal_DateSelected(object sender, DateRangeEventArgs e)
        {
            Mes = e.Start.Month;
            Dia = e.Start.Day;
            FillList();
        }

        void FillList() {
            lv.Items.Clear();
            var eqs = d.GetDepartamento(Mes, Dia);
            if (eqs != null)
            {
                var ls = eqs.EquipajesL;
                foreach (var i in ls)
                {
                    lv.Items.Add(i.ToString());
                }
            }
        }

        void Add_Click (object sender, EventArgs e)
		{
			var eqs = d.GetDepartamento(Mes,Dia);
			var ne = new Iterador.Equipaje (nEqp.Text);
			string msg = "Añadido correctamente";
			if (eqs != null) {
				var ls = new List<Iterador.Equipaje> (eqs.EquipajesL);
				if (!ls.Contains (ne)) {
					ls.Add (ne);
				} else {
					msg = "Equipaje reportado anteriormente";
				}
				eqs = new Iterador.Equipajes (ls.ToArray ());
			} else {
				eqs = new Iterador.Equipajes (new Iterador.Equipaje[]{ ne });
			}
			d.SetDepartamento (Mes, Dia, eqs);
            FillList();
			MessageBox.Show(msg);
            nEqp.Clear();

        }

		int Dia{
            get; set;
		}

		int Mes {
            get; set;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BuscarEquipaje
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BuscarEquipaje";
            this.ResumeLayout(false);

        }

        void Bsc_Click (object sender, EventArgs e)
		{
			bool r = Iterador.ControlEquipajes.BuscarEquipaje (nEqp.Text, Mes, Dia, d);
			MessageBox.Show(String.Format ("El equipaje {0}ha sido encontrado", r ? "" : "no "));
            nEqp.Clear();
        }
	}
}

