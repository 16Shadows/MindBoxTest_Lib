namespace MindBoxLib
{
	public static class DoubleExtensions
	{
		/// <summary>
		/// Проверяет, равны ли два значения с учётом некоторой допустимой разницы между ними
		/// </summary>
		/// <param name="a">Первое значение</param>
		/// <param name="b">Второе значение</param>
		/// <returns>True, если значения приблизительно равны, false иначе</returns>
		public static bool AlmostEquals(this double a, double b)
		{
			//Берём своё значение эпсилона (1E-15, т.к. double имеет приблизительную точность в 15-17 символов) и скейлим его под порядок величины большего из значений.
			double epsilon = Math.Max(Math.Abs(a), Math.Abs(b)) * 1E-15;
			return Math.Abs(a - b) < epsilon; //Сравниваем разницу между значениями с полученным эпсилоном
		}
		
		/// <summary>
		/// Проверяет, равны ли два значения с учётом некоторой допустимой разницы между ними после усечения из до n знаков после запятой.
		/// </summary>
		/// <param name="a">Первое значение</param>
		/// <param name="b">Второе значение</param>
		/// <param name="digits">Количество допустимых знаков после запятой</param>
		/// <returns>True, если значения приблизительно равны, false иначе</returns>
		public static bool AlmostEquals(this double a, double b, int digits)
		{
			return AlmostEquals(Floor(a, digits), Floor(b, digits));
		}

		/// <summary>
		/// Округляет вниз (усекает) значение до указанного числа знаков после запятой
		/// </summary>
		/// <param name="a">Значение</param>
		/// <param name="digits">Количество знаков после запятой</param>
		/// <returns>Усечённое значение</returns>
		private static double Floor(double a, int digits)
		{
			double correctABy = a - Math.Round(a, digits);
			return a - (correctABy >= 0 ? correctABy : Math.Pow(10, -digits) + correctABy);
		}
	}
}
