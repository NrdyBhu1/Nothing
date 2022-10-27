using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nothing
{
    public class Particle
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float opacity;
        public void Initialize(GraphicsDevice graphicsDevice, Vector2 _position)
        {
            texture = new Texture2D(graphicsDevice, Math.Rand(1, 10), Math.Rand(1, 10));
            Color[] data = new Color[texture.Width * texture.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.SandyBrown;
            texture.SetData(data);
            SetVecs(_position);
            opacity = 1.0f;
        }

        private void SetVecs(Vector2 _position) {
            position = new Vector2(Math.Rand((int)_position.X - 20, (int)_position.X + 20), Math.Rand((int)_position.Y - 20, (int)_position.Y + 20));
            velocity = new Vector2(Math.RandFloat(), Math.RandFloat());
        }

        public void PopAt(Vector2 _position)
        {
            opacity = 1.0f;
            SetVecs(_position);
        }

        public bool OutOfBounds()
        {
            if (position.X >= 800 || position.Y >= 600 || opacity <= 0.1f)
                return true;

            return false;
        }

        public void Update()
        {
            position += velocity;
            opacity -= 0.01f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White * opacity);
        }

        public void Dispose()
        {
            texture.Dispose();
        }
    }
}