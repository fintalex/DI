using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleExample
{
	class Rectangle
	{
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }

		public int CalculateRectangleArea()
		{
			return Width * Height;
		}
	}

	class Square : Rectangle
	{
		public override int Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				base.Width = value;
			}
		}
		public override int Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
				base.Height = value;
			}
		}
	}
}
