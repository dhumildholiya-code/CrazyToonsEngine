using CrazyToonsEngine.src.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.GameSrc
{
    public sealed class Ball : BaseGameobject
    {
        private Sprite _sprite;
        private Text _label;

        public Ball(string name, Vector2 position, Sprite sprite, Text label) : base(name, position)
        {
            _sprite = sprite;
            _label = label;
            _label.anchorPosition = transform.position + Vector2.UnitY * (_sprite.Height + 40f);
        }
        public Ball(string name, Transform transform, Sprite sprite, Text label) : base(name, transform)
        {
            _sprite = sprite;
            _label = label;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, gameTime);
            _label.Draw(spriteBatch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
