using System;
using System.Drawing;
//using MonoMac.Foundation;
//using MonoMac.AppKit;
//using MonoMac.ObjCRuntime;
using WaveEngine.Adapter;

namespace Antinoid
{
	class Program
	{
		static void Main (string[] args)
        {
            using (App game = new App())
            {
                game.Run();
            }
		}
	}
}


