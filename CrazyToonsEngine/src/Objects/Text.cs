using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.Objects
{
    public class Text : BaseGameobject
    {
        public Vector2 anchorPosition;
        public Color color;

        private SpriteFont _font;
        private string _text;

        private Vector2 _pivot;
        private Vector2 _textSize;


        public Text(SpriteFont font, string text)
        {
            isActive = true;
            depth = 1;
            this._font = font;
            this._text = text;
            position = Vector2.Zero;
            anchorPosition = Anchor.MiddleCenter;
            color = Color.White;

            _textSize = _font.MeasureString(text);
            _pivot = _textSize * .5f;
        }
        public Text(SpriteFont font, string text, Vector2 position) : this(font, text)
        {
            this.position = position;
        }
        public Text(SpriteFont font, string text, Vector2 position, Vector2 anhorPosition) : this(font, text, position)
        {
            anchorPosition = anhorPosition;
        }
        public Text(SpriteFont font, string text, Vector2 position, Color color) : this(font, text, position)
        {
            this.color = color;
        }
        public Text(SpriteFont font, string text, Vector2 position, Vector2 anhorPosition, Color color) : this(font, text, position, anhorPosition)
        {
            this.color = color;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(_font, _text, anchorPosition + position, color, 0f, _pivot, 1f, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
