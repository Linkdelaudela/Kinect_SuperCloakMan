using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projet
{
	public abstract class Bonus : INotifyPropertyChanged
	{
		/// <summary>
		/// Skin du Bonus
		/// </summary>
		public String skin
		{
			get
			{
				return mSkin;
			}
			set
			{
				mSkin = value;
				OnPropertyChanged("skin");
			}
		}

		private String mSkin;

		public double positionX
		{
			get
			{
				return mPositionX;
			}
			set
			{
				mPositionX = value;
				OnPropertyChanged("positionX");
			}
		}
		private double mPositionX;

		public double positionY
		{
			get
			{
				return mPositionY;
			}
			set
			{
				mPositionY = value;
				OnPropertyChanged("positionY");
			}
		}
		private double mPositionY;

		private double vitesse = 1;
		/// <summary>
		/// Permet de bouger l'Image correspondante dans le xaml
		/// </summary>
		/// <param name="fond"></param>
		public void move(double posTer, double length, double screenWidth, double vitesseTerrain, PersonnageAbstrait player)
		{
			if (positionY >= 20 )
			{
				positionY -= vitesse;
				
			}
			if (positionY <= 480)
			{
				positionY += vitesse;
			}
			if (positionY <= 20)
			{
				positionY =20;

			}
			if (positionY >= 480)
			{
				positionY = 480;
			}

			if (-posTer >= length - screenWidth)
				positionX = 1800;
			else
			{
				positionX -= vitesseTerrain;
			}
		}

		public Bonus()
		{
			skin = "";
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
