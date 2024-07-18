using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindBoxLib.Tests
{
	[TestClass()]
	public class TriangleTests
	{
		[TestMethod()]
		public void CreateWithInvalidSides()
		{
			Assert.ThrowsException<ArgumentException>(() =>
			{
				Triangle t = new Triangle(1, 1, 3);
			});
		}

		[TestMethod()]
		public void SetInvalidSides()
		{
			Triangle t = new Triangle(1, 1, 1);
			
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideA = -5;
			});
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideA = 4;
			});

			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideB = -5;
			});
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideB = 4;
			});

			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideC = -5;
			});
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				t.SideC = 4;
			});
		}

		[TestMethod()]
		public void AreaTest()
		{
			Triangle t = new Triangle(3, 4, 5);
			double area = 6;

			Assert.IsTrue(area.AlmostEquals(t.Area), $"Expected {t.Area} to be almost equal to {area}.");

			t.SideA = 5;
			t.SideC = 3;
			Assert.IsTrue(area.AlmostEquals(t.Area), $"Expected {t.Area} to be almost equal to {area}.");

			t.SideB = 5;
			t.SideA = 4;
			Assert.IsTrue(area.AlmostEquals(t.Area), $"Expected {t.Area} to be almost equal to {area}.");

			t = new Triangle(2, 3, 4);
			area = 2.9;
			Assert.IsTrue(area.AlmostEquals(t.Area, 1), $"Expected {t.Area} to be almost equal to {area}.");
		}
	}
}