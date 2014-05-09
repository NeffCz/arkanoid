#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Math;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Graphics;
using WaveEngine.Materials;


#endregion
namespace AntinoidProject
{
	// IMPORTANT NOTE
	// Currently Wave Engine references (WaveEngine.*.dll) *must* be added manually.
	// Please follow these steps:
	// 1. Under YourGame project, do right click on References and select "Edit references..."
	// 2. Select ".Net Assembly" tab, and go to:
	//    /Library/Frameworks/WaveEngine.framework/MacLibraries/
	//    , and select the following assemblies:
	//    WaveEngine.Adapter.dll
	//    WaveEngine.Common.dll
	//    WaveEngine.Framework.dll
	// 3. Click on "Add", followed by "Accept", in order to close the window
	// 4. Under YourGameProject project (please note the difference with previous step 1),
	//    do right click on References and select "Edit references..."
	// 5. Select ".Net Assembly" tab, and go to:
	//    /Library/Frameworks/WaveEngine.framework/MacLibraries/
	//    , and select the following assemblies:
	//    WaveEngine.Common.dll
	//    WaveEngine.Components.dll
	//    WaveEngine.Framework.dll
	//    WaveEngine.Materials.dll
	// 6. Click on "Add", followed by "Accept"
	// 7. Build, sorry for the inconveniences, and enjoy :-)
	// One last thing:
	// Some versions of Mono framework need X11, but Mac OS X Mavericks (10.9) does no longer include it.
	// If you have experienced problems with Wave Engine tools, you need to install X11 libraries,
	// that are available from the XQuartz project:
	// https://xquartz.macosforge.org
	public class GameScene : Scene
	{
		protected override void CreateScene ()
		{
			RenderManager.BackgroundColor = Color.Black;
            //RenderManager.DebugLines = true;
			//Insert your code here
			var barTop = new Entity ("barTop")
					.AddComponent (new Sprite ("Content/Texture/wall.wpk"))
					.AddComponent (new SpriteRenderer (DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider()
                {
                    DebugLineColor = Color.Green
                })
				.AddComponent (new Transform2D () {
				XScale = 80
			});

			var barLeft = new Entity ("barLeft")
				.AddComponent (new Sprite ("Content/Texture/wall.wpk"))
				.AddComponent (new SpriteRenderer (DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider()
                {
                    DebugLineColor = Color.Green
                })
				.AddComponent (new Transform2D () {
					YScale = 60
				});
			var barRight = new Entity ("barRight")
				.AddComponent (new Sprite ("Content/Texture/wall.wpk"))
				.AddComponent (new SpriteRenderer (DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider()
                {
                    DebugLineColor = Color.Green
                })
				.AddComponent (new Transform2D () {
					YScale = 60,
					X = WaveServices.Platform.ScreenWidth - 10
				});


			var barBot = new Entity ("barBot")
				.AddComponent (new Sprite ("Content/Texture/wall.wpk"))
				.AddComponent (new SpriteRenderer (DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider()
                {
                    DebugLineColor = Color.Green
                })
				.AddComponent (new Transform2D () {
					XScale = 8,
					Y = WaveServices.Platform.ScreenHeight - 10,
                    X = WaveServices.Platform.ScreenWidth/2 - 40
				})
                .AddComponent(new PlayerBehavior());

			EntityManager.Add (barTop);
			EntityManager.Add (barLeft);
			EntityManager.Add (barRight);
			EntityManager.Add (barBot);


            var brick = new Entity("brick")
                .AddComponent(new Sprite("Content/Texture/brickSmallR.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider()
                {
                    DebugLineColor = Color.Green
                })
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.Platform.ScreenWidth / 2 - 50,
                    Y = WaveServices.Platform.ScreenHeight / 2 - 25
                });

            EntityManager.Add(brick);

			var ball = new Entity("ball")
				.AddComponent(new Sprite("Content/Texture/ball.wpk"))
				.AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new CircleCollider()
                {
                    DebugLineColor = Color.Green
                })
				.AddComponent(new Transform2D()
					{
                        Origin = new Vector2(0.5f,0.5f),
						Y = WaveServices.Platform.ScreenHeight / 2,
						X = WaveServices.Platform.ScreenWidth / 2
					});
				ball.AddComponent(new BallBehavior(null, barBot, barTop, barLeft, barRight, brick));

			EntityManager.Add (ball);
		}

	}
}

