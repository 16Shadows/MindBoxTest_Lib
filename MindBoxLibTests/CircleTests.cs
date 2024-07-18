using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindBoxLib.Tests
{
	[TestClass()]
	public class CircleTests
	{
		[TestMethod()]
		public void CreateWithInvalidRadiusTest()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				new Circle(-5);
			});
		}

		[TestMethod()]
		public void SetInvalidRadiusTest()
		{
			Circle c = new Circle(15);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				c.Radius = -5;
			});
		}

		[TestMethod()]
		public void CreateValid()
		{
			Circle c = new Circle(15);
		}

		[TestMethod()]
		public void AreaTest()
		{
			Circle c = new Circle(15);
			double area = c.Radius * c.Radius * Math.PI;

			Assert.IsTrue(area.AlmostEquals(c.Area), $"Expected {c.Area} to be almost equal to {area}.");

			c.Radius = 5;
			area = c.Radius * c.Radius * Math.PI;
			Assert.IsTrue(area.AlmostEquals(c.Area), $"Expected {c.Area} to be almost equal to {area}.");
		}
	}
}