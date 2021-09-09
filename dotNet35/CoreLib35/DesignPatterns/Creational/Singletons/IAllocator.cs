#region File Notice
// Created at: 2013/12/24 3:41 PM
// Last Update time: 2013/12/24 3:58 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

namespace Library35.DesignPatterns.Creational.Singletons
{
	public interface IAllocator<out T>
		where T : class
	{
		// Properties
		T Instance { get; }
	}
}