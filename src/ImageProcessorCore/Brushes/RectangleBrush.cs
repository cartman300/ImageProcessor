using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessorCore.Processors;
using ImageProcessorCore;

namespace ImageProcessorCore.Brushes
{
	public class RectangleBrush : Brush
	{
		public Color Color;
		public Rectangle Rectangle;

		public override void Draw(Image source, Image dest,
			IPixelAccessor<Color, uint> sourcePixels, IPixelAccessor<Color, uint> destPixels)
		{
			for (int y = 0; y < Rectangle.Width; y++)
			{
				for (int x = 0; x < Rectangle.Height; x++)
				{
					destPixels[Rectangle.X + x, Rectangle.Y + y] = Color;
				}
			}
		}
	}
}