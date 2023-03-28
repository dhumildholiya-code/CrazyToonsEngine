using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public abstract class BaseGameobject : IGameobject
    {
        protected string name;
        protected int depth;
        protected bool isActive;
        public string Name => name;

        public int Depth => depth;

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public bool IsActive()
        {
            return isActive;
        }

        public void SetActive(bool active)
        {
            isActive = active;
        }

        public abstract void Update(GameTime gameTime);
    }
}
