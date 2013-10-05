using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
	public class MainsLevees : GesteAbstrait
	{
		public bool recognize(/*Skeleton lastSkeletonCaptured,*/ Skeleton first)
		{
			//Ecarts entre la position de la main et du coude, respectivement droit et gauche, 
			//pour le dernier skeleton tracké et le skeleton tracké actuellement
			float //varLastRight = lastSkeletonCaptured.Joints[JointType.HandRight].Position.Y - lastSkeletonCaptured.Joints[JointType.ElbowRight].Position.Y,
					varNewRight = first.Joints[JointType.HandRight].Position.Y - first.Joints[JointType.ElbowRight].Position.Y,
					//varLastLeft = lastSkeletonCaptured.Joints[JointType.HandLeft].Position.Y - lastSkeletonCaptured.Joints[JointType.ElbowLeft].Position.Y,
					varNewLeft = first.Joints[JointType.HandLeft].Position.Y - first.Joints[JointType.ElbowLeft].Position.Y;

			if ((/*varLastRight < 0 &&*/ varNewRight < 0) && (/*varLastRight > 0 &&*/ varNewLeft < 0))
			{
				//if ((varLastLeft > 0 && varNewLeft < 0) || (varLastLeft < 0 && varNewLeft > 0))
				return true;
			}
			return false;
		}
	}
}
