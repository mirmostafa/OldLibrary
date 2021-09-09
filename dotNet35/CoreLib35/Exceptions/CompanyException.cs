#region File Notice
// Created at: 2013/12/24 3:41 PM
// Last Update time: 2013/12/24 3:58 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Runtime.Serialization;

namespace Library35.Exceptions
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class CompanyException : ExceptionBase
	{
		#region CompanyException
		/// <summary>
		/// </summary>
		public CompanyException()
		{
		}
		#endregion

		#region CompanyException
		protected CompanyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
		#endregion

		#region CompanyException
		/// <summary>
		/// </summary>
		/// <param name="message"> </param>
		public CompanyException(string message)
			: base(message)
		{
		}
		#endregion

		#region CompanyException
		/// <summary>
		/// </summary>
		/// <param name="message"> </param>
		/// <param name="inner"> </param>
		public CompanyException(string message, Exception inner)
			: base(message, inner)
		{
		}
		#endregion

		public static void Throw<TCompanyException>() where TCompanyException : CompanyException, new()
		{
			Throw(() => new TCompanyException());
		}

		public static void Throw<TCompanyException>(Func<TCompanyException> ctor) where TCompanyException : CompanyException
		{
			throw ctor();
		}
	}
}