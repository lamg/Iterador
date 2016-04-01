using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EquipajesAdm
{
	public class BuscarEquipaje:Form
	{
		NumericUpDown dia, mes;
		Label ldia, lmes, lres;
		TextBox nEqp;
		Button bsc,add;
		Iterador.Departamento d;

		public BuscarEquipaje ()
		{
			d = Iterador.ControlEquipajes.Prueba ();
			
			Text = "Administrar equipaje";
			Width = 400;
			Height = 300;

			dia = new NumericUpDown ();
			dia.DecimalPlaces = 0;
			dia.Minimum = 1;
			dia.Maximum = 31;
			dia.Width = 40;
			dia.Height = 10;
			dia.Top = 10;
			dia.Left = 60;
			dia.Show ();

			ldia = new Label ();
			ldia.Text = "Día";
			ldia.Width = 20;
			ldia.Height = dia.Height;
			ldia.Top = dia.Top;
			ldia.Left = dia.Left - (ldia.Width + 20);
			ldia.Show ();

			mes = new NumericUpDown ();
			mes.DecimalPlaces = 0;
			mes.Minimum = 1;
			mes.Maximum = 12;
			mes.Width = dia.Width;
			mes.Height = dia.Height;
			mes.Top = dia.Top + dia.Height + 10;
			mes.Left = dia.Left;
			mes.Show ();

			lmes = new Label ();
			lmes.Text = "Mes";
			lmes.Width = 25;
			lmes.Height = mes.Height;
			lmes.Top = mes.Top;
			lmes.Left = mes.Left - (lmes.Width + 20);
			lmes.Show ();

			nEqp = new TextBox ();
			nEqp.Width = 60;
			nEqp.Height = dia.Height;
			nEqp.Top = dia.Top;
			nEqp.Left = dia.Left + nEqp.Width + 10;
			nEqp.GotFocus += (object sender, EventArgs e) => lres.Text = "";
			nEqp.Show ();

			lres = new Label ();
			//lres.Width = 60;
			lres.AutoSize = true;
			lres.Height = nEqp.Height;
			lres.Top = nEqp.Top;
			lres.Left = nEqp.Left + nEqp.Width + 10;

			lres.Show ();

			bsc = new Button ();
			bsc.Width = 60;
			bsc.Height = 20;
			bsc.Text = "Buscar";
			bsc.Top = Height - (bsc.Height + 40);
			bsc.Left = Width - (bsc.Width + 40);
			bsc.Click += Bsc_Click;
			bsc.Show ();

			add = new Button ();
			add.Width = bsc.Width;
			add.Height = bsc.Height;
			add.Text = "Añadir";
			add.Top = bsc.Top;
			add.Left = bsc.Left - (add.Width + 20);
			add.Click += Add_Click;
			add.Show ();

			Controls.Add (dia);
			Controls.Add (ldia);
			Controls.Add (mes);
			Controls.Add (lmes);
			Controls.Add (nEqp);
			Controls.Add (bsc);
			Controls.Add (lres);
			Controls.Add (add);
		}

		void Add_Click (object sender, EventArgs e)
		{
			var eqs = d.GetDepartamento((int)mes.Value-1,(int)dia.Value-1);
			var ne = new Iterador.Equipaje (nEqp.Text);
			string msg = "Añadido correctamente";
			if (eqs != null) {
				var ls = new List<Iterador.Equipaje> (eqs.GetEquipajes ());
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
			lres.Text = msg;


		}

		int Dia{
			get { return (int)dia.Value - 1;}
		}

		int Mes {
			get { return (int)mes.Value - 1;}
		}

		void Bsc_Click (object sender, EventArgs e)
		{
			bool r = Iterador.ControlEquipajes.BuscarEquipaje (nEqp.Text, Mes, Dia, d);
			lres.Text = String.Format ("El equipaje {0}ha sido encontrado", r ? "" : "no ");
		}
	}
}

