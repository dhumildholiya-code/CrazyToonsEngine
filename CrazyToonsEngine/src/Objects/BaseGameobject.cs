using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public abstract class BaseGameobject : IGameobject
    {
        protected string name;
        protected Vector2 position;
        protected Vector2 scale;
        protected Vector2 pivot;
        protected float rotation;

        protected int depth;
        protected bool isActive;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Depth => depth;

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);

        public bool IsActive()
        {
            return isActive;
        }

        public void SetActive(bool active)
        {
            isActive = active;
        }

    }
}
