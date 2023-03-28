using Microsoft.Xna.Framework;

namespace CrazyToonsEngine.src.Objects
{
    public class Transform
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;

        public Transform()
        {
            position = Vector2.Zero;
            scale = Vector2.One;
            rotation = 0f;
        }
        public Transform(Vector2 position)
        {
            this.position = position;
            scale = Vector2.One;
            rotation = 0f;
        }
        public Transform(Vector2 position, Vector2 scale) : this(position)
        {
            this.scale = scale; 
        }
        public Transform(Vector2 position, float rotation) : this(position)
        {
            this.rotation = rotation;
        }
        public Transform(Vector2 position , Vector2 scale, float rotation) :  this(position, scale)
        {
            this.rotation = rotation;
        }
    }
}
