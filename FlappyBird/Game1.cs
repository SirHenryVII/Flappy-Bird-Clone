using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;

        public static Texture2D Zero;
        public static Texture2D One;
        public static Texture2D Two;
        public static Texture2D Three;
        public static Texture2D Four;
        public static Texture2D Five;
        public static Texture2D Six;
        public static Texture2D Seven;
        public static Texture2D Eight;
        public static Texture2D Nine;
        public static Texture2D BirdDownFlap;
        public static Texture2D BirdMidFlap;
        public static Texture2D BirdUpFlap;
        public static Texture2D PipeTexture;
        public static Texture2D Background;
        public static Texture2D GameOver;
        public static Texture2D Base;
        public static Texture2D Message;

        MainScreen mainScreen;

        public Game1()
        {
            //Setup
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            //Change Resolution
            Graphics.PreferredBackBufferHeight = 1000;
            Graphics.PreferredBackBufferWidth = 563;
            Graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Zero = this.Content.Load<Texture2D>("0");
            One = this.Content.Load<Texture2D>("1");
            Two = this.Content.Load<Texture2D>("2");
            Three = this.Content.Load<Texture2D>("3");
            Four = this.Content.Load<Texture2D>("4");
            Five = this.Content.Load<Texture2D>("5");
            Six = this.Content.Load<Texture2D>("6");
            Seven = this.Content.Load<Texture2D>("7");
            Eight = this.Content.Load<Texture2D>("8");
            Nine = this.Content.Load<Texture2D>("9");
            BirdDownFlap = this.Content.Load<Texture2D>("yellowbird-downflap");
            BirdMidFlap = this.Content.Load<Texture2D>("yellowbird-midflap");
            BirdUpFlap = this.Content.Load<Texture2D>("yellowbird-upflap");
            PipeTexture = this.Content.Load<Texture2D>("pipe-green");
            Background = this.Content.Load<Texture2D>("background-day");
            Base = this.Content.Load<Texture2D>("base");
            GameOver = this.Content.Load<Texture2D>("gameover");
            Message = this.Content.Load<Texture2D>("message");

            //Instanciate Screen
            mainScreen = new MainScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mainScreen.GameOver == true && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Pipe.PipeList.Clear();
                mainScreen = new MainScreen();
            }
            mainScreen.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            mainScreen.DrawScreen();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
