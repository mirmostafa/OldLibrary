#region File Notice
// Created at: 2013/12/24 3:44 PM
// Last Update time: 2013/12/24 4:03 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System.Drawing;

namespace Library40.Win.Renderers.Internal
{
	/// <summary>
	///     Provide Office 2007 Blue Theme colors
	/// </summary>
	internal class Office2007ColorTable : ProfessionalColorTable
	{
		#region Static Fixed Colors - Blue Color Scheme
		private static readonly Color _buttonBorder = Color.FromArgb(121, 153, 194);
		private static readonly Color _buttonPressedBegin = Color.FromArgb(248, 181, 106);
		private static readonly Color _buttonPressedEnd = Color.FromArgb(255, 208, 134);
		private static readonly Color _buttonPressedMiddle = Color.FromArgb(251, 140, 60);
		private static readonly Color _buttonSelectedBegin = Color.FromArgb(255, 255, 222);
		private static readonly Color _buttonSelectedEnd = Color.FromArgb(255, 203, 136);
		private static readonly Color _buttonSelectedMiddle = Color.FromArgb(255, 225, 172);
		private static readonly Color _checkBack = Color.FromArgb(255, 227, 149);
		private static readonly Color _contextMenuBack = Color.FromArgb(250, 250, 250);
		private static readonly Color _gripDark = Color.FromArgb(111, 157, 217);
		private static readonly Color _gripLight = Color.FromArgb(255, 255, 255);
		private static readonly Color _imageMargin = Color.FromArgb(233, 238, 238);
		private static readonly Color _menuBorder = Color.FromArgb(134, 134, 134);
		private static readonly Color _menuItemSelectedBegin = Color.FromArgb(255, 213, 103);
		private static readonly Color _menuItemSelectedEnd = Color.FromArgb(255, 228, 145);
		private static readonly Color _menuToolBack = Color.FromArgb(191, 219, 255);
		private static readonly Color _overflowBegin = Color.FromArgb(167, 204, 251);
		private static readonly Color _overflowEnd = Color.FromArgb(101, 147, 207);
		private static readonly Color _overflowMiddle = Color.FromArgb(167, 204, 251);
		private static readonly Color _separatorDark = Color.FromArgb(154, 198, 255);
		private static readonly Color _separatorLight = Color.FromArgb(255, 255, 255);
		private static readonly Color _statusStripDark = Color.FromArgb(172, 201, 238);
		private static readonly Color _statusStripLight = Color.FromArgb(215, 229, 247);
		private static readonly Color _toolStripBegin = Color.FromArgb(227, 239, 255);
		private static readonly Color _toolStripBorder = Color.FromArgb(111, 157, 217);
		private static readonly Color _toolStripContentEnd = Color.FromArgb(164, 195, 235);
		private static readonly Color _toolStripEnd = Color.FromArgb(152, 186, 230);
		private static readonly Color _toolStripMiddle = Color.FromArgb(222, 236, 255);
		#endregion

		#region Identity
		#endregion

