#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

#endregion
namespace AntinoidProject
{
	public class Game : WaveEngine.Framework.Game
	{
		public override void Initialize (IApplication app)
		{
			base.Initialize (app);
					
			ScreenContext screenContext = new ScreenContext (new GameScene ());
			WaveServices.ScreenContextManager.To (screenContext);
		}
	}
}

