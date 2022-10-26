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
        public float speed { set; get; }

        // private variables
        private KeyboardState state;
        public Vector2 position;
        private Vector2 velocity;
        private Texture2D texture;

        /// <summary>
        /// Player constructor
        /// current speed is set to param speed
        /// <param name="_speed">Player's speed</param>
        /// </summary>
        public Player(float _speed)
        {
            speed = _speed;
        }

        /// <summary>
        /// Player constructor
        /// current speed is set 5f
        /// </summary>
        public Player()
        {
            speed = 5f;
        }

        /// <summary>
        /// Initialization point for Player
        /// </summary>
        public void Initialize(GraphicsDevice graphicsDevice)
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
        public void Update()
        {
            // TODO: Make Centrally Controlled Keyboard state
            state = Keyboard.GetState();

            // position.X += velocity.X * speed;
            // position.Y += velocity.Y * speed;
            position += velocity * speed;

            #region Keyboard
            // KeyDown
            // Up and Down
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
            {
                velocity.Y = -1;
                // Console.WriteLine("Going Down!");
            }
            else if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1;
                // Console.WriteLine("Going Up!");
            }

            // Left and Right
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
            {
                velocity.X = -1;
                // Console.WriteLine("Going Left!");
            }
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                velocity.X = 1;
                // Console.WriteLine("Going Right!");
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

        public void Draw(SpriteBatch spriteBatch)
        {
            // Console.Write("Position: ");
            // Console.WriteLine(position);
            // Console.Write("Velocity: ");
            // Console.WriteLine(velocity);
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Dispose()
        {
            texture.Dispose();
        }
    }
}