using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Nothing 
{
    public class EnemyManager 
    {
        private static Enemy[] enemies;
        private static SoundEffect effect;

        public static void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            enemies = new Enemy[100];
            for (int i = 0; i < 100; i++)
            {
                enemies[i] = new Enemy();
                enemies[i].Initialize(graphicsDevice);
            }

            effect = content.Load<SoundEffect>("mutantdie");
        }

        public static bool Click()
        {
            Point mousePos = StateManager.NewMouseState.Position;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (
                    // disables
                    enemies[i].disabled != true &&
                    // X axis
                    mousePos.X >= enemies[i].position.X && mousePos.X <= enemies[i].position.X+50 &&
                    // Y axis
                    mousePos.Y >= enemies[i].position.Y && mousePos.Y <= enemies[i].position.Y+50
                )
                {
                    effect.Play();
                    enemies[i].disabled = true;
                    ParticleManager.InstantiateAt(mousePos.ToVector2());
                    return true;
                }
            }

            return false;
        }

        public static void Update(Vector2 position)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].disabled)
                    continue;

                enemies[i].Update(position);
            }

            if (StateManager.OldMouseState.LeftButton == ButtonState.Released && 
                StateManager.NewMouseState.LeftButton == ButtonState.Pressed) {
                    Click();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].disabled || enemies[i].OutOfBounds())
                    continue;

                enemies[i].Draw(spriteBatch);
            }
        }

        public static void Dispose()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Dispose();
            }
            effect.Dispose();
        }
    }
}