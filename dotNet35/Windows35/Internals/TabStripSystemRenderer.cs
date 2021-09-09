#region File Notice
// Created at: 2013/12/24 3:42 PM
// Last Update time: 2013/12/24 4:01 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Library35.Windows.Controls;

namespace Library35.Windows.Internals
{
	/// <summary>
	///     This is just the start of what you would do if you wanted to draw using
	///     the theme APIs.
	/// </summary>
	internal class TabStripSystemRenderer : ToolStripSystemRenderer
	{
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			var tabStrip = e.ToolStrip as TabStrip;
			var tab = e.Item as Tab;
			var bounds = new Rectangle(Point.Empty, e.Item.Size);

			if (tab != null && tabStrip != null)
			{
				var tabState = TabItemState.Normal;
				if (tab.Checked)
					tabState |= TabItemState.Selected;
				if (tab.Selected)
					tabState |= TabItemState.Hot;
				TabRenderer.DrawTabItem(e.Graphics, bounds, tabState);
			}
			else
				base.OnRenderButtonBackground(e);
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			base.OnRenderItemText(e);
			var tab = e.Item as Tab;
			if (tab != null && tab.Checked)
			{
				var rect = e.TextRectangle;
				ControlPaint.DrawFocusRectangle(e.Graphics, rect);
			}
		}
	}
}