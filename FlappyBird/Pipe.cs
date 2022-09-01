using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    class Pipe
    {
        public static List<Pipe> PipeList = new List<Pipe>();
        public Rectangle TopPipe;
        public Rectangle BottomPipe;
        public int PositionX;
        public int HeightApart;
        public int Offset;
        private Random random = new Random();

        public Pipe()
        {
            HeightApart = random.Next(220, 300);
            Offset = random.Next(-Game1.PipeTexture.Height, -100);

            PositionX = Game1.Graphics.PreferredBackBufferWidth;

            TopPipe = new Rectangle(PositionX, Offset, Game1.PipeTexture.Width * 2, Game1.PipeTexture.Height * 2);
            BottomPipe = new Rectangle(PositionX, Offset + Game1.PipeTexture.Height * 2 + HeightApart, Game1.PipeTexture.Width * 2, Game1.PipeTexture.Height * 2);
        }

        private void Update()
        {
            PositionX -= 3;
            TopPipe.X = PositionX;
            BottomPipe.X = PositionX;
        }

        private void Draw()
        {
            Game1.SpriteBatch.Draw(Game1.PipeTexture, BottomPipe, null, Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
            Game1.SpriteBatch.Draw(Game1.PipeTexture, TopPipe, null, Color.White, 0f, new Vector2(0), SpriteEffects.FlipVertically, 0f);

        }

        public static Boolean CheckCollision(Player player)
        {
            foreach(Pipe pipe in PipeList)
            {
                if(pipe.TopPipe.Intersects(player.HitBox) || pipe.BottomPipe.Intersects(player.HitBox))
                {
                    return true;
                }
            }

            if (player.HitBox.Y > Game1.Graphics.PreferredBackBufferHeight - 140)
            {
                return true;
            }

            return false;
        }

        public static void UpdatePipes()
        {
            //Spawn Pipes
            if (PipeList[PipeList.Count - 1].PositionX < 200)
            {
                PipeList.Add(new Pipe());
            }

            //Remove Tiles
            Pipe pipeToRemove = null;
            foreach(Pipe pipe in PipeList)
            {
                if (pipe.PositionX < -Game1.PipeTexture.Width * 2) pipeToRemove = pipe;
            }
            if (pipeToRemove != null) PipeList.Remove(pipeToRemove);

            //Update Pipes
            foreach(Pipe pipe in PipeList)
            {
                pipe.Update();
            }
        }

        public static void DrawPipes()
        {
            foreach (Pipe pipe in PipeList)
            {
                pipe.Draw();
            }
        }

    }
}
