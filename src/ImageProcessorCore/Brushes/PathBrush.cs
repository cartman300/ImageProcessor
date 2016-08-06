using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessorCore.Processors;
using ImageProcessorCore;

namespace ImageProcessorCore.Brushes
{
	public enum SplineFunction
	{
		Linear, Bezier
	}

	public class PathBrush : Brush
	{
		public Color Color;
		public Point[] Points;
		public SplineFunction Function;

		public override void Draw(Image source, Image dest,
			IPixelAccessor<Color, uint> sourcePixels, IPixelAccessor<Color, uint> destPixels)
		{
			switch (Function)
			{
				case SplineFunction.Linear:
					DrawLinear(source, dest, sourcePixels, destPixels);
					break;
				case SplineFunction.Bezier:
					DrawBezier(source, dest, sourcePixels, destPixels);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public virtual void DrawLinear(Image source, Image dest,
			IPixelAccessor<Color, uint> sourcePixels, IPixelAccessor<Color, uint> destPixels)
		{

		}

		public virtual void DrawBezier(Image source, Image dest,
			IPixelAccessor<Color, uint> sourcePixels, IPixelAccessor<Color, uint> destPixels)
		{

		}
	}
}