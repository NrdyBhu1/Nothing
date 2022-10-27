using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nothing
{
    public class Enemy
    {
        private Texture2D texture;
        public Vector2 position;
        private Vector2 velocity;
        public bool disabled { get; set; }
        public void Initialize(GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 50, 50);
            Color[] data = new Color[50*50];
            for (int i = 0; i < data.Length; i++) data[i] = Color.Orchid;
            texture.SetData(data);
            position = new Vector2((float)Math.Rand(-100, 1000), (float)Math.Rand(-100, 1000));
            velocity = Vector2.Zero;
            disabled = false;
        }

        public bool OutOfBounds()
        {
            if (position.X >= 800 || position.Y >= 600)
                return true;

            return false;
        }

        public void Update(Vector2 playerPosition)
        {

            position += velocity;

            #region X - axis
            if (playerPosition.X > position.X)
            {
                velocity.X = 1;
            } else if (playerPosition.X < position.X) 
            {
                velocity.X = -1;
            } else 
            {
                velocity.X = 0;
            }
            #endregion

            #region Y - axis
            if (playerPosition.Y > position.Y)
            {
                velocity.Y = 1;
            } else if (playerPosition.Y < position.Y) 
            {
                velocity.Y = -1;
            } else
            {
                velocity.Y = 0;
            }
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Dispose()
        {
            texture.Dispose();
        }
    }
}