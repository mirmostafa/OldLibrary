#region File Notice
// Created at: 2013/12/24 3:41 PM
// Last Update time: 2013/12/24 3:58 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Reflection;

namespace Library35.DesignPatterns.Creational.Singletons
{
	public class StaticAllocator<T> : IAllocator<T>
		where T : class
	{
		// Fields
		private static readonly T _Instance;

		// Methods
		static StaticAllocator()
		{
			var constructor = typeof (T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], new ParameterModifier[0]);
			if (constructor == null)
				throw new Exception("The object that you want to singleton doesn't have a private/protected constructor so the property cannot be enforced.");
			try
			{
				_Instance = constructor.Invoke(new object[0]) as T;
			}
			catch (Exception e)
			{
				throw new Exception("The StaticSingleton couldn't be constructed, check if the type T has a default constructor", e);
			}
		}

		private StaticAllocator()
		{
		}

		#region IAllocator<T> Members
		public T Instance
		{
			get { return _Instance; }
		}
		#endregion

		// Properties

		public void Dispose()
		{
		}
	}
}