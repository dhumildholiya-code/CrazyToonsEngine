using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public class Sprite : BaseGameobject
    {
        protected Texture2D texture;
        protected Color color;
        protected Vector2 pivot;

        public Color Color
        {
            get => color; set => color = value;
        }
        public int Width => texture.Width;
        public int Height => texture.Height;

        protected Rectangle DrawRect => new Rectangle((int)transform.position.X, (int)transform.position.Y,
            (int)(texture.Width * transform.scale.X), (int)(texture.Height * transform.scale.Y));

        #region Constructors
        public Sprite(string name, Texture2D texture, Vector2 position) : base(name, position)
        {
            this.texture = texture;
            this.color = Color.White;
            pivot = new Vector2(texture.Width * .5f, texture.Height * .5f);
        }
        public Sprite(string name, Texture2D texture, Transform transform) : base(name, transform)
        {
            this.texture = texture;
            this.color = Color.White;
            pivot = new Vector2(texture.Width * .5f, texture.Height * .5f);
        }
        #endregion

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, DrawRect, null, color, transform.rotation, pivot, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
