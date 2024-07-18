namespace MindBoxLib
{
	/// <summary>
	/// Описывает сущность, которая имеет площадь.
	/// </summary>
	public interface IHasArea
	{
		/// <summary>
		/// Площадь этой сущности.
		/// </summary>
		double Area { get; }
	}
}