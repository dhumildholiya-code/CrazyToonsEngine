using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src
{
    public static class Global
    {
        public static GraphicsDevice GraphicsDevice;
    }
    public static class Screen
    {
        public static int Width;
        public static int Height;
        public static int ViewportWidth;
        public static int ViewportHeight;

        public static int HalfWidth => (int)(Width * .5f);
        public static int HalfHeight => (int)(Height * .5f);

        public static Rectangle RenderRect;
    }
}
