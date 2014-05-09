using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Common.Input;

namespace AntinoidProject
{
    class PlayerBehavior : Behavior
    {
        private const int SPEED = 5;
        private const int LEFT = -1;
        private const int RIGHT  = 1;
        private const int NONE = 0;
        private const int BORDER_OFFSET = 10;

        [RequiredComponent]
        public Transform2D trans2D;

        /// <summary>
        /// 1 or -1 indicating up or down respectively
        /// </summary>
        private int direction;
        private PlayerState currentState, lastState;
        private enum PlayerState { Idle, Left, Right };

        public PlayerBehavior()
            : base("PlayerBehavior")
        {
            this.direction = NONE;
            this.trans2D = null;
            this.currentState = PlayerState.Idle;
        }

        protected override void Update(TimeSpan gameTime)
        {
            currentState = PlayerState.Idle;

            // Keyboard
            var keyboard = WaveServices.Input.KeyboardState;
            if (keyboard.A == ButtonState.Pressed || keyboard.Left == ButtonState.Pressed)
            {
                currentState = PlayerState.Left;
            }
            else if (keyboard.D == ButtonState.Pressed || keyboard.Right == ButtonState.Pressed)
            {
                currentState = PlayerState.Right;
            }

            // Set current state if that one is diferent
            if (currentState != lastState)
            {
                switch (currentState)
                {
                    case PlayerState.Idle:
                        direction = NONE;
                        break;
                    case PlayerState.Left:
                        direction = LEFT;
                        break;
                    case PlayerState.Right:
                        direction = RIGHT;
                        break;
                }
            }

            lastState = currentState;

            // Move sprite
            trans2D.X += direction * SPEED * (gameTime.Milliseconds / 10);

            // Check borders
            if (trans2D.X < BORDER_OFFSET )
            {
                trans2D.X = BORDER_OFFSET ;
            }
            else if (trans2D.X > WaveServices.Platform.ScreenWidth - BORDER_OFFSET - trans2D.XScale * BORDER_OFFSET)
            {
                trans2D.X = WaveServices.Platform.ScreenWidth - BORDER_OFFSET - trans2D.XScale * BORDER_OFFSET;
            }
        }
    }


}
