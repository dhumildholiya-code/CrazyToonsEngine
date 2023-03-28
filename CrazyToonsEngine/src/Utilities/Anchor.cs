using Microsoft.Xna.Framework;

namespace CrazyToonsEngine.src.Utilities
{
    public class Anchor
    {
        public static readonly Vector2 TopLeft = new Vector2(0, 0);
        public static readonly Vector2 TopCenter = new Vector2(Screen.HalfWidth, 0);
        public static readonly Vector2 TopRight = new Vector2(Screen.Width, 0);
        public static readonly Vector2 MiddleLeft = new Vector2(0, Screen.HalfHeight);
        public static readonly Vector2 MiddleCenter = new Vector2(Screen.HalfWidth, Screen.HalfHeight);
        public static readonly Vector2 MiddleRight = new Vector2(Screen.HalfWidth, Screen.HalfHeight);
        public static readonly Vector2 BottomLeft = new Vector2(0, Screen.Height);
        public static readonly Vector2 BottomCenter = new Vector2(Screen.HalfWidth, Screen.Height);
        public static readonly Vector2 BottomRight = new Vector2(Screen.Width, Screen.Height);
    }
}
