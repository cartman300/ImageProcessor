using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessorCore;
using ImageProcessorCore.Processors;

namespace ImageProcessorCore
{
	public class Brush
	{
		public virtual void Draw(Image source, Image dest)
		{
			Draw(source, dest, source.Lock(), dest.Lock());
		}

		public virtual void Draw(Image source, Image dest,
			IPixelAccessor<Color, uint> sourcePixels, IPixelAccessor<Color, uint> destPixels)
		{
		}
	}

	public class BrushProcessor
	{
		Brush[] Brushes;

		public BrushProcessor(Brush[] Brushes)
		{
			this.Brushes = Brushes;
		}

		public Image Draw(Image source)
		{
			Image dest = new Image(source);
			for (int i = 0; i < Brushes.Length; i++)
			{
				Brushes[i].Draw(source, dest);
			}
			return dest;
		}
	}

	public static partial class ImageExtensions
	{
		public static Image Draw(this Image source, Brush brush)
		{
			return source.Draw(new[] { brush });
		}

		public static Image Draw(this Image source, Brush[] brushes)
		{
			return new BrushProcessor(brushes).Draw(source);
		}
	}
}