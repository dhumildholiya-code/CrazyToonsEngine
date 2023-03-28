using Microsoft.Xna.Framework.Input;

namespace CrazyToonsEngine.src.InputSystem
{
    public struct GameKey
    {
        public Keys key;
        public bool pressed;
        public bool down;
        public bool released;

        public GameKey(Keys key)
        {
            this.key = key;
            pressed = false;
            down = false;
            released = false;
        }
    }
}
