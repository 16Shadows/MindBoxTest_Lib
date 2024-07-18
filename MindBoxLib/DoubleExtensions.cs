using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxLib
{
	internal static class DoubleExtensions
	{
		public static bool AlmostEquals(this double a, double b)
		{
			double epsilon = Math.Max(Math.Abs(a), Math.Abs(b)) * 1E-15;
			return Math.Abs(a - b) < epsilon;
		}
	}
}
