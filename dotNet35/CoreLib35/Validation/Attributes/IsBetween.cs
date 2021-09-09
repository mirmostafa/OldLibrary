#region File Notice
// Created at: 2013/12/24 3:42 PM
// Last Update time: 2013/12/24 3:59 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;

namespace Library35.Validation.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class IsBetweenAttribute : ValidationAttribute
	{
		public IsBetweenAttribute(long minValue, long maxValue)
		{
			this.MinValue = minValue;
			this.MaxValue = maxValue;
		}

		public long MinValue { get; private set; }

		public long MaxValue { get; private set; }
	}
}