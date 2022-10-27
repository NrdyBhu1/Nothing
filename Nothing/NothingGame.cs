using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Nothing
{
    public class NothingGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Song song;

        public NothingGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            player = new Player();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            player.Initialize(_graphics.GraphicsDevice);
            ParticleManager.Initialize(_graphics.GraphicsDevice);
            EnemyManager.Initialize(_graphics.GraphicsDevice, Content);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            song = Content.Load<Song>("battle");

            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                bool destroyed = EnemyManager.Click(Mouse.GetState().Position);
                if (destroyed)
                    ParticleManager.InstantiateAt(Mouse.GetState().Position.ToVector2());
            }

            // DONE: Add your update logic here

            base.Update(gameTime);
            player.Update();
            ParticleManager.Update();
            EnemyManager.Update(player.position);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            EnemyManager.Draw(_spriteBatch);
            ParticleManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            player.Dispose();
            ParticleManager.Dispose();
            EnemyManager.Dispose();
            song.Dispose();
            base.Dispose(disposing);
        }
    }
}
