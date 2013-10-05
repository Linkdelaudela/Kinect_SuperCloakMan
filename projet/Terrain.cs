using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projet
{
	public class Terrain : INotifyPropertyChanged
	{
		/// <summary>
		/// Intensité de pesanteur du terrain
		/// </summary>
		public double gravityIntensity
		{
			get;
			set;
		}

		/// <summary>
		/// Décor du terrain
		/// </summary>
		public String background
		{
			get
			{
				return mbackground;
			}
			set
			{
				mbackground = value;
				OnPropertyChanged("background");
			}
		}
		private String mbackground;

		public Bonus bonus
		{
			get;
			private set;
		}

		public Malus malus
		{
			get;
			private set;
		}

		public Terrain()
		{
			background = "images/titre.png";
			gravityIntensity = 9.8;
			position = 0;
			vitesseTerrain = 10;
			length = 3200;
			screenWidth = 640;
			bonus = new Pièce();
		}

		public double position
		{
			get
			{
				return mPosition;
			}
			set
			{
				mPosition = value;
				OnPropertyChanged("position");
			}
		}
		private double mPosition;

		/// <summary>
		/// 
		/// </summary>
		private double vitesseTerrain;

		/// <summary>
		/// 
		/// </summary>
		private double length;

		/// <summary>
		/// 
		/// </summary>
		private double screenWidth;

		/// <summary>
		/// Permet de bouger l'Image correspondante dans le xaml
		/// </summary>
		/// <param name="fond"></param>
		public void move(PersonnageAbstrait player)
		{
			bonus.move(position,length,screenWidth,vitesseTerrain, player);
			//monstre.move(position);

			if (-position >= length - screenWidth)
				position = 0;
			else
				position -= vitesseTerrain;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}
	}
}
