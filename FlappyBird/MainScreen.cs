using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    class MainScreen : Screen
    {
        private Player player;
        private Boolean inStartScreen;
        public Boolean GameOver = false;
        bool check = true;

        public MainScreen()
        {
            //Innit Player
            player = new Player(0f, new Vector2((float)(Game1.Graphics.PreferredBackBufferWidth)/2, (float)(Game1.Graphics.PreferredBackBufferHeight / 2.0)));

            //Innit Pipe
            Pipe.PipeList.Add(new Pipe());

            //Innit Start Screen
            inStartScreen = true;

            //Innit Game Over
            GameOver = false;
        }

        public override void DrawScreen()
        {
            //Draw Background
            Game1.SpriteBatch.Draw(Game1.Background, new Vector2(0), null, Color.White, 0f, new Vector2(0), new Vector2((float)(Game1.Graphics.PreferredBackBufferWidth/280.0), (float)(Game1.Graphics.PreferredBackBufferHeight/510.0)), SpriteEffects.None, 0f);

            //Draw Player
            player.Draw();

            //Draw Pipes
            Pipe.DrawPipes();

            //Draw Base
            Game1.SpriteBatch.Draw(Game1.Base, new Vector2(0, Game1.Graphics.PreferredBackBufferHeight - 100), null, Color.White, 0f, new Vector2(0), new Vector2((float)(Game1.Graphics.PreferredBackBufferWidth / 280.0), (float)(Game1.Graphics.PreferredBackBufferHeight / 510.0)), SpriteEffects.None, 0f);

            //Start Screen
            if (inStartScreen) Game1.SpriteBatch.Draw(Game1.Message, new Vector2(50, 50), null, Color.White, 0f, new Vector2(0), new Vector2((float)(2.5)), SpriteEffects.None, 0f);
        }

        public override void Update()
        {
            //Check GameOver
            if (Pipe.CheckCollision(player) && check == true)
            {
                GameOver = true;
                player.GameOver = true;
                player.Velocity = -5;
                check = false;
            }

            //Start Screen
            if (inStartScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    inStartScreen = false;
                }
                else
                {
                    return;
                }
            }

            if (!GameOver)
            {
                //Update Pipes
                Pipe.UpdatePipes();
            }

            //Update Player
            player.Update();
        }

    }
}
