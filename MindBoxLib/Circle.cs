namespace MindBoxLib
{
	/// <summary>
	/// Круг
	/// </summary>
	public class Circle : IHasArea
	{
		/// <summary>
		/// Кешированное значение площади, чтобы не пересчитывать её при каждом запросе.
		/// </summary>
		private double _Area;
		public double Area => _Area;

		/// <summary>
		/// Значение радиуса
		/// </summary>
		private double _Radius;
		/// <summary>
		/// Радиус этого круга
		/// </summary>
		public double Radius
		{
			get => _Radius;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Radius)} should be greater than 0.");

				_Radius = value;
				RecomputeArea();
			}
		}

		/// <summary>
		/// Создать круг с указанным радиусом
		/// </summary>
		/// <param name="radius">Радиус создаваемого круга</param>
		public Circle(double radius)
		{
			Radius = radius;
		}

		/// <summary>
		/// Обновить значение площади.
		/// </summary>
		private void RecomputeArea()
		{
			_Area = Radius * Radius * Math.PI;
		}
	}
}
