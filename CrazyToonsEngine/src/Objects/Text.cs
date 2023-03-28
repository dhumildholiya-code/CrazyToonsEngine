﻿using CrazyToonsEngine.src.Utilities;
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


        #region Constructors
        public Text(string name, SpriteFont font, string text, Vector2 pos, Vector2 anchorPos) : base(name, pos)
        {
            depth = 1;
            _font = font;
            _text = text;
            anchorPosition = anchorPos;
            color = Color.White;

            _textSize = _font.MeasureString(text);
            _pivot = _textSize * .5f;
        }
        public Text(string name, SpriteFont font, string text, Transform transform) : base(name, transform)
        {
            depth = 1;
            _font = font;
            _text = text;
            anchorPosition = Anchor.MiddleCenter;
            color = Color.White;

            _textSize = _font.MeasureString(text);
            _pivot = _textSize * .5f;
        }

        #endregion

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(_font, _text, anchorPosition + transform.position, color, 0f, _pivot, 1f, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
