#region File Notice
// Created at: 2013/12/24 3:44 PM
// Last Update time: 2013/12/24 4:03 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library40.Win.Internals
{
	/// <summary>
	///     Handy layout helper utils.
	/// </summary>
	internal static class LayoutUtils
	{
		/// <summary>
		///     Increases the size of the rectangle by the padding
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="padding"></param>
		/// <returns></returns>
		public static Rectangle InflateRect(Rectangle rect, Padding padding)
		{
			rect.X -= padding.Left;
			rect.Y -= padding.Top;
			rect.Width += padding.Horizontal;
			rect.Height += padding.Vertical;
			return rect;
		}

		/// <summary>
		///     Decreases the rectangle by the amount of padding
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="padding"></param>
		/// <returns></returns>
		public static Rectangle DeflateRect(Rectangle rect, Padding padding)
		{
			rect.X += padding.Left;
			rect.Y += padding.Top;
			rect.Width -= padding.Horizontal;
			rect.Height -= padding.Vertical;
			return rect;
		}

		/// <summary>
		///     Given two sizes, returns the maximum width and maximum height
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Size UnionSizes(Size a, Size b)
		{
			return new Size(Math.Max(a.Width, b.Width), Math.Max(a.Height, b.Height));
		}
	}
}