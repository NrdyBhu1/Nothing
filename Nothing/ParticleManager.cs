using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nothing
{
    /// <summary>
    /// Uses <c>Object Pooling Method</c> for spawning particles.
    /// <para>
    /// Particles are instantiated at the start and only their position are manipulated
    /// </para>
    /// </summary>
    public class ParticleManager
    {
        private Particle[] particles;

        /// <summary>
        /// <param name="graphicsDevice"> graphics device of game </param>
        /// </summary>
        public void Initialize(GraphicsDevice graphicsDevice)
        {

            if (graphicsDevice == null)
                return;

            particles = new Particle[50];

            if (particles == null)
                return;

            for (int i = 0; i < 50; i++)
            {
                particles[i] = new Particle();
                particles[i].Initialize(graphicsDevice, new Vector2(10000f));
            }
        }

        public void InstantiateAt(Vector2 position) {
            for (int i = 0; i < 50; i++)
            {
                particles[i].PopAt(position);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 50; i++)
            {
                if (particles[i].OutOfBounds())
                    continue;

                particles[i].Draw(spriteBatch);
            }
        }

        public void Update()
        {
            for (int i = 0; i < 50; i++)
            {
                if (particles[i].OutOfBounds())
                    continue;

                particles[i].Update();
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Dispose();
            }
        }
    }
}