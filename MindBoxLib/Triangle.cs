using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxLib
{
	/// <summary>
	/// Треугольник
	/// </summary>
	public class Triangle : IHasArea
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
				{
					//Прямоугольный треугольник, где C - гипотенуза
					if ( (SideA * SideA + SideB * SideB).AlmostEquals(SideC * SideC) )
						_Area = SideA * SideB / 2;
					//Прямоугольный треугольник, где B - гипотенуза
					else if ( (SideA * SideA + SideC * SideC).AlmostEquals(SideB * SideB) )
						_Area = SideA * SideC / 2;
					//Прямоугольный треугольник, где A - гипотенуза
					else if ( (SideB * SideB + SideC * SideC).AlmostEquals(SideA * SideA) )
						_Area = SideB * SideC / 2;
					//Обычный треугольник
					else
					{
						double p = (SideA + SideB + SideC) / 2;
						_Area = Math.Sqrt(p*(p-SideA)*(p-SideB)*(p-SideC));
					}
				}
				return _Area;
			}
		}

		

		/// <summary>
		/// Значение первой стороны
		/// </summary>
		private double _SideA;
		/// <summary>
		/// Одна из сторон треугольника
		/// </summary>
		public double SideA
		{
			get => _SideA;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), $"Side should be greater than 0.");
				else if (!IsValidTriangle(value, SideB, SideC))
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {value}; {SideB}; {SideC} is not valid. {nameof(SideA)} should be less than {SideB+SideC}");

				_SideA = value;
				MarkAreaDirty();
			}
		}

		/// <summary>
		/// Значение второй стороны
		/// </summary>
		private double _SideB;
		/// <summary>
		/// Одна из сторон треугольника
		/// </summary>
		public double SideB
		{
			get => _SideB;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(SideB)} should be greater than 0.");
				else if (!IsValidTriangle(SideA, value, SideC))
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {SideA}; {value}; {SideC} is not valid. {nameof(SideB)} should be less than {SideA+SideC}");

				_SideB = value;
				MarkAreaDirty();
			}
		}

		/// <summary>
		/// Значение третьей стороны
		/// </summary>
		private double _SideC;
		/// <summary>
		/// Одна из сторон треугольника
		/// </summary>
		public double SideC
		{
			get => _SideC;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(SideC)} should be greater than 0.");
				else if (!IsValidTriangle(SideA, SideB, value))
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {SideA}; {SideB}; {value} is not valid. {nameof(SideC)} should be less than {SideA+SideB}");

				_SideC = value;
				MarkAreaDirty();
			}
		}

		/// <summary>
		/// Создать треугольник с указанными сторонами.
		/// </summary>
		/// <param name="sideA">Первая сторона треугольника</param>
		/// <param name="sideB">Вторая сторона треугольника</param>
		/// <param name="sideC">Третья сторона треугольника</param>
		public Triangle(double sideA, double sideB, double sideC)
		{
			if (!IsValidTriangle(sideA, sideB, sideC))
				throw new ArgumentException($"Triangle with sides {sideA}; {sideB}; {sideC} is not valid.");

			_SideA = sideA;
			_SideB = sideB;
			_SideC = sideC;
			MarkAreaDirty();
		}

		/// <summary>
		/// Проверяет, существует ли треугольник с заданными сторонами
		/// </summary>
		/// <param name="a">Первая сторона</param>
		/// <param name="b">Вторая сторона</param>
		/// <param name="c">Третья сторона</param>
		/// <returns>True, если треугольник существует, иначе false.</returns>
		protected static bool IsValidTriangle(double a, double b, double c)
		{
			return a + b > c && a + c > b && b + c > a;
		}
	}
}
