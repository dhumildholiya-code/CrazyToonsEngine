using Microsoft.Xna.Framework;
using System;

namespace CrazyToonsEngine.src.Utilities
{
    public static class Mathf
    {
        public static float Remap(float a, float b, float c, float d, float t)
        {
            float r = ((t - a) / (b - a)) * (d - c) + c;
            return Math.Clamp(r, c, d);
        }
        public static Vector2 RemapVector(Rectangle rect, Vector2 p)
        {
            float x = Remap(rect.X, rect.X + rect.Width, 0, Screen.Width, p.X);
            float y = Remap(rect.Y, rect.Y + rect.Height, 0, Screen.Height, p.Y);
            return new Vector2(x, y);
        }
    }
}
