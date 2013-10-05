using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using Microsoft.Kinect;

namespace projet
{
	public abstract class PersonnageAbstrait : INotifyPropertyChanged
	{
		/// <summary>
		/// Vitesse initiale du personnage
		/// </summary>
		public double vitesseInitiale
		{
			get;
			set;
		}
		/// <summary>
		/// Poids du personnage
		/// </summary>
		public double poids
		{
			get;
			set;
		}

		/// <summary>
		/// Skin du personnage
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


		/// <summary>
		/// Indice de l'animation du skin du personnage
		/// </summary>
		public int indiceSkin
		{
			get;
			set;
		}

		/// <summary>
		/// Fais bouger le personnage
		/// </summary>
		public abstract void move(Image personnage, Skeleton first, double gravityIntensity);

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
