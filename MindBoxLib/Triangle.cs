﻿using System;
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
		public double Area => _Area;

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
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {value}; {SideB}; {SideC} is not valid. {nameof(SideA)} should be greater than {SideB+SideC}");

				_SideA = value;
				RecomputeArea();
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
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {SideA}; {value}; {SideC} is not valid. {nameof(SideB)} should be greater than {SideA+SideC}");

				_SideB = value;
				RecomputeArea();
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
					throw new ArgumentOutOfRangeException(nameof(value), $"Triangle with sides {SideA}; {SideB}; {value} is not valid. {nameof(SideC)} should be greater than {SideA+SideB}");

				_SideC = value;
				RecomputeArea();
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
		}

		/// <summary>
		/// Обновить значение площади.
		/// </summary>
		private void RecomputeArea()
		{
			//Прямоугольный треугольник, где C - гипотенуза
			if ( (SideA * SideA + SideB * SideB).AlmostEquals(SideC * SideC) )
				_Area = SideA * SideB / 2;
			//Прямоугольный треугольник, где B - гипотенуза
			else if ( (SideA * SideA + SideC * SideC).AlmostEquals(SideB * SideB) )
				_Area = SideA * SideC / 2;
			//Прямоугольный треугольник, где A - гипотенуза
			else if ( (SideB * SideB + SideC * SideC).AlmostEquals(SideA * SideA) )
				_Area = SideA * SideC / 2;
			//Обычный треугольник
			else
			{
				double p = (SideA + SideB + SideC) / 2;
				_Area = Math.Sqrt(p*(p-SideA)*(p-SideB)*(p-SideC));
			}
		}

		protected static bool IsValidTriangle(double a, double b, double c)
		{
			return a + b > c && a + c > b && b + c > a;
		}
	}
}
