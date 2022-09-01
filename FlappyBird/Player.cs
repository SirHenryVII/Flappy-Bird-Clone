using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    class Player
    {
        private float Rotation;
        public Rectangle HitBox;
        public int Velocity;
        private Boolean otherFrame;
        public Boolean jumpPress;
        public Boolean GameOver = false;

        private Texture2D playerSprite;

        public Player(float rotate, Vector2 pos)
        {
            Rotation = rotate;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, Game1.BirdDownFlap.Width * 2, Game1.BirdDownFlap.Height * 2);
            playerSprite = Game1.BirdDownFlap;
            Velocity = 0;
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (!GameOver)
            {
                //Inputs
                if (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
                {
                    if (jumpPress == false)
                    {
                        Velocity = -11;
                        jumpPress = true;
                    }
                }
                else
                {
                    jumpPress = false;
                }
            }
            
            //Update Velocity
            if (otherFrame)
            {
                Velocity += 1;
                otherFrame = false;
            }
            else
            {
                otherFrame = true;
            }

            //Update Player Position
            if(HitBox.Y > 0 || Velocity > 0) HitBox.Y += Velocity;
            
            //Rotation Update
            Rotation = (float)(Velocity/15.0);

        }


        public void Draw()
        {
            Game1.SpriteBatch.Draw(playerSprite, HitBox, null, Color.White, Rotation, new Vector2(Game1.BirdDownFlap.Width/2, Game1.BirdDownFlap.Height/2), SpriteEffects.None, 0f);
        }
    }
}
