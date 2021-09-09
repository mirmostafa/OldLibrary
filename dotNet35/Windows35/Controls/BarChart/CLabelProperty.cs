#region File Notice
// Created at: 2013/12/24 3:42 PM
// Last Update time: 2013/12/24 4:00 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System.ComponentModel;
using System.Drawing;

namespace Library35.Windows.Controls.BarChart
{
	[TypeConverter(typeof (ExpandableObjectConverter))]
	public class CLabelProperty
	{
		private float fFontDefaultSize;
		private Font font;

		public CLabelProperty()
		{
			this.FontDefaultSize = 8f;
			this.Font = new Font("Tahoma", this.FontDefaultSize, FontStyle.Bold);
			this.Color = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
			this.Visible = true;
		}

		public Color Color { get; set; }

		public Font Font
		{
			get { return this.font; }
			set
			{
				this.FontSet(value);
				if (this.font != null)
					this.fFontDefaultSize = this.font.Size;
			}
		}

		[Browsable(false)]
		public float FontDefaultSize
		{
			get { return this.fFontDefaultSize; }
			set { this.fFontDefaultSize = value; }
		}

		public bool Visible { get; set; }

		public void FontReset()
		{
			var name = "Tahoma";
			var bold = FontStyle.Bold;
			if (this.font != null)
			{
				if (this.font.Size == this.fFontDefaultSize)
					return;
				if (this.font.Name != name)
					name = this.font.Name;
				if (this.font.Style != bold)
					bold = this.font.Style;
				this.font.Dispose();
				this.font = null;
			}
			this.font = this.FontDefaultSize <= 0f ? null : new Font(name, this.FontDefaultSize, bold);
		}

		public void FontSet(Font font)
		{
			if (this.font != null)
			{
				this.font.Dispose();
				this.font = null;
			}
			this.font = new Font(font, font.Style);
		}

		public void FontSetSize(float fNewSize)
		{
			if (this.font == null)
				this.font = new Font("Tahoma", fNewSize, FontStyle.Bold);
			else if (this.font.Size != fNewSize)
			{
				var font = this.font;
				this.font = new Font(font.FontFamily, fNewSize, font.Style);
				font.Dispose();
			}
		}
	}
}