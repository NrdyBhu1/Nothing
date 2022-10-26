using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Nothing 
{
    public class EnemyManager 
    {
        private Enemy[] enemies;
        private Random random;
        private SoundEffect effect;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            random = new Random();
            enemies = new Enemy[100];
            for (int i = 0; i < 100; i++)
            {
                enemies[i] = new Enemy();
                enemies[i].Initialize(graphicsDevice, random);
            }

            effect = content.Load<SoundEffect>("mutantdie");
        }

        public bool Click(Point mousePos)
        {
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
                    return true;
                }
            }

            return false;
        }

        public void Update(Vector2 position)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].disabled)
                    continue;

                enemies[i].Update(position);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].disabled || enemies[i].OutOfBounds())
                    continue;

                enemies[i].Draw(spriteBatch);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Dispose();
            }
            effect.Dispose();
        }
    }
}