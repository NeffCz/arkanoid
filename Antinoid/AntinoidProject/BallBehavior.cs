using System;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;



namespace AntinoidProject
{
	public class BallBehavior : Behavior
	{

		private const float SPEED = 4f;
		private const int BORDER_OFFSET = 10;

		private Entity player;
		private RectangleCollider rectPlayer;

		private Entity barBot;
		private RectangleCollider rectBarBot;

		private Entity barTop;
		private RectangleCollider rectBarTop;

		private Entity barLeft;
		private RectangleCollider rectBarLeft;

		private Entity barRight;
		private RectangleCollider rectBarRight;

		private int verticalDirection = -1;
		private int horizontalDirection = -1;
		private float speed = SPEED;
		private float incrementSpeed = 0.5f;
		private int goals1 = 0;
		private bool checkGoal = false;

		[RequiredComponent]
		public Transform2D trans2D;

		public int Goal1 { get { return goals1; } private set { goals1 = value; } }
		public int HorizontalDirection { get {return horizontalDirection; } }


		public BallBehavior ()
		{
		}

		public BallBehavior(Entity player, Entity barBot, Entity barTop, Entity barLeft, Entity barRight)
			: base("BallBehavior")
		{
			this.trans2D = null;
//			this.player = player;
//			this.rectPlayer = player.FindComponent<RectangleCollider>();
			this.barBot = barBot;
			this.rectBarBot = barBot.FindComponent<RectangleCollider>();
			this.barTop = barTop;
			this.rectBarTop = barTop.FindComponent<RectangleCollider>();
			this.barLeft = barLeft;
			this.rectBarLeft = barLeft.FindComponent<RectangleCollider> ();
			this.barRight = barRight;
			this.rectBarRight = barRight.FindComponent<RectangleCollider> ();
		}

		protected override void Update(TimeSpan gameTime)
		{
			//Move Ball
			if (trans2D.X > 0 && trans2D.X < WaveServices.Platform.ScreenWidth)
			{
				trans2D.X += horizontalDirection * speed * (gameTime.Milliseconds / 10);
				trans2D.Y += verticalDirection * speed * (gameTime.Milliseconds / 10);
			}

			// Check collisions
//			if (rectPlayer.Contain(new Vector2(trans2D.X, trans2D.Y)))
//			{
//				horizontalDirection = 1;
//				speed += incrementSpeed;
//				(Owner.Scene as GameScene).PlaySoundCollision();
//			}


			if (rectBarBot.Contain(new Vector2(trans2D.X, trans2D.Y+15)))
			{
				verticalDirection = -1;
//				(Owner.Scene as GameScene).PlaySoundCollision();
			}

			if (rectBarTop.Contain(new Vector2(trans2D.X, trans2D.Y)))
			{
				verticalDirection = 1;
//				(Owner.Scene as GameScene).PlaySoundCollision();
			}

			if (rectBarRight.Contain(new Vector2(trans2D.X + 15, trans2D.Y)))
			{
				horizontalDirection = -1;
				//				(Owner.Scene as GameScene).PlaySoundCollision();
			}

			if (rectBarLeft.Contain(new Vector2(trans2D.X, trans2D.Y)))
			{
				horizontalDirection = 1;
				//				(Owner.Scene as GameScene).PlaySoundCollision();
			}
		}

	}
}

