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
        private ParticleManager particleManager;
        private EnemyManager enemyManager;
        private Song song;

        public NothingGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            player = new Player();
            particleManager = new ParticleManager();
            enemyManager = new EnemyManager();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            player.Initialize(_graphics.GraphicsDevice);
            particleManager.Initialize(_graphics.GraphicsDevice);
            enemyManager.Initialize(_graphics.GraphicsDevice, Content);
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
                bool destroyed = enemyManager.Click(Mouse.GetState().Position);
                if (destroyed)
                    particleManager.InstantiateAt(Mouse.GetState().Position.ToVector2());
            }

            // DONE: Add your update logic here

            base.Update(gameTime);
            player.Update();
            particleManager.Update();
            enemyManager.Update(player.position);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            enemyManager.Draw(_spriteBatch);
            particleManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            player.Dispose();
            particleManager.Dispose();
            enemyManager.Dispose();
            song.Dispose();
            base.Dispose(disposing);
        }
    }
}
