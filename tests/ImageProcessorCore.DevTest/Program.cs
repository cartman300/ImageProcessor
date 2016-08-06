using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using ImageProcessorCore;
using ImageProcessorCore.Formats;
using ImageProcessorCore.Processors;
using ImageProcessorCore.Quantizers;
using ImageProcessorCore.Brushes;

namespace ImageProcessorCore.DevTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Run();
			Console.WriteLine("Done!");
			//Console.ReadLine();
		}

		static void Run()
		{

			using (FileStream Test = File.OpenRead("test.png"))
			using (FileStream Test2 = File.Create("test2.png"))
			{
				Image Img = new Image(Test);

				Brush Fill = new RectangleBrush
				{
					Color = Color.White,
					Rectangle = Img.Bounds
				};

				Brush Path1 = new PathBrush
				{
					Color = Color.Black,
					Function = SplineFunction.Linear
				};

				Brush Path2 = new PathBrush
				{
					Color = Color.Red,
					Function = SplineFunction.Bezier
				};

				Img
					.Draw(Fill)
					.Draw(Path1)
					.Draw(Path2)
					.SaveAsPng(Test2);
			}
		}

	}
}