		#region ButtonPressed
		/// <summary>
		///     Gets the starting color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientBegin
		{
			get { return _buttonPressedBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientEnd
		{
			get { return _buttonPressedEnd; }
		}

		/// <summary>
		///     Gets the middle color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientMiddle
		{
			get { return _buttonPressedMiddle; }
		}
		#endregion

		#region ButtonSelected
		/// <summary>
		///     Gets the starting color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientBegin
		{
			get { return _buttonSelectedBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientEnd
		{
			get { return _buttonSelectedEnd; }
		}

		/// <summary>
		///     Gets the middle color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientMiddle
		{
			get { return _buttonSelectedMiddle; }
		}

		/// <summary>
		///     Gets the border color to use with ButtonSelectedHighlight.
		/// </summary>
		public override Color ButtonSelectedHighlightBorder
		{
			get { return _buttonBorder; }
		}
		#endregion

		#region Check
		/// <summary>
		///     Gets the solid color to use when the check box is selected and gradients are being used.
		/// </summary>
		public override Color CheckBackground
		{
			get { return _checkBack; }
		}
		#endregion

		#region Grip
		/// <summary>
		///     Gets the color to use for shadow effects on the grip or move handle.
		/// </summary>
		public override Color GripDark
		{
			get { return _gripDark; }
		}

		/// <summary>
		///     Gets the color to use for highlight effects on the grip or move handle.
		/// </summary>
		public override Color GripLight
		{
			get { return _gripLight; }
		}
		#endregion

		#region ImageMargin
		/// <summary>
		///     Gets the starting color of the gradient used in the image margin of a ToolStripDropDownMenu.
		/// </summary>
		public override Color ImageMarginGradientBegin
		{
			get { return _imageMargin; }
		}
		#endregion

		#region MenuBorder
		/// <summary>
		///     Gets the border color or a MenuStrip.
		/// </summary>
		public override Color MenuBorder
		{
			get { return _menuBorder; }
		}
		#endregion

		#region MenuItem
		/// <summary>
		///     Gets the starting color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientBegin
		{
			get { return _toolStripBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientEnd
		{
			get { return _toolStripEnd; }
		}

		/// <summary>
		///     Gets the middle color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		/// <summary>
		///     Gets the starting color of the gradient used when the ToolStripMenuItem is selected.
		/// </summary>
		public override Color MenuItemSelectedGradientBegin
		{
			get { return _menuItemSelectedBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used when the ToolStripMenuItem is selected.
		/// </summary>
		public override Color MenuItemSelectedGradientEnd
		{
			get { return _menuItemSelectedEnd; }
		}
		#endregion

		#region MenuStrip
		/// <summary>
		///     Gets the starting color of the gradient used in the MenuStrip.
		/// </summary>
		public override Color MenuStripGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the MenuStrip.
		/// </summary>
		public override Color MenuStripGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion

		#region OverflowButton
		/// <summary>
		///     Gets the starting color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientBegin
		{
			get { return _overflowBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientEnd
		{
			get { return _overflowEnd; }
		}

		/// <summary>
		///     Gets the middle color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientMiddle
		{
			get { return _overflowMiddle; }
		}
		#endregion

		#region RaftingContainer
		/// <summary>
		///     Gets the starting color of the gradient used in the ToolStripContainer.
		/// </summary>
		public override Color RaftingContainerGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the ToolStripContainer.
		/// </summary>
		public override Color RaftingContainerGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion

		#region Separator
		/// <summary>
		///     Gets the color to use to for shadow effects on the ToolStripSeparator.
		/// </summary>
		public override Color SeparatorDark
		{
			get { return _separatorDark; }
		}

		/// <summary>
		///     Gets the color to use to for highlight effects on the ToolStripSeparator.
		/// </summary>
		public override Color SeparatorLight
		{
			get { return _separatorLight; }
		}
		#endregion

		#region StatusStrip
		/// <summary>
		///     Gets the starting color of the gradient used on the StatusStrip.
		/// </summary>
		public override Color StatusStripGradientBegin
		{
			get { return _statusStripLight; }
		}

		/// <summary>
		///     Gets the end color of the gradient used on the StatusStrip.
		/// </summary>
		public override Color StatusStripGradientEnd
		{
			get { return _statusStripDark; }
		}
		#endregion

		#region ToolStrip
		/// <summary>
		///     Gets the border color to use on the bottom edge of the ToolStrip.
		/// </summary>
		public override Color ToolStripBorder
		{
			get { return _toolStripBorder; }
		}

		/// <summary>
		///     Gets the starting color of the gradient used in the ToolStripContentPanel.
		/// </summary>
		public override Color ToolStripContentPanelGradientBegin
		{
			get { return _toolStripContentEnd; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the ToolStripContentPanel.
		/// </summary>
		public override Color ToolStripContentPanelGradientEnd
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		///     Gets the solid background color of the ToolStripDropDown.
		/// </summary>
		public override Color ToolStripDropDownBackground
		{
			get { return _contextMenuBack; }
		}

		/// <summary>
		///     Gets the starting color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientBegin
		{
			get { return _toolStripBegin; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientEnd
		{
			get { return _toolStripEnd; }
		}

		/// <summary>
		///     Gets the middle color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		/// <summary>
		///     Gets the starting color of the gradient used in the ToolStripPanel.
		/// </summary>
		public override Color ToolStripPanelGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		///     Gets the end color of the gradient used in the ToolStripPanel.
		/// </summary>
		public override Color ToolStripPanelGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion
	}
}