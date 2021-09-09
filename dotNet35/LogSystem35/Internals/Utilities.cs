#region File Notice
// Created at: 2013/12/24 3:42 PM
// Last Update time: 2013/12/24 4:00 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System.IO;
using System.Reflection;
using Library35.Globalization;
using Library35.Helpers;
using Library35.LogSystem.Entities;

namespace Library35.LogSystem.Internals
{
	internal class Utilities
	{
		internal static string GernerateFileSpec(DirectoryInfo directory, string prefix, string extension)
		{
			return string.Concat(directory.FullName, "\\", prefix, "_", PersianDateTime.Now.ToDateString('-'), extension);
		}

		internal static Assembly GetCaller()
		{
			var skipFrames = SkipFrameCount();
			return Assembly.GetAssembly(MethodHelper.GetCallerMethod(skipFrames - 1).DeclaringType);
		}

		internal static int SkipFrameCount()
		{
			var i = 1;
			while (MethodHelper.GetCallerMethod(i) != null)
			{
				if (MethodHelper.GetCallerMethod(i).DeclaringType.BaseType != typeof (LogEntity))
					if (!Equals(Assembly.GetAssembly(MethodHelper.GetCallerMethod(i).DeclaringType), Assembly.GetCallingAssembly()))
						if (!MethodHelper.GetCallerMethod(i).DeclaringType.FullName.StartsWith("Library"))
							if (!Assembly.GetAssembly(MethodHelper.GetCallerMethod(i).DeclaringType).GlobalAssemblyCache)
								return i;
				i++;
			}
			return -1;
		}
	}
}