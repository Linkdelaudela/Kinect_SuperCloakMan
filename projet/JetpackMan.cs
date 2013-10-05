using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projet
{
	public class JetpackMan : PersonnageAbstrait
	{
		/// <summary>
		/// 
		/// </summary>
		private double vitesse = 0;

		private double vitesseMaxMontee = -14;

		private double vitesseMaxDescente = 24;

		private GesteAbstrait geste;

		/// <summary>
		/// Compteur pour l'animation des personnages
		/// </summary>
		private int cptAnimation = 0;

		/// <summary>
		/// 
		/// </summary>
		public JetpackMan(GesteAbstrait g)
		{
			indiceSkin = 1;
			skin = String.Format("images/persoV2-{0}.png", indiceSkin);
			poids = 50;
			vitesseInitiale = 10;
			geste = g;
			positionX = 19;
			positionY = 410;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void move(Image personnage, Skeleton first, double gravityIntensity)
		{
			double val;
			
			//Si les mains
			if (geste.recognize(first)/*first.Joints[JointType.HandRight].Position.Y > first.Joints[JointType.ElbowRight].Position.Y*/)
			{
				if (positionY + vitesse < 470 - personnage.Height)
				{
					if (positionY + vitesse > 10)
						val = positionY + vitesse;
					else
						val = 10;
					positionY = val;
					if (vitesse < vitesseMaxDescente)
						vitesse += 0.8 * (gravityIntensity - (poids / 10));
				}
				else
				{
					positionY = 470 - personnage.Height;
					vitesse = 0;
				}
			}
			else
			{
				if (positionY + vitesse > 10)
				{
					if (positionY + vitesse < 470 - personnage.Height)
						val = positionY + vitesse;
					else
						val = 470 - personnage.Height;
					positionY = val;
					if (vitesse > vitesseMaxMontee)
						vitesse -= 0.5 * (gravityIntensity - (poids / 10));
				}
				else
				{
					positionY = (double)10;
					vitesse = 0;
				}
			}
			
			
			int modulo = 5;
			cptAnimation = (cptAnimation + 1) % modulo;
			if (cptAnimation == modulo - 1)
			{
				indiceSkin = indiceSkin % 3 + 1;
				skin = String.Format("images/persoV2-{0}.png", indiceSkin);
			}
		}
	}
}
