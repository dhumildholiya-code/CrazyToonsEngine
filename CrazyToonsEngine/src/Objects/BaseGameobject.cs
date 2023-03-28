using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

namespace CrazyToonsEngine.src.Objects
{
    public abstract class BaseGameobject : IGameobject
    {
        protected string name;
        public Transform transform;

        protected int depth;
        protected bool isActive;

        #region Constructors
        public BaseGameobject(string name)
        {
            depth = 0;
            isActive = true;
            this.name = name;
            transform = new Transform();
        }
        public BaseGameobject(string name, Vector2 pos) : this(name)
        {
            transform = new Transform(pos);
        }
        public BaseGameobject(string name, Transform transform) : this(name)
        {
            this.transform = transform;
        }

        #endregion

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
