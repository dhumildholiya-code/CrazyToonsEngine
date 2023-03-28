using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public class Sprite : BaseGameobject
    {
        protected Texture2D texture;
        protected Color color;
        protected Vector2 position;
        protected Vector2 scale;
        protected float rotation;

        protected Rectangle DrawRect => new Rectangle((int)position.X, (int)position.Y,
            (int)(texture.Width * scale.X), (int)(texture.Height * scale.Y));

        public Sprite(Texture2D texture, Vector2 position)
        {
            isActive = true;
            this.texture = texture;
            this.color = Color.White;
            this.position = position;
            scale = Vector2.One;
            rotation = 0;
        }
        public Sprite(Texture2D texture, Vector2 position, Color color) : this(texture, position)
        {
            this.color = color;
        }
        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale) : this(texture, position, color)
        {
            this.scale = scale;
        }
        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, float rotation) : this(texture, position, color, scale)
        {
            this.rotation = rotation;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!isActive) return;
            spriteBatch.Draw(texture, DrawRect, null, color);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
