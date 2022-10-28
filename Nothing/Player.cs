using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Nothing
{
    /// <summary>
    /// Nothing Player
    /// </summary>
    public class Player
    {
        // public variables
        public static float speed = 5f;

        // private variables
        public static Vector2 position;
        private static Vector2 velocity;
        private static Texture2D texture;

        /// <summary>
        /// Initialization point for Player
        /// </summary>
        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 30, 80);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            texture.SetData(data);
            position = new Vector2();
            velocity = new Vector2();
        }

        /// <summary>
        /// Player Update function structure:
        ///   - get keyboard state
        ///   - check key presses
        ///   - update position
        /// </summary>
        public static void Update()
        {
            // TODO: Make Centrally Controlled Keyboard state
            KeyboardState state = StateManager.NewKeyboardState;

            position += velocity * speed;

            #region Keyboard
            // KeyDown
            // Up and Down
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
            {
                velocity.Y = -1;
            }
            else if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1;
            }

            // Left and Right
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
            {
                velocity.X = -1;
            }
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                velocity.X = 1;
            }

            // KeyUp
            // Up and Down
            if (state.IsKeyUp(Keys.W) && state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.S) && state.IsKeyUp(Keys.Down))
            {
                velocity.Y = 0;
            }

            // Left and Right
            if (state.IsKeyUp(Keys.A) && state.IsKeyUp(Keys.Left) && state.IsKeyUp(Keys.D) && state.IsKeyUp(Keys.Right))
            {
                velocity.X = 0;
            }
            #endregion
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public static void Dispose()
        {
            texture.Dispose();
        }
    }
}