using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public interface IGameobject
    {
        public string Name { get; set; }
        public int Depth { get; }
        public bool IsActive();
        public void SetActive(bool active);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
