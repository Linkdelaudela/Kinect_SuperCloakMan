using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
	public interface GesteAbstrait
	{
		/// <summary>
		/// Rend vrai si le geste a été reconnu
		/// </summary>
		/// <returns></returns>
		bool recognize(/*Skeleton lastSkeletonCaptured,*/ Skeleton first);
	}
}
