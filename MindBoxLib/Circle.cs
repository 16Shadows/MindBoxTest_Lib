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

		private bool _AreaHasChanged;
		protected void MarkAreaDirty()
		{
			_AreaHasChanged = true;
		}

		public double Area
		{
			get
			{
				if (_AreaHasChanged)
					_Area = Radius * Radius * Math.PI;
				return _Area;
			}
		}

		/// <summary>
		/// Значение радиуса
		/// </summary>
		private double _Radius;
		/// <summary>
		/// Радиус этого круга
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Будет брошено, если радиус меньше или равен 0.</exception>
		public double Radius
		{
			get => _Radius;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Radius)} should be greater than 0.");

				_Radius = value;
				MarkAreaDirty();
			}
		}

		/// <summary>
		/// Создать круг с указанным радиусом
		/// </summary>
		/// <param name="radius">Радиус создаваемого круга</param>
		/// <exception cref="ArgumentOutOfRangeException">Будет брошено, если радиус меньше или равен 0.</exception>
		public Circle(double radius)
		{
			Radius = radius;
		}
	}
}
