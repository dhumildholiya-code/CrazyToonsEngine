using CrazyToonsEngine.src.InputSystem;
using CrazyToonsEngine.src.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrazyToonsEngine.src.Objects
{
    public class Button : Sprite
    {
        public event EventHandler OnClick;

        public Color normalColor;
        public Color hoverColor;
        public Color pressedColor;
        public Vector2 anchorPosition;

        public Vector2 globalPositon => transform.position + anchorPosition;

        public Button(string name, Texture2D texture, Vector2 position, Vector2 anchorPosition) : base(name, texture, position)
        {
            this.anchorPosition = anchorPosition;
            normalColor = Color.White;
            hoverColor = Color.Gray;
            pressedColor = Color.Green;
        }
        public Button(string name, Texture2D texture, Transform transform) : base(name, texture, transform)
        {
            anchorPosition = Anchor.MiddleCenter;
            normalColor = Color.White;
            hoverColor = Color.Gray;
            pressedColor = Color.Green;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, transform.position + anchorPosition, null, color, transform.rotation,
                pivot, transform.scale, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle buttonRect = new Rectangle((int)(globalPositon.X - pivot.X * transform.scale.X),
                (int)(globalPositon.Y - pivot.Y * transform.scale.Y),
                (int)(Width), (int)(Height));
            Point mousePos = Input.GetMousePosition();
            Rectangle mousePointRect = new Rectangle(mousePos.X, mousePos.Y, 1, 1);

            if (buttonRect.Intersects(mousePointRect))
            {
                color = hoverColor;
                if (Input.GetMouseButton(0))
                {
                    color = pressedColor;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    OnClick?.Invoke(this, null);
                }
            }
            else
            {
                color = normalColor;
            }
        }
    }
}
