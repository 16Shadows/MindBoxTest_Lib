using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindBoxLib.Tests
{
	[TestClass()]
	public class DoubleExtensionsTests
	{
		[TestMethod()]
		public void AlmostEqualsTest()
		{
			double a = 26.01;
			double b = 5.1;

			Assert.AreNotEqual(a, b*b);
			Assert.IsTrue(a.AlmostEquals(b*b));
			Assert.IsFalse(a.AlmostEquals(b*b+0.1));
		}

		[TestMethod()]
		public void AlmostEqualsRoundedTest()
		{
			double a = 26.016543;
			double b = 26.011535;

			Assert.AreNotEqual(Math.Round(a, 2), Math.Round(b, 2));
			Assert.IsTrue(a.AlmostEquals(b, 2));
			Assert.IsFalse(a.AlmostEquals(b+0.1, 2));
		}
	}
}