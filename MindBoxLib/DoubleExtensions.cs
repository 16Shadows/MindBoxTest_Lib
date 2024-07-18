namespace MindBoxLib
{
	public static class DoubleExtensions
	{
		public static bool AlmostEquals(this double a, double b)
		{
			double epsilon = Math.Max(Math.Abs(a), Math.Abs(b)) * 1E-15;
			return Math.Abs(a - b) < epsilon;
		}

		public static bool AlmostEquals(this double a, double b, int digits)
		{
			return AlmostEquals(Floor(a, digits), Floor(b, digits));
		}

		private static double Floor(double a, int digits)
		{
			double correctABy = a - Math.Round(a, digits);
			return a - (correctABy >= 0 ? correctABy : Math.Pow(10, -digits) + correctABy);
		}
	}
}
